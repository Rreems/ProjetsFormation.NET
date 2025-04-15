using Exercice03.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercice03.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<AppUser> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
