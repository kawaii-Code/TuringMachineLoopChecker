namespace TuringMachines.TuringMachine;

public interface ITuringMachine
{
    public Tape Tape { get; }
    public TuringMachineState CurrentState { get; }
    int Position { get; }

    public bool Next();
}