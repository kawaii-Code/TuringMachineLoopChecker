namespace TuringMachines.TuringMachine;

public class TuringMachineStateBuilder
{
    private readonly string _stateToBuildName;
    private readonly Dictionary<Letter, TuringMachineAction> _stateActions = new();

    public TuringMachineStateBuilder(string stateToBuildName)
    {
        _stateToBuildName = stateToBuildName;
    }

    public void AddAction(Letter letter, TuringMachineAction action) =>
        _stateActions.Add(letter, action);

    public TuringMachineState Build() => 
        new(_stateToBuildName, _stateActions);
}