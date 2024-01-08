
namespace HttpServerForBN;

public static class Program
{
    static void Main(string[] args)
    {
        var serverController = new ServerController();
        serverController.StartServer();
        serverController.Dispose();
    }
}