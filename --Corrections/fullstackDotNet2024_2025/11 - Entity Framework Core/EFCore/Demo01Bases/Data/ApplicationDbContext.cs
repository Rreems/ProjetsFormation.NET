using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo01Bases.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo01Bases.Data;

// Le DbContext nous permet de communiquer entre nos modèles et la base de données
internal class ApplicationDbContext : DbContext
{
    // Dans une app qui n'utilise pas d'injection de dépendances, on utilisera ce constructeur
    public ApplicationDbContext() : base()
    {
    }

    // les propriétés de types DbSet<Entité> permettent de définir les tables que nous allons utiliser
    public DbSet<Livre> Livres { get; set; }

    // Méthode appelée lors de la configuration d'EFCore à notre application
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Ici on utilise une méthode de optionsBuilder pour lui spécifier que nous allons utiliser une base de données SqlServer avec la chaine de connexion
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\EFCore;Integrated Security=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Ici, on pourra modifier la BDD avec la FluentAPI d'EFCore


        // DATA SEED => données de base de l'application
        modelBuilder.Entity<Livre>().HasData(new Livre() { Id = 1, Titre = "La recette des crêpes", Auteur = "Arthur DENNETIERE", DatePublication = DateTime.Now, Description = "La meilleure recette de crêpe connue à ce jour" });
        // A noter, l'Id est obligatoire, attention aux CONFLITS avec les ids existants
        // Sert pour créer les données par défaut de notre application
        // DateTime.Now est à éviter, changera la valeur à chaque migration
    }
}
