using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo02RelationsRepository.Data;
using Demo02RelationsRepository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Demo02RelationsRepository.Repositories
{
    // Classe qui va permettre la persistance des Blogs => en utilisant EFCore ici (on pourrait en faire un autre pour MongoDb/ADO/...)
    // On indique le type d'entité que l'on va manipuler, ainsi que le type de la clé primaire
    internal class BlogRepository : IRepository<Blog, int>  // ou IBlogRepository
    {
        private readonly AppDbContext _db;

        public BlogRepository(AppDbContext db)
        {
            _db = db;
        }

        public Blog? Add(Blog blog)
        {
            EntityEntry<Blog> blogEntity = _db.Add(blog);
            _db.SaveChanges();
            //return blogEntity.Entity.Id > 0; // si le retour était bool

            return blogEntity.Entity;
        }

        public Blog? GetById(int id)
        {
            //return _db.Blogs.Find(id);
            return _db.Blogs
                      .Include(b => b.Posts)
                      .Include(b => b.BlogTags)
                      .FirstOrDefault(b => b.Id == id);

            // Include est à utiliser pour les Listes, car EF Core fait du Lazy Loading
            // Quand on est en ManyToOne ou OneToOne => 1 seule entité => pas de Include
        }

        public Blog? Get(Func<Blog, bool> predicate) // ex: b => b.Url.Contains("johnny")
        {
            return _db.Blogs
                      .Include(b => b.Posts)
                      .Include(b => b.BlogTags)
                      .FirstOrDefault(predicate);
        }

        public IEnumerable<Blog> GetAll()
        {
            return _db.Blogs; // éviter les Includes ici pour des question de performances
        }

        public IEnumerable<Blog> GetAll(Func<Blog, bool> predicate)
        {
            return _db.Blogs.Where(predicate);
        }

        public Blog? Update(int id, Blog blog)
        {
            var blogFromDb = GetById(id);

            if (blogFromDb is null)
                return null;

            //blog.Id = id;
            //_db.Blogs.Update(blog); // a éviter


            if (blogFromDb.Nom != blog.Nom)
                blogFromDb.Nom = blog.Nom;
            if (blogFromDb.Url != blog.Url)
                blogFromDb.Url = blog.Url;

            //return _db.SaveChanges() == 1; // si le retour était bool

            _db.SaveChanges();
            return blogFromDb;
        }

        public bool Delete(int id)
        {
            var blog = GetById(id);

            if (blog is null)
                return false;

            _db.Blogs.Remove(blog);

            return _db.SaveChanges() == 1;
        }
    }
}
