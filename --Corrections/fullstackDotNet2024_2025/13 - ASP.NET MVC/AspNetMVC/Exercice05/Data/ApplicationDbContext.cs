using Exercice05.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercice05.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Marmoset> Marmosets { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
