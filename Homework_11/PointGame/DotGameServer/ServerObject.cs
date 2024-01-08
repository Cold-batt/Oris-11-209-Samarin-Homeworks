using GameModels;
using System.Net;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text.Json;

namespace DotGameServer;


class ServerObject
{
    TcpListener tcpListener = new TcpListener(IPAddress.Any, 8888);
    public List<ClientObject> clients = new List<ClientObject>(); 
    
    protected internal void RemoveConnection(string id)
    {
        ClientObject? client = clients.FirstOrDefault(c => c.Id == id);
        
        if (client != null) clients.Remove(client);
        client?.Close();
    }

    protected internal async Task ListenAsync()
    {
        try
        {
            tcpListener.Start();
            Console.WriteLine("Сервер запущен. Ожидание подключений...");
 
            while (true)
            {
                TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();
                ClientObject clientObject = new ClientObject(tcpClient, this);
                clients.Add(clientObject);
                Task.Run(clientObject.ProcessAsync);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    protected internal async Task BroadcastMessageAsync()
    {
        var response = GetServerResponse();

        foreach (var client in clients)
        {
            await client.Writer.WriteLineAsync(JsonSerializer.Serialize(response));
            await client.Writer.FlushAsync();
        }
    }

    private ServerResponse GetServerResponse() =>
         new ServerResponse() { Users = GetAllUsers(), DrawingPoints = GetDrawingMap() };
    

    private DrawingPoint[] GetDrawingMap() =>
        clients.SelectMany(x => x.DrawingPoints).ToArray();
    

    public User[] GetAllUsers() =>
         clients.Select(x => x.CurrentUser).ToArray();   
}