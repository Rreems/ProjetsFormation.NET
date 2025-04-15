using CaisseEnregistreuse.Models;
using Microsoft.EntityFrameworkCore;

namespace CaisseEnregistreuse.Tools
{
    public class DataDbContext : DbContext
    {
        public DbSet<Product> Products { get;set; } 
        public DbSet<UserApp> Users { get;set; }
        public DbSet<Category> Categories { get;set; }
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrateur\Documents\BDDCaisseIhab.mdf;Integrated Security=True;Connect Timeout=30";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
