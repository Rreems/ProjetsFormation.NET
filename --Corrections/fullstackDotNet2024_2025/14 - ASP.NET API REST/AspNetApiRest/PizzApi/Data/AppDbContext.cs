using Microsoft.EntityFrameworkCore;
using PizzApi.Models;
using PizzApi.Models.Users;

namespace PizzApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Pizzaiolo> Pizzaiolos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>().HasData(InitialData.Pizzas);
            modelBuilder.Entity<Ingredient>().HasData(InitialData.Ingredients);
        }
    }
}
