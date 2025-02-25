using System.Linq.Expressions;

namespace Exo02_R_API_Tatouille.Repositories;


public interface IRepository<T, Tid> where T : new()
{
    Task<T> Add(T entity);
    Task<T?> GetById(Tid id);
    Task<T?> Get(Expression<Func<T, bool>> predicate); // Expression permet une meilleure optimisation avec EF Core
    Task<IEnumerable<T>> GetAll();
    Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate);
    Task<T?> Update(T entity);
    Task<bool> Delete(Tid id);
}


