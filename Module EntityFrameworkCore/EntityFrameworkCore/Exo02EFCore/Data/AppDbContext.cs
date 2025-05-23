﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Exo02EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Exo01EFCore.Data;



public class AppDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Chambre> Chambres { get; set; }
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<ReservationChambre> ReservationChambres { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\Exo01EFCore;Integrated Security=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ReservationChambre>().HasKey(rc => new { rc.ReservationId, rc.ChambreId });

        modelBuilder.Entity<Reservation>()
            .HasMany(r => r.Chambres)
            .WithMany(c => c.Reservations)
            .UsingEntity<ReservationChambre>();


        // DATA SEED
        modelBuilder.Entity<Client>().HasData(
            new Client { Id= 2, Nom="Ratata", Prenom="Max", NumeroTelephone="01544884"}
            );
    }
}