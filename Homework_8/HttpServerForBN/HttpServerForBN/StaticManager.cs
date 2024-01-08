using HttpServerForBN.Configuration;

namespace HttpServerForBN;

public class StaticManager
{
    private string _defaultPath;
    private string _notFoundPagePath = "./NotFoundPage/not_found.html";
    public StaticManager()
    {
        if (!Directory.Exists(@".\static"))
            Directory.CreateDirectory(@".\static");
        
        _defaultPath = @".\static\index.html";
    }

    public Page GetPage(Uri uri)
    {
        Console.WriteLine(uri.AbsolutePath);
        var absolutePath = CheckAndGetCorrectPath(
            "./static" + uri.AbsolutePath
            );
        
        return new Page(File.ReadAllBytes(absolutePath),
            GetContentType(GetExtensionFromPath(absolutePath)));
    }

    private string CheckAndGetCorrectPath(string path)
    {
        var result = string.Join("/", path.Split("/", StringSplitOptions.RemoveEmptyEntries)
            .Distinct());
        if (result.Equals("./static"))
            return _defaultPath;
        
        return File.Exists(result) ? result : _notFoundPagePath;
    }

    private string GetExtensionFromPath(string path) =>
        path[path.LastIndexOf(".", StringComparison.Ordinal)..];

    private string GetContentType(string fileExtension) =>
        ContentTypeManager.Types[fileExtension];
}