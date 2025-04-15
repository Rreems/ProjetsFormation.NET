using ExoCaisseEnregistreuse.Models;
using Microsoft.EntityFrameworkCore;

namespace ExoCaisseEnregistreuse.Data
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Produit> Produits { get; set; }
        public DbSet<Categorie> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produit>().HasData(
                new Produit()
                {
                    Id =1,
                    Nom = "Cartouches N2O",
                    Description = "Pour faire de la chantilly bien entendu",
                    Prix = 10.99M,
                    QteEnStock =45,
                    CategorieId =1,
                },
            new Produit()
            {
                Id =2,
                Nom = "Saucisses Herta",
                Description = "Le goût des choses simples",
                Prix = 3.5M,
                QteEnStock = 48,
                CategorieId =1,
            },
             new Produit()
             {
                 Id =3,
                 Nom = "Chaussettes RC Lens",
                 Description = "Composition : 93% Polyester, 7% élasthanne",
                 Prix =2.25M,
                 QteEnStock =150,
                 CategorieId =2,
             });
            modelBuilder.Entity<Categorie>().HasData(
 new Categorie()
 {
     Id =1,
     Nom = "Alimentaire",
 },
            new Categorie()
            {
                Id =2,
                Nom = "Vêtements",
            },
             new Categorie()
             {
                 Id =3,
                 Nom = "Bricolage et jardinage",
             });
        }
    }

}