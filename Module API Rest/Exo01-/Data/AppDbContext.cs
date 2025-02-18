using System.Collections.Generic;
using Exo01_.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exo01_.Data;



public class AppDbContext : DbContext
{
    public DbSet<Hamster> Hamsters { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}