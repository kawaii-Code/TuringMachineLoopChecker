namespace TuringMachines;

public struct TuringMachineInfo
{
    public string State;
    public string Tape;
    public int Position;

    public TuringMachineInfo(string state, string tape, int position)
    {
        State = state;
        Tape = tape;
        Position = position;
    }
}