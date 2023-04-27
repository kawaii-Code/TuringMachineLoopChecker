using TuringMachines.TuringMachine;

namespace TuringMachines;

public class TuringMachineLoopChecker
{
    private readonly ITuringMachine _target;
    private readonly HashSet<TuringMachineInfo> _previousStates = new();

    public TuringMachineLoopChecker(ITuringMachine target)
    {
        _target = target;
    }

    public bool IsLooped()
    {
        while (_target.Next())
        {
            TuringMachineInfo currentInfo = new(_target.CurrentState.Name, _target.Tape.AsString(), _target.Position);
            if (!_previousStates.Add(currentInfo))
                return true;
        }
        return false;
    }
}