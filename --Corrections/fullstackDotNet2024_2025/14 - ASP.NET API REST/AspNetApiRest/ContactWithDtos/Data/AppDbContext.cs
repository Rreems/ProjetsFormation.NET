using ContactWithDtos.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactWithDtos.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().HasAlternateKey(e => e.Email);
        //}
    }
}
