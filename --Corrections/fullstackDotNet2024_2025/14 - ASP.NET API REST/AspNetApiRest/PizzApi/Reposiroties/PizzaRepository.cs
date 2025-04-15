using Microsoft.EntityFrameworkCore;
using PizzApi.Data;
using PizzApi.Models;
using System.Linq.Expressions;

namespace PizzApi.Reposiroties
{
    public class PizzaRepository : IRepository<Pizza, int>
    {
        private readonly AppDbContext _db;

        public PizzaRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Pizza> Add(Pizza pizza)
        {
            await _db.Pizzas.AddAsync(pizza);
            await _db.SaveChangesAsync();
            return pizza;
        }

        public async Task<Pizza?> GetById(int id) => await _db.Pizzas.Include(p => p.Ingredients).FirstOrDefaultAsync(p => p.Id == id);

        public async Task<Pizza?> Get(Expression<Func<Pizza, bool>> predicate) => await _db.Pizzas.FirstOrDefaultAsync(predicate);

        public async Task<IEnumerable<Pizza>> GetAll() => _db.Pizzas;

        public async Task<IEnumerable<Pizza>> GetAll(Expression<Func<Pizza, bool>> predicate) => _db.Pizzas.Where(predicate);

        public async Task<Pizza?> Update(Pizza pizza)
        {
            var pizzaFromDb = await GetById(pizza.Id);
            if (pizzaFromDb is null)
                return null;

            if (pizzaFromDb.Name != pizza.Name)
                pizzaFromDb.Name = pizza.Name;
            if (pizzaFromDb.Price != pizza.Price)
                pizzaFromDb.Price = pizza.Price;
            if (pizzaFromDb.ImageLink != pizza.ImageLink)
                pizzaFromDb.ImageLink = pizza.ImageLink;

            await _db.SaveChangesAsync();
            return pizzaFromDb;
        }

        public async Task<bool> Delete(int id)
        {
            var pizza = await GetById(id);
            if (pizza is null)
                return false;

            _db.Pizzas.Remove(pizza);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
