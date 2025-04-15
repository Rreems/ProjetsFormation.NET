using IdentityProvider.Models;
using Microsoft.EntityFrameworkCore;

namespace IdentityProvider.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

#nullable disable
        public DbSet<User> Users { get; set; }
#nullable enable

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasAlternateKey(e => e.Email);
            modelBuilder.Entity<User>().ToTable("users");
        }
    }
}
