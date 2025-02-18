using System.Linq.Expressions;
using Microsoft.OpenApi.Models;

namespace Exo01_.Repository;

public interface IRepository<T,Tid> where T : class
{
    public T Add(T entity);
    public T? GetById(Tid id);
    public T? Get(Expression<Func<HamsterRepository, bool>> predicate);
    public IEnumerable<T> GetAll();
    public IEnumerable<T> GetAll(Expression<Func<HamsterRepository, bool>> predicate);
    public T? Update(T entity);
    public bool Delete(T entity);
}