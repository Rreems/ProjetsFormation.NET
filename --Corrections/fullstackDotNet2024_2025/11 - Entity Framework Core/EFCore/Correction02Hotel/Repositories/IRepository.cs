namespace Correction02Hotel.Repositories;

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
