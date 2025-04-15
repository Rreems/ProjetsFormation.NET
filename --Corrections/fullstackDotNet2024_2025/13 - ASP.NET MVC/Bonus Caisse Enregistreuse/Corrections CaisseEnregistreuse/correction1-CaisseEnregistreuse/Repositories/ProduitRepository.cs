using ExoCaisseEnregistreuse.Data;
using ExoCaisseEnregistreuse.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace ExoCaisseEnregistreuse.Repositories
{
    public class ProduitRepository : IRepository<Produit>
    {

        private ApplicationDbContext _dbContext { get; }
        public ProduitRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public bool Add(Produit produit)
        {
            var addedObj = _dbContext.Produits.Add(produit);
            _dbContext.SaveChanges();
            return addedObj.Entity.Id > 0;
        }

        public bool Delete(int id)
        {
            Produit produit = GetById(id);
            if (produit == null)
                return false;
            _dbContext.Produits.Remove(produit);
            return _dbContext.SaveChanges() > 0;
        }



        public Produit? Get(Expression<Func<Produit, bool>> predicate)
        {
            return _dbContext.Produits.Include(p => p.Categorie).FirstOrDefault(predicate);
        }

        public List<Produit> GetAll()
        {
            return _dbContext.Produits.Include(p => p.Categorie).ToList();
        }

        public List<Produit> GetAll(Expression<Func<Produit, bool>> predicate)
        {
            return _dbContext.Produits.Where(predicate).Include(p => p.Categorie).ToList();
        }

        public Produit? GetById(int id)
        {
            //return _dbContext.Produits.Include(p => p.Categorie).Find(id); //marche pas
            return _dbContext.Produits.Include(p => p.Categorie).FirstOrDefault(p => p.Id == id);
        }


        public bool Update(Produit produit)
        {
            var produitFromDb = GetById(produit.Id);

            if (produitFromDb == null)
                return false;
            if (produitFromDb.Nom != produit.Nom)
                produitFromDb.Nom = produit.Nom;
            if (produitFromDb.Description != produit.Description)
                produitFromDb.Description = produit.Description;
            if (produitFromDb.Prix != produit.Prix)
                produitFromDb.Prix = produit.Prix;
            if (produitFromDb.QteEnStock != produit.QteEnStock)
                produitFromDb.QteEnStock = produit.QteEnStock;
            if (produitFromDb.CategorieId != produit.CategorieId)
                produitFromDb.CategorieId = produit.CategorieId;
            if (produitFromDb.ImagePath != produit.ImagePath)
                produitFromDb.ImagePath = produit.ImagePath;

            return _dbContext.SaveChanges() > 0;
        }
    }
}

// return _dbContext.Clients.Include(c => c.Reservations).ThenInclude(r => r.Chambre).FirstOrDefault(predicate);