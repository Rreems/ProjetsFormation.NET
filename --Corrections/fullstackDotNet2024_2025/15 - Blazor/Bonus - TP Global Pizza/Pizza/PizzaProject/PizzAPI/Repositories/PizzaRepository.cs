using Microsoft.EntityFrameworkCore;
using PizzAPI.Datas;
using PizzCore.Models;
using System.Linq.Expressions;

namespace PizzAPI.Repositories
{
    public class PizzaRepository : IRepository<Pizza>
    {
        private ApplicationDbContext _dbContext { get; }
        public PizzaRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // CREATE
        public async Task<int> Add(Pizza pizza)
        {
            var addedObj = await _dbContext.Pizzas.AddAsync(pizza);
            await _dbContext.SaveChangesAsync();
            return addedObj.Entity.Id;
        }

        // READ
        public async Task<Pizza?> GetById(int id)
        {
            return await _dbContext.Pizzas.Include(p => p.Ingredients).FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<Pizza?> Get(Expression<Func<Pizza, bool>> predicate)
        {
            return await _dbContext.Pizzas.Include(p => p.Ingredients).FirstOrDefaultAsync(predicate);
        }
        public async Task<List<Pizza>> GetAll()
        {
            return await _dbContext.Pizzas.Include(p => p.Ingredients).ToListAsync();
        }
        public async Task<List<Pizza>> GetAll(Expression<Func<Pizza, bool>> predicate)
        {
            return await _dbContext.Pizzas.Include(p => p.Ingredients).Where(predicate).ToListAsync();
        }

        // UPDATE
        public async Task<bool> Update(Pizza pizza)
        {
            var pizzaFromDb = await GetById(pizza.Id);

            if (pizzaFromDb == null)
                return false;

            if (pizzaFromDb.Name != pizza.Name)
                pizzaFromDb.Name = pizza.Name;
            if (pizzaFromDb.Price != pizza.Price)
                pizzaFromDb.Price = pizza.Price;
            if (pizzaFromDb.ImageLink != pizza.ImageLink)
                pizzaFromDb.ImageLink = pizza.ImageLink;

            // mettre à jour les ingrédients :
            if (pizza.Ingredients != null)
            {
                // gestion des ingrédients déjà existants en BDD
                foreach (var ingredientFromDb in pizzaFromDb.Ingredients!)
                {
                    var ingredientDejaExistant = pizza.Ingredients.FirstOrDefault(i => i.Name == ingredientFromDb.Name);
                    // l'ingrédient existe déjà donc pas de modification => on le retire des ingrédients à traiter
                    if (ingredientDejaExistant != null)
                    {
                        pizza.Ingredients.Remove(ingredientDejaExistant);
                        continue;
                    }
                    // l'ingrédient a été retiré de la pizza donc on le retire de la BDD
                    _dbContext.Ingredients.Remove(ingredientFromDb);
                }
                // ajout des nouveaux ingrédients (ceux qui restent dans la pizza à traiter)
                foreach (var nouvelIngredient in pizza.Ingredients)
                {
                    await _dbContext.Ingredients.AddAsync(nouvelIngredient);
                }
            }
            else
            {
                // la nouvelle pizza n'a pas d'ingrédients => on supprime les ingrédients existants
                foreach (var ingredientFromDb in pizzaFromDb.Ingredients!)
                {
                    _dbContext.Ingredients.Remove(ingredientFromDb);
                }
            }

            return await _dbContext.SaveChangesAsync() > 0;
        }

        // DELETE
        public async Task<bool> Delete(int id)
        {
            var pizza = await GetById(id);
            if (pizza == null)
                return false;
            _dbContext.Pizzas.Remove(pizza);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
