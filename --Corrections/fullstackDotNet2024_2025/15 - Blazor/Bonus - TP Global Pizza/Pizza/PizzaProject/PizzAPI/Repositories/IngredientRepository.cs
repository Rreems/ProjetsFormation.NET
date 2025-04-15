using Microsoft.EntityFrameworkCore;
using PizzAPI.Datas;
using PizzCore.Models;
using System.Linq.Expressions;

namespace PizzAPI.Repositories
{
    public class IngredientRepository : IRepository<Ingredient>
    {
        private ApplicationDbContext _dbContext { get; }
        public IngredientRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // CREATE
        public async Task<int> Add(Ingredient ingredient)
        {
            var addedObj = await _dbContext.Ingredients.AddAsync(ingredient);
            await _dbContext.SaveChangesAsync();
            return addedObj.Entity.Id;
        }

        // READ
        public async Task<Ingredient?> GetById(int id)
        {
            return await _dbContext.Ingredients.FindAsync(id);
        }
        public async Task<Ingredient?> Get(Expression<Func<Ingredient, bool>> predicate)
        {
            return await _dbContext.Ingredients.FirstOrDefaultAsync(predicate);
        }
        public async Task<List<Ingredient>> GetAll()
        {
            return await _dbContext.Ingredients.ToListAsync();
        }
        public async Task<List<Ingredient>> GetAll(Expression<Func<Ingredient, bool>> predicate)
        {
            return await _dbContext.Ingredients.Where(predicate).ToListAsync();
        }

        // UPDATE
        public async Task<bool> Update(Ingredient ingredient)
        {
            var ingredientFromDb = await GetById(ingredient.Id);

            if (ingredientFromDb == null)
                return false;

            if (ingredientFromDb.Name != ingredient.Name)
                ingredientFromDb.Name = ingredient.Name;
            if (ingredientFromDb.PizzaId != ingredient.PizzaId)
                ingredientFromDb.PizzaId = ingredient.PizzaId;

            return await _dbContext.SaveChangesAsync() > 0;
        }

        // DELETE
        public async Task<bool> Delete(int id)
        {
            var ingredient = await GetById(id);
            if (ingredient == null)
                return false;
            _dbContext.Ingredients.Remove(ingredient);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
