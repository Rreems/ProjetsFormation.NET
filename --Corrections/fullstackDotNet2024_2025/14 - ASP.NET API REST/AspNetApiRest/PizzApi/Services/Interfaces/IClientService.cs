using PizzApi.Models.Users;

namespace PizzApi.Services.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetAll();
        Task<Client?> GetById(int id);
        Task<Client?> GetByEmail(string email);
        Task<Client> Create(Client client);
        Task<Client> Update(int id, Client client);
        Task Delete(int id);
    }
}
