using ZSTemplater.Core.Constructions;
using ZSTemplater.Core.Models;

namespace ZSTemplater.Core.Executor;

public class ConditionExecutor
{
    private List<IfConstruction> _ifConstructions;
    private List<ForConstruction> _forConstructions;
    private MainModel _model;

    public void AddForConstruction(string head, string body)
    {
        _forConstructions.Add(new ForConstruction(head, body));
    }
}