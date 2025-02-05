using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo02EFCore.Repositories;
public interface IRepository<T, Tid> where T : new()
{
    T? Add(T entity);

    T? GetById(Tid id);
    T? Get(Func<T, bool> predicate);
    IEnumerable<T> GetAll();
    IEnumerable<T> GetAll(Func<T, bool> predicate);

    T? Update(Tid id, T entity);
    bool Delete(Tid id);
}
