using System.Linq.Expressions;
using TpCaisseEnregistreuse.Data;
using TpCaisseEnregistreuse.Models;

namespace TpCaisseEnregistreuse.Repositories
{
    public class ProduitsRepository : IRepository<Produit>
    {
        private CaisseEnregistreuseContext _dbProduitContext { get; }

        public ProduitsRepository(CaisseEnregistreuseContext dbProduitContext)
        {
            _dbProduitContext = dbProduitContext;
        }

        public bool Add(Produit task)
        {
            var addedObj = _dbProduitContext.Add(task);
            _dbProduitContext.SaveChanges();
            return addedObj.Entity.Id > 0;
        }

        public bool Delete(int id)
        {
            var cat = GetById(id);
            if (cat == null)
                return false;
            _dbProduitContext.Produits.Remove(cat);
            return _dbProduitContext.SaveChanges() > 0;
        }

        public Produit? Get(Expression<Func<Produit, bool>> predicate)
        {
            return _dbProduitContext.Produits.FirstOrDefault(predicate);
        }

        public List<Produit> GetAll()
        {
            return _dbProduitContext.Produits.ToList();
        }

        public List<Produit> GetAll(Expression<Func<Produit, bool>> predicate)
        {
            return _dbProduitContext.Produits.Where(predicate).ToList();
        }

        public Produit? GetById(int id)
        {
            return _dbProduitContext.Produits.Find(id);
        }

        public bool Update(Produit prod)
        {
            var prodFromDb = GetById(prod.Id);

            if (prodFromDb == null)
                return false;

            if (prodFromDb.Name != prod.Name)
                prodFromDb.Name = prod.Name;
            if (prodFromDb.Description != prod.Description)
                prodFromDb.Description = prod.Description;
            if (prodFromDb.Price != prod.Price)
                prodFromDb.Price = prod.Price;
            if (prodFromDb.StorageQuantity != prod.StorageQuantity)
                prodFromDb.StorageQuantity = prod.StorageQuantity;
            if (prodFromDb.ProduitPath != prod.ProduitPath)
                prodFromDb.ProduitPath = prod.ProduitPath;
            return _dbProduitContext.SaveChanges() > 0;
        }

    }
}
