using System.Data;
using System.Linq.Expressions;
using Exo02_R_API_Tatouille.Data;
using Exo02_R_API_Tatouille.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Exo02_R_API_Tatouille.Repositories
{
    public class UserRepository : IRepository<User, string>
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<User> Add(User user)
        {
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetById(string id) => await _db.Users.FindAsync(id);

        public async Task<User?> Get(Expression<Func<User, bool>> predicate) => await _db.Users.FirstOrDefaultAsync(predicate);

        public async Task<IEnumerable<User>> GetAll() => _db.Users;

        public async Task<IEnumerable<User>> GetAll(Expression<Func<User, bool>> predicate) => _db.Users.Where(predicate);

        public async Task<User?> Update(User user)
        {
            var userFromDb = await GetById(user.Id);
            if (userFromDb is null)
                return null;

            if (userFromDb.Email != user.Email)
                userFromDb.Email = user.Email;

            if (userFromDb.Password != user.Password)
                userFromDb.Password = user.Password;

            if (userFromDb.Role != user.Role)
                userFromDb.Role = user.Role;

            if (userFromDb.CreatedAt != user.CreatedAt)
                userFromDb.CreatedAt = user.CreatedAt;

            if (userFromDb.CreatedBy != user.CreatedBy)
                userFromDb.CreatedBy = user.CreatedBy;

            if (userFromDb.LastName != user.LastName)
                userFromDb.LastName = user.LastName;

            if (userFromDb.Email != user.Email)
                userFromDb.Email = user.Email;

            if (userFromDb.FirstName != user.FirstName)
                userFromDb.FirstName = user.FirstName;

            await _db.SaveChangesAsync();
            return userFromDb;
        }

        public async Task<bool> Delete(string id)
        {
            var user = await GetById(id);
            if (user is null)
                return false;

            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
