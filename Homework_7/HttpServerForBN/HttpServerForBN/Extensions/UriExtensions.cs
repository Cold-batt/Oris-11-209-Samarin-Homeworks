namespace HttpServerForBN.Extensions;

public static class UriExtensions
{
    public static bool isEmptyAbsolutePath(this Uri absolutePath) =>
        absolutePath.AbsolutePath.Equals("/");
}