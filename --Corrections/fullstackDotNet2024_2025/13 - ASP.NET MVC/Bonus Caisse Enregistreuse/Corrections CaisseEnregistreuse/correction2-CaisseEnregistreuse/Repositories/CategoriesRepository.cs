using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TpCaisseEnregistreuse.Data;
using TpCaisseEnregistreuse.Models;

namespace TpCaisseEnregistreuse.Repositories
{
    public class CategoriesRepository : IRepository<Categorie>
    {
        private CaisseEnregistreuseContext _dbCategorieContext { get; }

        public CategoriesRepository(CaisseEnregistreuseContext dbCategorieContext)
        {
            _dbCategorieContext = dbCategorieContext;
        }

        public bool Add(Categorie task)
        {
            var addedObj = _dbCategorieContext.Add(task);
            _dbCategorieContext.SaveChanges();
            return addedObj.Entity.Id > 0;
        }

        public bool Delete(int id)
        {
            var cat = GetById(id);
            if (cat == null)
                return false;
            _dbCategorieContext.Categories.Remove(cat);
            return _dbCategorieContext.SaveChanges() > 0;
        }

        public Categorie? Get(Expression<Func<Categorie, bool>> predicate)
        {
            return _dbCategorieContext.Categories.FirstOrDefault(predicate);
        }

        public List<Categorie> GetAll()
        {
            return _dbCategorieContext.Categories.ToList();
        }

        public List<Categorie> GetAll(Expression<Func<Categorie, bool>> predicate)
        {
            return _dbCategorieContext.Categories.Where(predicate).ToList();
        }

        public Categorie? GetById(int id)
        {
            var categoryWithProducts = _dbCategorieContext.Categories
                                      .Include(c => c.Produits)
                                      .FirstOrDefault(c => c.Id == id);
            return categoryWithProducts;
        }

        public bool Update(Categorie cat)
        {
            var catFromDb = GetById(cat.Id);

            if (catFromDb == null)
                return false;

            if (catFromDb.Name != cat.Name)
                catFromDb.Name = cat.Name;

            return _dbCategorieContext.SaveChanges() > 0;
        }

    }
}
