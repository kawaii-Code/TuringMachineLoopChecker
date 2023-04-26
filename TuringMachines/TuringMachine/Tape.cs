namespace TuringMachines.TuringMachine;

public class Tape
{
    private readonly Letter[] _tape;

    private Tape(Letter[] tape)
    {
        _tape = tape;
    }

    public int Length => _tape.Length;

    public Letter this[int index]
    {
        get => _tape[index];
        set => _tape[index] = value;
    }

    public static Tape From(int tapeSize, string word)
    {
        Letter[] chars = new Letter[tapeSize];
        for (int i = 0; i < word.Length; i++) 
            chars[i] = word[i] == ' ' ? Letter.Empty : Letter.From(word[i]);
        for (int i = word.Length; i < tapeSize; i++)
            chars[i] = Letter.Empty;
        return new Tape(chars);
    }

    public string AsString() => 
        new(_tape.Select(symbol => symbol.IsEmpty ? '^' : symbol.Value).ToArray());
}