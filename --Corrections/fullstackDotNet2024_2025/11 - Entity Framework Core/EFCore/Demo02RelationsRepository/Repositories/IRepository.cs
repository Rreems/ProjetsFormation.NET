using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo02RelationsRepository.Models;

namespace Demo02RelationsRepository.Repositories
{
    // Interface générique qui sera utilisée par tous les repositories (CRUD)
    // T fait référence au model, Tid au type de primary key du model (int, string, guid ...)
    // new() indique que le type T doit être une classe avec un constructeur de base
    internal interface IRepository<T, Tid> where T : new()
    {
        T? Add(T blog); 
        T? GetById(Tid id);
        T? Get(Func<T, bool> predicate); 
        IEnumerable<T> GetAll(); 
        IEnumerable<T> GetAll(Func<T, bool> predicate);
        T? Update(Tid id, T blog);
        bool Delete(Tid id);
    }
}
