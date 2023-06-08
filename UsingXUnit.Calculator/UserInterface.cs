using Microsoft.Extensions.Logging;
using UsingXUnit.Data.Entities;
using UsingXUnit.Data.Repositories.Interfaces;
using UsingXUnit.Interfaces;

namespace UsingXUnit;

public class UserInterface : IUserInterface
{
    private readonly IConsole _console;
    private readonly ILogger _logger;
    private readonly IRepository<Calculation> _repository;

    public UserInterface(IConsole console, ILogger<UserInterface> logger, IRepository<Calculation> repository)
    {
        _console = console;
        _logger = logger;
        _repository = repository;
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
            
            List<double> userInput = new();
            
            switch (input)
            {
                case "1":
                    userInput = GetNumbersFromUser();
                    if (userInput.Count == 2)
                    {
                        var calculator = new Calculator();
                        PrintResult(calculator.Add(userInput[0], userInput[1])); 
                        _repository.Create(new Calculation(userInput[0], userInput[1], '+', calculator.Add(userInput[0], userInput[1])));
                        ReturnToMainMenu();
                    }
                    else
                    {
                        _console.WriteLine("Invalid input. Please try again.");
                        ReturnToMainMenu();
                    }
                    break;
                case "2":
                    userInput = GetNumbersFromUser();
                    if (userInput.Count == 2)
                    {
                        var calculator = new Calculator();
                        PrintResult(calculator.Subtract(userInput[0], userInput[1]));
                        _repository.Create(new Calculation(userInput[0], userInput[1], '-', calculator.Subtract(userInput[0], userInput[1])));
                        ReturnToMainMenu();
                    }
                    else
                    {
                        _console.WriteLine("Invalid input. Please try again.");
                        ReturnToMainMenu();
                    }
                    break;
                case "3":
                    userInput = GetNumbersFromUser();
                    if (userInput.Count == 2)
                    {
                        var calculator = new Calculator();
                        PrintResult(calculator.Multiply(userInput[0], userInput[1]));
                        _repository.Create(new Calculation(userInput[0], userInput[1], '*', calculator.Multiply(userInput[0], userInput[1])));
                        ReturnToMainMenu();
                    }
                    else
                    {
                        _console.WriteLine("Invalid input. Please try again.");
                        ReturnToMainMenu();
                    }
                    break;
                case "4":
                    userInput = GetNumbersFromUser();
                    if (userInput.Count == 2)
                    {
                        var calculator = new Calculator();
                        PrintResult(calculator.Divide(userInput[0], userInput[1]));
                        _repository.Create(new Calculation(userInput[0], userInput[1], '/', calculator.Divide(userInput[0], userInput[1])));
                        ReturnToMainMenu();
                    }
                    else
                    {
                        _console.WriteLine("Invalid input. Please try again.");
                        ReturnToMainMenu();
                    }
                    break;
                case "5":
                    ListPreviousResults();
                    ReturnToMainMenu();
                    break;
            }
        } while (input != "6");
    }

    public void ListPreviousResults()
    {
        var calculations = _repository.ReadAll();
        _console.Clear();
        _console.WriteLine("These are the previous calculations:");
        
        foreach (var calculation in calculations)
        {
            _console.WriteLine($"{calculation.FirstNumber} {calculation.Operation} {calculation.SecondNumber} = {calculation.Result}");
        }
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
            _logger.LogError(e,"Error getting numbers from user");
            return new List<double>();
        }
    }
    
    public void PrintResult(double result)
    {
        _console.WriteLine($"The result is: {result}");
    }
    
    public void ReturnToMainMenu()
    {
        _console.WriteLine("Press any key to return to the main menu...");
        _console.ReadKey();
    }
}