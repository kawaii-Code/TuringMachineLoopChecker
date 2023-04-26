namespace TuringMachines.TuringMachine;

public class TuringMachineAction
{
    public TuringMachineAction(Letter put, int shift, string transitionTo)
    {
        Put = put;
        Shift = shift;
        TransitionTo = transitionTo;
    }
    
    public string TransitionTo { get; }
    public Letter Put { get; }
    public int Shift { get; }
}