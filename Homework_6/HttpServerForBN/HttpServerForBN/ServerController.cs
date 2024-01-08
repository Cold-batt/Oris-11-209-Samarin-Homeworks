namespace HttpServerForBN;


public class ServerController: IDisposable
{
    private const string ServerConfigurationPath = @".\appsettings.json";
    
    private HttpServer _httpServer;
    private bool _isStarted = false;
    

    public void StartServer()
    {
        Console.WriteLine();
        try
        {
            Configurator.UpdateConfig(ServerConfigurationPath);
            _httpServer = new HttpServer();
            _isStarted = !_isStarted;
            _httpServer.StartAsync().Wait();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            _isStarted = !_isStarted;
            Console.WriteLine("Server Stopped...");
        }
    }

    public void Dispose()
    {
        if (_isStarted) 
            _httpServer.Stop();   
    }
}