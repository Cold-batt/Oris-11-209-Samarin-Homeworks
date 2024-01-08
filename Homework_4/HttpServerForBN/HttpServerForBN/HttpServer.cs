using System.Net;
using HttpServerForBN.Handlers;
using static HttpServerForBN.Configurator;


namespace HttpServerForBN;

public class HttpServer
{
    private HttpListener _listener;
    
    private Handler _staticHandler;
    private Handler _controllersHandler;
    public HttpServer()
    {
        _listener = new HttpListener();
        
        _staticHandler = new StaticFilesHandler();
        _controllersHandler = new ControllersHandler();
        
        _listener.Prefixes.Add($"http://{Config.Address}:{Config.Port}/");
    }

    public async Task StartAsync()
    {
        Console.WriteLine("Starting server...");
        _listener.Start();
        Console.WriteLine($"Server started on port: {Config.Port}");
        await ListenAsync();
    }

    public void Stop()
    {
        _listener.Stop();
        _listener.Close();
    }

    private async Task ListenAsync()
    {
        new Task(() =>
        {
            if (Console.ReadLine()!.Equals("stop", StringComparison.OrdinalIgnoreCase))
                Stop();
        }).Start();
        while (true)    
        {
            var context = await _listener.GetContextAsync();
            
            _staticHandler.Successor = _controllersHandler;
            _staticHandler.HandleRequest(context);
        }
    }
}