using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UsingXUnit.Data.Repositories.Interfaces;

namespace UsingXUnit.Data.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly CalculatorDbContext _context;
    private ILogger _logger;

    public Repository(CalculatorDbContext context, ILogger logger)
    {
        _context = context;
        _logger = logger;
    }
    
    public void Create(T entity)
    {
        try
        {
            _context.Set<T>().AddAsync(entity);
            _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            throw;
        }
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public T Read(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> ReadAll()
    {
        throw new NotImplementedException();
    }
}