using System.Net;
using HttpServerForBN.Extensions;

namespace HttpServerForBN.Handlers;

public class StaticFilesHandler: Handler
{
    private StaticManager _manager;

    public StaticFilesHandler()
    {
        _manager = new StaticManager();
    }

    public override async void HandleRequest(HttpListenerContext context)
    {
        var uri = context.Request.Url;
        var segments = uri.Segments;
         
        if (segments.LastOrDefault().Contains('.') || uri.isEmptyAbsolutePath())
        {
            var response = context.Response;
            var page = _manager.GetPage(uri);
            var output = response.OutputStream;
            
            response.ContentType = page.ContentType;
            response.ContentLength64 = page.Length;
            
            await output.WriteAsync(page.Content);
            await output.FlushAsync();
        }
        else if (Successor != null)
        {
            Successor.HandleRequest(context);
        }
    }
}