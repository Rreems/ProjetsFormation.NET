using System.Data;
using System.Linq.Expressions;
using Exo02_R_API_Tatouille.Data;
using Exo02_R_API_Tatouille.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Exo02_R_API_Tatouille.Repositories
{
    public class RatatouilleRepository : IRepository<Ratatouille, string>
    {
        private readonly AppDbContext _db;

        public RatatouilleRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Ratatouille> Add(Ratatouille ratatouille)
        {
            await _db.Ratatouilles.AddAsync(ratatouille);
            await _db.SaveChangesAsync();
            return ratatouille;
        }

        public async Task<Ratatouille?> GetById(string id) => await _db.Ratatouilles.Include(r => r.Ingredients)
                                                                                    .FirstOrDefaultAsync(r => r.Id == id);

        public async Task<Ratatouille?> Get(Expression<Func<Ratatouille, bool>> predicate) => await _db.Ratatouilles.Include(r => r.Ingredients)
                                                                                                                    .FirstOrDefaultAsync(predicate);

        public async Task<IEnumerable<Ratatouille>> GetAll() => _db.Ratatouilles.Include(r => r.Ingredients);

        public async Task<IEnumerable<Ratatouille>> GetAll(Expression<Func<Ratatouille, bool>> predicate) => _db.Ratatouilles.Where(predicate).Include(r => r.Ingredients);

        public async Task<Ratatouille?> Update(Ratatouille ratatouille)
        {
            var ratatouilleFromDb = await GetById(ratatouille.Id);
            if (ratatouilleFromDb is null)
                return null;

            if (ratatouilleFromDb.Name != ratatouille.Name)
                ratatouilleFromDb.Name = ratatouille.Name;

            if (ratatouilleFromDb.Description != ratatouille.Description)
                ratatouilleFromDb.Description = ratatouille.Description;

            if (ratatouilleFromDb.Price != ratatouille.Price)
                ratatouilleFromDb.Price = ratatouille.Price;

            if (ratatouilleFromDb.IsVeggie != ratatouille.IsVeggie)
                ratatouilleFromDb.IsVeggie = ratatouille.IsVeggie;

            if (ratatouilleFromDb.IsSpicy != ratatouille.IsSpicy)
                ratatouilleFromDb.IsSpicy = ratatouille.IsSpicy;


            await _db.SaveChangesAsync();
            return ratatouilleFromDb;
        }

        public async Task<bool> Delete(string id)
        {
            var ratatouille = await GetById(id);
            if (ratatouille is null)
                return false;

            _db.Ratatouilles.Remove(ratatouille);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
