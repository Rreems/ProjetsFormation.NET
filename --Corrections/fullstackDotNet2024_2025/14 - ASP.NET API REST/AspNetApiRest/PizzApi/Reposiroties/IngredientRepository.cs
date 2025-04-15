using Microsoft.EntityFrameworkCore;
using PizzApi.Data;
using PizzApi.Models;
using PizzApi.Models.Users;
using System.Linq.Expressions;

namespace PizzApi.Reposiroties
{
    public class IngredientRepository : IRepository<Ingredient, int>
    {
        private readonly AppDbContext _db;

        public IngredientRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Ingredient> Add(Ingredient ingredient)
        {
            await _db.Ingredients.AddAsync(ingredient);
            await _db.SaveChangesAsync();
            return ingredient;
        }

        public async Task<Ingredient?> GetById(int id) => await _db.Ingredients.FindAsync(id);

        public async Task<Ingredient?> Get(Expression<Func<Ingredient, bool>> predicate) => await _db.Ingredients.FirstOrDefaultAsync(predicate);

        public async Task<IEnumerable<Ingredient>> GetAll() => _db.Ingredients;

        public async Task<IEnumerable<Ingredient>> GetAll(Expression<Func<Ingredient, bool>> predicate) => _db.Ingredients.Where(predicate);

        public async Task<Ingredient?> Update(Ingredient ingredient)
        {
            var ingredientFromDb = await GetById(ingredient.Id);
            if (ingredientFromDb is null)
                return null;

            if (ingredientFromDb.Name != ingredient.Name)
                ingredientFromDb.Name = ingredient.Name;
            if (ingredientFromDb.PizzaId != ingredient.PizzaId)
                ingredientFromDb.PizzaId = ingredient.PizzaId;

            await _db.SaveChangesAsync();
            return ingredientFromDb;
        }

        public async Task<bool> Delete(int id)
        {
            var ingredient = await GetById(id);
            if (ingredient is null)
                return false;

            _db.Ingredients.Remove(ingredient);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
