using TuringMachines.TuringMachine;

namespace TuringMachines;

public struct TuringMachineInfo
{
    public string State;
    public Tape Tape;
    public int Position;

    public TuringMachineInfo(string state, Tape tape, int position)
    {
        State = state;
        Tape = tape;
        Position = position;
    }
}