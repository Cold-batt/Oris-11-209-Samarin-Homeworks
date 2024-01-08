namespace ZSTemplater.Core.Constructions;

public class ForConstruction: IConstruction
{
    public string Head { get; set; }
    public string Body { get; set; }

    public ForConstruction(string head, string body)
    {
        Head = head;
        Body = body;
    }
}