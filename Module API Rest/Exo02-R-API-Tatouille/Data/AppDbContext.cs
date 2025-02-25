using Exo02_R_API_Tatouille.Models;
using Microsoft.EntityFrameworkCore;

namespace Exo02_R_API_Tatouille.Data;

public class AppDbContext : DbContext
{
    public DbSet<Ratatouille> Ratatouilles { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<User> Users { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}
