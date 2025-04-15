using Microsoft.EntityFrameworkCore;
using PizzApi.Data;
using PizzApi.Models.Users;
using System.Linq.Expressions;

namespace PizzApi.Reposiroties
{
    public class PizzaioloRepository : IRepository<Pizzaiolo, int>
    {
        private readonly AppDbContext _db;

        public PizzaioloRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Pizzaiolo> Add(Pizzaiolo pizzaiolo)
        {
            await _db.Pizzaiolos.AddAsync(pizzaiolo);
            await _db.SaveChangesAsync();
            return pizzaiolo;
        }

        public async Task<Pizzaiolo?> GetById(int id) => await _db.Pizzaiolos.FindAsync(id);

        public async Task<Pizzaiolo?> Get(Expression<Func<Pizzaiolo, bool>> predicate) => await _db.Pizzaiolos.FirstOrDefaultAsync(predicate);

        public async Task<IEnumerable<Pizzaiolo>> GetAll() => _db.Pizzaiolos;

        public async Task<IEnumerable<Pizzaiolo>> GetAll(Expression<Func<Pizzaiolo, bool>> predicate) => _db.Pizzaiolos.Where(predicate);

        public async Task<Pizzaiolo?> Update(Pizzaiolo pizzaiolo)
        {
            var pizzaioloFromDb = await GetById(pizzaiolo.Id);
            if (pizzaioloFromDb is null)
                return null;

            if (pizzaioloFromDb.Email != pizzaiolo.Email)
                pizzaioloFromDb.Email = pizzaiolo.Email;
            if (pizzaioloFromDb.Password != pizzaiolo.Password)
                pizzaioloFromDb.Password = pizzaiolo.Password;

            await _db.SaveChangesAsync();
            return pizzaioloFromDb;
        }

        public async Task<bool> Delete(int id)
        {
            var pizzaiolo = await GetById(id);
            if (pizzaiolo is null)
                return false;

            _db.Pizzaiolos.Remove(pizzaiolo);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
