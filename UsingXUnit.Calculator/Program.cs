using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
        var configuration = new ConfigurationBuilder()
            .SetBasePath("/Users/mac/RiderProjects/UsingXUnit/UsingXUnit.Calculator/")
            .AddJsonFile("appsettings.json")
            .Build();
        
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        var logger = loggerFactory.CreateLogger<UserInterface>();

        var dbContextOptions = new DbContextOptionsBuilder<CalculatorDbContext>()
            .UseSqlServer(connectionString)
            .Options;
        
        var dbContext = new CalculatorDbContext(dbContextOptions);
        var repository = new Repository<Calculation>(dbContext, logger);
        
        IUserInterface userInterface = new UserInterface(new ConsoleWrapper(), logger, repository);
        Calculator app = new Calculator(userInterface);
        app.Run();
    }
}