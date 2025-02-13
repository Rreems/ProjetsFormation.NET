using System.Collections.Generic;
using Exo06.Models;
using Microsoft.EntityFrameworkCore;

namespace Exo06.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Movie> Movies { get; set; }
}


