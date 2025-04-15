using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TodoList.Models;

namespace TodoList.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ToDo> ToDos { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDo>().HasData(
            new ToDo { Id = 1, Title = "Salon", Description = "Balayer le sol", Finished = false },
            new ToDo { Id = 2, Title = "Cuisine", Description = "Faire la vaisselle", Finished = false },
            new ToDo { Id = 3, Title = "Chambre", Description = "Balayer le sol", Finished = false });
        }
    }
}
    
    