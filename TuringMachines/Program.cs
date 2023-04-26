using TuringMachines.TuringMachine;

namespace TuringMachines;

public static class Program
{
    private const string ProgramDescription = """
        == TURING MACHINE LOOP CHECKER ==
        This program will determine whether the given looped turing machine will get into an infinite loop.
        The important thing is that the turing machine has a looped tape (like a circle), it is not infinite,
        so it is possible to see if it's going to loop.

        Hints:
            'q0' is a reserved state name and '^' stands for an empty symbol.

        Help: 
            Q - Count of states (without the q0 'turned off' state)
            M - Count of state desctription lines
                * Description of state format: 'state' 'symbol' -> 'stateTo' 'putSymbol' 'shift'
            Word - The word initially on the tape
            N - The length of the tape
        
        Example:
        ```
        Q: 1
        M: 1
        States:
        q1 a -> q1 a +1
        Word: aaa
        n: 3
        >>> This turing machine will loop.
        ```

        """;
    
    private static void Intro()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(ProgramDescription);
        Console.ResetColor();
    }

    private static ITuringMachine ReadLoopedTuringMachine()
    {
        int q = Input.Read<int>("Q: ");
        int m = Input.Read<int>("M: ");
        
        Dictionary<string, TuringMachineState> states = ParseStates(q, Input.ReadStrings(m, "States:"));
        if (states.Count != q + 1)
            throw new ArgumentException($"There should have been {q} states, but was {states.Count - 1}!");
        
        string initialWord = Input.ReadString("Word: ");
        int n = Input.Read<int>("n: ");

        return new LoopedTuringMachine(n, initialWord, states);
    }

    public static void Main()
    {
        Intro();
        ITuringMachine turingMachine = ReadLoopedTuringMachine();
        TuringMachineLoopChecker loopChecker = new(turingMachine);
        try
        {
            Console.WriteLine(loopChecker.IsLooped()
                ? "Not OK"
                : "OK");
        }
        catch (Exception exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR: " + exception.Message);
            Console.ResetColor();
            Main();
        }
    }

    private static Dictionary<string, TuringMachineState> ParseStates(int q, IEnumerable<string> strings)
    {
        Dictionary<string, TuringMachineStateBuilder> builders = new(q)
        {
            { "q0", new TuringMachineStateBuilder("q0") }
        };

        foreach (string s in strings)
        {
            string[] data = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name = data[0];
            Letter inputSymbol = Letter.From(data[1][0]);
            string transitionTo = data[3];
            Letter putSymbol = Letter.From(data[4][0]);
            int shift = ParseShift(data[5]);

            TuringMachineAction action = new(putSymbol, shift, transitionTo);
            builders.TryAdd(name, new TuringMachineStateBuilder(name));
            builders[name].AddAction(inputSymbol, action);
        }

        return builders.ToDictionary(pair => pair.Key, pair => pair.Value.Build());
        
        int ParseShift(string s)
        {
            return (s[0], s.Length > 1 ? s[1] : ' ') switch
            {
                ('0', _) => 0,
                ('+', '1') => 1,
                ('-', '1') => -1,
                _ => throw new ArgumentException($"Expected a shift to be one of: '+1', '-1' or '0', but was '{s}'!")
            };
        }
    }
}