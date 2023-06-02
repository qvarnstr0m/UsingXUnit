using Microsoft.Extensions.Logging;
using UsingXUnit.Interfaces;

namespace UsingXUnit;

public class UserInterface : IUserInterface
{
    private readonly IConsole _console;
    private readonly ILogger _logger;

    public UserInterface(IConsole console, ILogger<UserInterface> logger)
    {
        _console = console;
        _logger = logger;
    }
    
    public void Menu()
    {
        string input = string.Empty;
        do
        {
            _console.Clear();
            _console.WriteLine("Welcome to the calculator!");
            _console.WriteLine("Please select an option:");
            _console.WriteLine("1. Add two numbers");
            _console.WriteLine("2. Subtract two numbers");
            _console.WriteLine("3. Multiply two numbers");
            _console.WriteLine("4. Divide two numbers");
            _console.WriteLine("5. List previous results");
            _console.WriteLine("6. Exit");
            _console.Write("Enter a valid option: ");
            input = _console.ReadLine();

            switch (input)
            {
                case "1":
                    GetNumbersFromUser();
                    break;
            }
        } while (input != "6");
    }
    
    public List<double> GetNumbersFromUser()
    {
        try
        {
            var numbers = new List<double>();
            _console.Write("Enter the first number: ");
            numbers.Add(double.Parse(_console.ReadLine()));
            _console.Write("Enter the second number: ");
            numbers.Add(double.Parse(_console.ReadLine()));
            return numbers;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error getting numbers from user");
            return new List<double>();
        }
    }
}