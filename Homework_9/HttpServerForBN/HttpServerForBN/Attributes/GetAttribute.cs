namespace HttpServerForBN.Attributes;

public class GetAttribute: HttpMethodAttribute
{
    public GetAttribute(string name) : base(name)
    {
        
    }
}