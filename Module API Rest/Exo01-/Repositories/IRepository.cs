namespace Exo01_.Repository;

public interface IRepository<T> where T : class
{
    public T Create(T entity);
    public IEnumerable<T> GetAll();
    public T? GetById(int id);
    public T? Update(T entity);
    public bool Delete(T entity);
}