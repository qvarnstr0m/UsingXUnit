namespace UsingXUnit.Data.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
    void Create(T entity);
    void Update(T entity);
    void Delete(int id);
    T Read(int id);
    IEnumerable<T> ReadAll();
}