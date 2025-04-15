using Microsoft.EntityFrameworkCore;
using TpCaisseEnregistreuse.Models;

namespace TpCaisseEnregistreuse.Data
{
    public class CaisseEnregistreuseContext : DbContext
    {

        public DbSet<Produit> Produits { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public CaisseEnregistreuseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //    modelBuilder.Entity<Categorie>()
            //.HasMany(c => c.ProductList) // Définit une relation un-à-plusieurs entre Categorie et Produit
            //.WithOne(p => p.Categorie) // Définit Produit comme étant l'entité "Plusieurs"
            //.HasForeignKey(p => p.CategorieId); // Définit CategoryId comme étant la clé étrangère dans Produit

            modelBuilder.Entity<Categorie>().HasData(new Categorie()
            {
                Id = 1,
                Name = "Test"
            });

            modelBuilder.Entity<Produit>().HasData(new Produit()
            {
                Id = 1,
                Name = "Test",
                Description = "Test",
                Price = 20,
                StorageQuantity = 1,
                ProductUrl = "Test",
                CategorieId = 1,

            });
        }


    }

}