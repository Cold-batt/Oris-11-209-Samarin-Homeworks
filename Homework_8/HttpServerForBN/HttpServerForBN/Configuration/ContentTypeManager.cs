namespace HttpServerForBN.Configuration;


public static class ContentTypeManager
{
    public static readonly Dictionary<string, string> Types = new()
    {
        {".css", "text/css"},
        {".html", "text/html"},
        {".jpg", "image/jpeg"},
        {".png", "image/png"},
        {".ico", "text/vnd.microsoft.icon"},
        {".svg", "text/svg+xml"},
        {".gif", "text/gif"},
    };
}