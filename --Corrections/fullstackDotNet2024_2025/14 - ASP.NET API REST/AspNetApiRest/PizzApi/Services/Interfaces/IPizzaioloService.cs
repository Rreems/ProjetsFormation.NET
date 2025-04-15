using PizzApi.Models.Users;

namespace PizzApi.Services.Interfaces
{
    public interface IPizzaioloService
    {
        Task<IEnumerable<Pizzaiolo>> GetAll();
        Task<Pizzaiolo?> GetById(int id);
        Task<Pizzaiolo?> GetByEmail(string email);
        Task<Pizzaiolo> Create(Pizzaiolo pizzaiolo);
        Task<Pizzaiolo> Update(int id, Pizzaiolo pizzaiolo);
        Task Delete(int id);
    }
}
