using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo02RelationsRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo02RelationsRepository.Data
{
    internal class AppDbContext : DbContext
    {
        public AppDbContext() : base() { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<BlogHeader> BlogHeaders { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BlogTag> BlogTags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\EFCore;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            int lastid = 0;// pour éviter d'avoir à saisair les id un par 1 et éviter les conflits
            int lastPostId = 0;// pour éviter d'avoir à saisair les id un par 1 et éviter les conflits

            // HasData permet d'ajouter des données dans la base lors de la création des tables
            modelBuilder.Entity<Blog>().HasData(
                new Blog() { Id = ++lastid, Nom = "JohnnyHalliday115", Url = "http://www.johnnyhalliday115.skyblog.com" },
                new Blog() { Id = ++lastid, Nom = "Koreus", Url = "http://www.koreus.com" },
                new Blog() { Id = ++lastid, Nom = "Toto", Url = "http://www.toto.com" });
                //new Blog() { Id = ++lastid, Nom = "Skyblog de Jennyfer", Url = "http://www.jenn.skyblog.com", 
                //             Posts = { // si nous n'avions pas l'id c'est comme ça qu'il faudrait faire
                //                new Post() { Id = ++lastPostId, Titre = "Kevin m'a larguée", Contenu = "Je suis triste ..." },
                //                new Post() { Id = ++lastPostId, Titre = "On est de nouveau ensemble", Contenu = "Yes !" }
                //    } });


            modelBuilder.Entity<Post>().HasData(
                new Post() { Id = ++lastPostId, Titre = "Johnny est mort.", BlogId = 1, Contenu = "Trop triste :'(" },
                new Post() { Id = ++lastPostId, Titre = "Trop mdr xd la vidéo OLALALA", BlogId = 2, Contenu = "Le chat il tombe là" },
                new Post() { Id = ++lastPostId, Titre = "Trop mdr xd la vidéo 2", BlogId = 2, Contenu = "Le chien il tombe là" },
                new Post() { Id = ++lastPostId, Titre = "Tu connais la blague de toto aux toilettes ?", BlogId = 3, Contenu = "Moi non plus la porte était fermée ^^" }
                );


            //modelBuilder.Entity<BlogHeader>().HasAlternateKey(bh => bh.BlogId); // ajouter une clé alternative (contrainte d'unicité)


            // primary key composite avec les 2 clés étrangères
            modelBuilder.Entity<BlogTag>().HasKey(bt => new { bt.TagId, bt.BlogId });


            // on définit la table et les propriétés de jointure,
            // obligatoire pour ajouter les property-skip sans dupliquer la table en "PostTags" et "PostTag"
            modelBuilder.Entity<Blog>()
                .HasMany(e => e.Tags)
                .WithMany(e => e.Blogs)
                .UsingEntity<BlogTag>(); 



        }
    }
}
