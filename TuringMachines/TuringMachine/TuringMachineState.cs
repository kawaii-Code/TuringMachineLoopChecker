namespace TuringMachines.TuringMachine;

public class TuringMachineState
{
    private readonly Dictionary<Letter, TuringMachineAction> _actions;

    public readonly string Name;
    
    public TuringMachineState(string name, Dictionary<Letter, TuringMachineAction> actions)
    {
        Name = name;
        _actions = actions;
    }

    public TuringMachineAction ActionFor(Letter current)
    {
        if (!_actions.TryGetValue(current, out TuringMachineAction? action))
            throw new ArgumentException($"Encountered letter '{current}', which is not defined for state '{Name}'!");
        return action;
    }
}