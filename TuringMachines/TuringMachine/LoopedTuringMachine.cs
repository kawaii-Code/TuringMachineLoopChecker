namespace TuringMachines.TuringMachine;

public class LoopedTuringMachine : ITuringMachine
{
    private readonly Dictionary<string, TuringMachineState> _states;

    public LoopedTuringMachine(int tapeSize, string initialWord, Dictionary<string, TuringMachineState> state)
    {
        Tape = Tape.From(tapeSize, initialWord);
        _states = state;
        CurrentState = _states.First(s => s.Key != "q0").Value;
    }
    
    public Tape Tape { get; }
    public TuringMachineState CurrentState { get; private set; }
    public int Position { get; private set; }

    private Letter Current
    {
        get => Tape[Position];
        set => Tape[Position] = value;
    }

    public bool Next()
    {
        TuringMachineAction action = CurrentState.ActionFor(Current);
        PutSymbol(action.Put);
        TransitionTo(action.TransitionTo);
        ShiftPosition(action.Shift);
        return CurrentState.Name != "q0";
    }

    private void PutSymbol(Letter put)
    {
        Current = put;
    }

    private void ShiftPosition(int shift)
    {
        Position += shift;
        
        if (Position == Tape.Length)
            Position = 0;
        else if (Position < 0)
            Position = Tape.Length - 1;
    }

    private void TransitionTo(string transitionTo)
    {
        if (!_states.TryGetValue(transitionTo, out TuringMachineState? state))
            throw new InvalidOperationException($"Trying to transition to state '{state.Name}', which does not exist!");
        CurrentState = state;
    }
}