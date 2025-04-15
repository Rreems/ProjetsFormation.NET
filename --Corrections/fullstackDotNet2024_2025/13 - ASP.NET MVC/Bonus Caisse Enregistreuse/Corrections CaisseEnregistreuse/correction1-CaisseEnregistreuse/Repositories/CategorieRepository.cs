using ExoCaisseEnregistreuse.Data;
using ExoCaisseEnregistreuse.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ExoCaisseEnregistreuse.Repositories
{
    public class CategorieRepository : IRepository<Categorie>
    {

        private ApplicationDbContext _dbContext { get; }
        public CategorieRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public bool Add(Categorie categorie)
        {
            var addedObj = _dbContext.Categories.Add(categorie);
            _dbContext.SaveChanges();
            return addedObj.Entity.Id > 0;
        }

        public bool Delete(int id)
        {
            Categorie categorie = GetById(id);
            if (categorie == null)
                return false;
            _dbContext.Categories.Remove(categorie);
            return _dbContext.SaveChanges() > 0;
        }



        public Categorie? Get(Expression<Func<Categorie, bool>> predicate)
        {
            return _dbContext.Categories.Include(c => c.ListeProduits).FirstOrDefault(predicate);
        }

        public List<Categorie> GetAll()
        {
            return _dbContext.Categories.Include(c => c.ListeProduits).ToList();
        }

        public List<Categorie> GetAll(Expression<Func<Categorie, bool>> predicate)
        {
            return _dbContext.Categories.Include(c => c.ListeProduits).Where(predicate).ToList();
        }

        public Categorie? GetById(int id)
        {
            //return _dbContext.Categories.Find(id); 
            return _dbContext.Categories.Include(c => c.ListeProduits).FirstOrDefault(c => c.Id == id);
        }


        public bool Update(Categorie categorie)
        {
            var categorieFromDb = GetById(categorie.Id);

            if (categorieFromDb == null)
                return false;
            if (categorieFromDb.Nom != categorie.Nom)
                categorieFromDb.Nom = categorie.Nom;
            if (categorieFromDb.ListeProduits != categorie.ListeProduits)
                categorieFromDb.ListeProduits = categorie.ListeProduits;

            return _dbContext.SaveChanges() > 0;
        }
    }
}
