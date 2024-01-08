namespace HttpServerForBN.Attributes;

public class HttpMethodAttribute: Attribute
{
    public string ActionName { get; set; }

    public HttpMethodAttribute(string actionName)
    {
        ActionName = actionName;
    }
}