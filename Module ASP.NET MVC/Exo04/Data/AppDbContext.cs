using Exo04.Models;
using Microsoft.EntityFrameworkCore;

namespace Exo04.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Marsupilami> Marsupilamis { get; set; }
    }
}
