namespace Demo01.Data
{
    // Repository LEVEL 1 - Synchrone, sans évènements
    public interface IRepository<T> where T : class
    {
        public T Create(T entity);
        public IEnumerable<T> GetAll();
        public T? GetById(int id);
        public T? Update(T entity);
        public bool Delete(T entity);
    }

    // Repository LEVEL 2 - Avec asynchronisme, sans évènements
    public interface IRepositoryLevelTwo<T> where T : class
    {
        public Task<T> Create(T entity);
        public Task<IEnumerable<T>> GetAll();
        public Task<T?> GetById(int id);
        public Task<T?> Update(T entity);
        public Task<bool> Delete(T entity);
    }

    // Repository LEVEL 3 - Asynchronisme, avec évènements
    public interface IRepositoryLevelThree<T> where T : class
    {
        // Les évènements ici sont des "conteneurs" de fonctionnalités, auquel on peut par la suite ajouter des fonctions (ne devant pas avoir de retour), de sorte à pouvoir si l'on le veut informer de la création ou de la modification d'un élément (par sms, par mail, log, Console.WriteLine(), à discretion du développeur lors de la mise en place de l'application) 
        public event Action<T> EntityAdded;
        public event Action<T> EntityUpdated;


        public Task<T> Create(T entity);
        public Task<IEnumerable<T>> GetAll();
        public Task<T?> GetById(int id);
        public Task<T?> Update(T entity);
        public Task<bool> Delete(T entity);
    }


}
