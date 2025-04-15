namespace Exercice.Movies.Data.Interfaces;

public interface IRepository<T> where T : class
{
    public IEnumerable<T> GetAll();
    public T? GetById(Guid id);
    public T Add(T entity);
    public T? Update(T entity);
    public bool Delete(Guid id);
}