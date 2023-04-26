namespace TuringMachines.TuringMachine;

public readonly struct Letter
{
    private readonly char _value;

    private Letter(bool isEmpty, char letter = '\0')
    {
        IsEmpty = isEmpty;
        _value = letter;
    }
    
    public bool IsEmpty { get; }
    public char Value => 
        IsEmpty ? throw new InvalidOperationException("Can't get an empty character!") : _value;

    public static Letter Empty => 
        new(true);

    public static Letter From(char letter) =>
        letter == '^' ? Empty : new(false, letter);

    public override string ToString() =>
        IsEmpty ? "^" : Value.ToString();
}