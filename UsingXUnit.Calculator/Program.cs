using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using UsingXUnit;
using UsingXUnit.Interfaces;
using UsingXUnit.Wrappers;

public class Program
{
    public static void Main(string[] args)
    {
        using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        var logger = loggerFactory.CreateLogger<UserInterface>();
        
        IUserInterface userInterface = new UserInterface(new ConsoleWrapper(), logger);
        Calculator app = new Calculator(userInterface);
        app.Run();
    }
}