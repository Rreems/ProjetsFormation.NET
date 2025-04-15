using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PizzApi.Data;
using PizzApi.Models.Users;

namespace PizzApi.Reposiroties
{
    public class ClientRepository : IRepository<Client, int>
    {
        private readonly AppDbContext _db;

        public ClientRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Client> Add(Client client)
        {
            await _db.Clients.AddAsync(client);
            await _db.SaveChangesAsync();
            return client;
        }

        public async Task<Client?> GetById(int id) => await _db.Clients.FindAsync(id);

        public async Task<Client?> Get(Expression<Func<Client, bool>> predicate) => await _db.Clients.FirstOrDefaultAsync(predicate);

        public async Task<IEnumerable<Client>> GetAll() => _db.Clients;

        public async Task<IEnumerable<Client>> GetAll(Expression<Func<Client, bool>> predicate) => _db.Clients.Where(predicate);

        public async Task<Client?> Update(Client client)
        {
            var clientFromDb = await GetById(client.Id);
            if (clientFromDb is null)
                return null;

            if (clientFromDb.Email != client.Email)
                clientFromDb.Email = client.Email;
            if (clientFromDb.Password != client.Password)
                clientFromDb.Password = client.Password;
            if (clientFromDb.FirstName != client.FirstName)
                clientFromDb.FirstName = client.FirstName;
            if (clientFromDb.LastName != client.LastName)
                clientFromDb.LastName = client.LastName;
            if (clientFromDb.PhoneNumber != client.PhoneNumber)
                clientFromDb.PhoneNumber = client.PhoneNumber;
            if (clientFromDb.Address != client.Address)
                clientFromDb.Address = client.Address;

            await _db.SaveChangesAsync();
            return clientFromDb;
        }

        public async Task<bool> Delete(int id)
        {
            var client = await GetById(id);
            if (client is null)
                return false;

            _db.Clients.Remove(client);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
