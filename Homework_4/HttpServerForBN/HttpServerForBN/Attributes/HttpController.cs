namespace HttpServerForBN.Attributes;

public class HttpController: Attribute
{
    public string Name { get; set; }

    public HttpController(string name)
    {
        Name = name;
    }
}