using System.Globalization;

namespace TuringMachines;

public static class Input
{
    public static string ReadString(string messageToUser)
    {
        Console.Write(messageToUser);
        return Console.ReadLine() ?? string.Empty;
    }

    public static IEnumerable<string> ReadStrings(int count, string messageToUser)
    {
        Console.WriteLine(messageToUser);
        
        while (count-- > 0)
        {
            string response = Console.ReadLine() ?? string.Empty;
            yield return response;
        }
    }

    public static T Read<T>(string messageToUser) where T : IParsable<T>
    {
        string response = ReadString(messageToUser);
        return T.Parse(response, CultureInfo.InvariantCulture);
    }
}