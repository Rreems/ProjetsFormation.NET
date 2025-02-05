using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exo01EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Exo01EFCore.Data;



public class AppDbContext : DbContext
{
    public DbSet<Personnage> Personnages    { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\Exo01EFCore;Integrated Security=True");
    }
}
