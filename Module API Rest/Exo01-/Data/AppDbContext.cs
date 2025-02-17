using System.Collections.Generic;
using Exo01_.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exo01_.Data;



public class ApplicationDbContext : DbContext
{
    public DbSet<Hamster> Hamsters { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}