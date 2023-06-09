namespace UsingXUnit.Interfaces;

public interface IConsole
{
    string ReadLine();
    void WriteLine(string message);
    void Write(string message);
    void Clear();
    void ReadKey();
}