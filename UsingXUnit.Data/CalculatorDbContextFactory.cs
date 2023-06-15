using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using UsingXUnit.Data;
using Microsoft.Extensions.Configuration;



public class CalculatorDbContextFactory : IDesignTimeDbContextFactory<CalculatorDbContext>
{
    public CalculatorDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        var optionsBuilder = new DbContextOptionsBuilder<CalculatorDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new CalculatorDbContext(optionsBuilder.Options);
    }
}