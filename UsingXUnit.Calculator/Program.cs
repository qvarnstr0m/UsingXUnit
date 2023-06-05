using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using UsingXUnit;
using UsingXUnit.Data;
using UsingXUnit.Data.Entities;
using UsingXUnit.Data.Repositories;
using UsingXUnit.Interfaces;
using UsingXUnit.Wrappers;

public class Program
{
    public static void Main(string[] args)
    {
        using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        var logger = loggerFactory.CreateLogger<UserInterface>();
        var repository = new Repository<Calculation>(new CalculatorDbContext(new DbContextOptionsBuilder<CalculatorDbContext>().Options), logger);
        
        IUserInterface userInterface = new UserInterface(new ConsoleWrapper(), logger, repository);
        Calculator app = new Calculator(userInterface);
        app.Run();
    }
}