using Exercice.Movies.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exercice.Movies.Data.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}