using System.Data;
using System.Linq.Expressions;
using Exo02_R_API_Tatouille.Data;
using Exo02_R_API_Tatouille.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Exo02_R_API_Tatouille.Repositories
{
    public class IngredientRepository : IRepository<Ingredient, string>
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

        public async Task<Ingredient?> GetById(string id) => await _db.Ingredients.FindAsync(id);

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

            if (ingredientFromDb.FirstName != ingredient.FirstName)
                ingredientFromDb.FirstName = ingredient.FirstName;

            if (ingredientFromDb.RatatouilleId != ingredient.RatatouilleId)
                ingredientFromDb.RatatouilleId = ingredient.RatatouilleId;

            await _db.SaveChangesAsync();
            return ingredientFromDb;
        }

        public async Task<bool> Delete(string id)
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
