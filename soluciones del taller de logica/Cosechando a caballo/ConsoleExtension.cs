internal class ConsoleExtension
{
    internal static string? GetString(string v)
    {
        Console.Write(v);
        return Console.ReadLine();
    }
}