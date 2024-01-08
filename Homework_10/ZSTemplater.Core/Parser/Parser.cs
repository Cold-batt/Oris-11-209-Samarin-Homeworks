using System.Text.RegularExpressions;
using ZSTemplater.Core.Enums;
using ZSTemplater.Core.Executor;

namespace ZSTemplater.Core;

public class Parser: IParser
{
    private string _template;
    private ConditionExecutor _executor;

    public Parser(string template)
    {
        _template = template;
    }


    public void Parse(string template)
    {
        var matches = Regex.Matches(template, @"@for(.*\sin\s.*)\s{.*}");
        if (matches.Count == 0)
            return;
        foreach (Match match in matches)
        {
            Console.WriteLine("---------------------------");
            //Console.WriteLine(match.ToString());
            var a = Regex.Match(match.Value, "{.*}").ToString();
            Console.WriteLine(a);
            Parse(a);
        }
    }
    /*
    public void Parse(string template)
    {
        for (var i = 0; i < template.Length; i++)
        {
            if (template[i] == '@')
            {
                var type = DefineConstructionsType(i, template);
                if (type == ConstructionsType.ForConstruction)
                {
                    Console.WriteLine(ParseConditionHead(i + 3, template));
                }
            }
        }
    }

    private string ParseConditionHead(int startIndex, string template)
    {
        var a = template[startIndex..template.Length];
        return a[(a.IndexOf('(') + 1)..a.IndexOf(')')];
    }

    private ConstructionsType DefineConstructionsType(int startIndex, string template)
    {
        var a = template[startIndex..(startIndex + 6)];
        if (Regex.IsMatch(a, @"^@if.*"))
            return ConstructionsType.IfConstruction;
        
        if (Regex.IsMatch(a, @"^@for.*"))
            return ConstructionsType.ForConstruction;
        
        if (Regex.IsMatch(a, @"^@then.*"))
            return ConstructionsType.ThenConstruction;
        
        if (Regex.IsMatch(a, @"^@else.*"))
            return ConstructionsType.ElseConstruction;
        

        return ConstructionsType.Constant;

    }*/
}