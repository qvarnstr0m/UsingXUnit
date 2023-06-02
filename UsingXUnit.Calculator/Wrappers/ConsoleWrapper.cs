using UsingXUnit.Interfaces;

namespace UsingXUnit.Wrappers;


public class ConsoleWrapper : IConsole
{
    public string ReadLine()
    {
        return Console.ReadLine();
    }

    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }
    
    public void Write(string message)
    {
        Console.Write(message);
    }
    
    public void Clear()
    {
        Console.Clear();
    }
    
    public void ReadKey()
    {
        Console.ReadKey();
    }
}