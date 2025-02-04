using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exo01EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Exo01EFCore.Data;

internal class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() : base()
    {
    }

    public DbSet<Personnage> Personnages { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\Exo01EFCore;Integrated Security=True"); 
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    //modelBuilder.Entity<Livre>().HasData(new Livre() { ... });
    //}
}
