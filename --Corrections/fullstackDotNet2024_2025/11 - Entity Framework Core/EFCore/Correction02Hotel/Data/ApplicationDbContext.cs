using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Correction02Hotel.Models;
using Correction02Hotel.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Correction02Hotel.Data
{
    internal class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base()
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationChambre> ReservationChambres { get; set; }
        public DbSet<Chambre> Chambres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\EFCore;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ReservationChambre>()
            //    .HasKey(rc => new { rc.ChambreNumero, rc.ReservationId }); // => remplacé par PrimaryKey sur le model

            modelBuilder.Entity<Chambre>()
                        .HasMany(c => c.Reservations)
                        .WithMany(r => r.Chambres)
                        .UsingEntity<ReservationChambre>();

            // DATA SEED

            modelBuilder.Entity<Chambre>().HasData(new Chambre()
            {
                Numero = 1,
                NombreLits = 2,
                Statut = StatutChambre.Libre,
                Tarif = 100.50M
            },
            new Chambre()
            {
                Numero = 2,
                NombreLits = 4,
                Statut = StatutChambre.Nettoyage,
                Tarif = 400.50M
            });

            modelBuilder.Entity<Client>().HasData(new Client()
            {
                Identifiant = 1,
                Prenom = "Guillaume",
                Nom = "Mairesse",
                Telephone = "0607080910"
            },
            new Client()
            {
                Identifiant = 2,
                Prenom = "Antoine",
                Nom = "Dieudonné",
                Telephone = "0607080911"
            });

        }
    }
}
