using System.Linq.Expressions;

namespace TpCaisseEnregistreuse.Repositories
{
    public interface IRepository<TEntity>
    {
        //CREATE
        bool Add(TEntity task);
        // READ
        TEntity? GetById(int id);
        TEntity? Get(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> GetAll();
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        // UPDATE
        bool Update(TEntity task);
        // DELETE
        bool Delete(int id);
    }
}
