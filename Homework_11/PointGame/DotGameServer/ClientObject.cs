using GameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DotGameServer;
class ClientObject
{
    protected internal string Id { get; } = Guid.NewGuid().ToString();
    protected internal StreamWriter Writer { get; }
    protected internal StreamReader Reader { get; }

    public User CurrentUser;
    public List<DrawingPoint> DrawingPoints;

    TcpClient client;
    ServerObject Server;

    public ClientObject(TcpClient tcpClient, ServerObject ServerObject)
    {
        client = tcpClient;
        Server = ServerObject;
        var stream = client.GetStream();
        DrawingPoints = new List<DrawingPoint>();

        Reader = new StreamReader(stream);
        Writer = new StreamWriter(stream);
    }

    public async Task ProcessAsync()
    {
        try
        {
            var message = await Reader.ReadLineAsync();
            if (string.IsNullOrEmpty(message)) return;
            CurrentUser = JsonSerializer.Deserialize<User>(message);


            await Console.Out.WriteLineAsync($"{CurrentUser.Name}   -  Зашел на сервер");

            await Server.BroadcastMessageAsync();


            while (true)
            {
                try
                {
                    var point = await Reader.ReadLineAsync();
                    if (string.IsNullOrEmpty(point)) continue;

                    var map = JsonSerializer.Deserialize<DrawingPoint>(point);
                    DrawingPoints.Add(map);

                    await Server.BroadcastMessageAsync();
                }
                catch
                {
                    break;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            Server.RemoveConnection(Id);
        }
    }
    protected internal void Close()
    {
        Writer.Close();
        Reader.Close();
        client.Close();
    }
}

