using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exo01EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Exo01EFCore.Data;

public class PersonnageRepository : IRepository<Personnage> //  IRepository<Personnage, int>
{
    private readonly AppDbContext _db;

    public PersonnageRepository(AppDbContext context)
    {
        _db = context;
    }

    public void Add(Personnage entity)
    {
        _db.Add(entity);
        _db.SaveChanges();
    }

    public IEnumerable<Personnage> GetAll()
    {
        return _db.Personnages;
    }

    public Personnage? GetById(int id)
    {
        return _db.Personnages
                            //.Include(p => p.PersoTags) -> récup de chaque relation / liste des objets relations 
                            // .ThenInclude ( " " " )  -> include des listes des objets du 1e Include
                            .FirstOrDefault( p => p.Id == id);

        //return _db.Personnages.Find(id);   // Existe aussi, sans LINQ
    }

    public Personnage? Get(Func<Personnage, bool> predicate) // ex prédicat  p => p.Armor.COntains(15)
    {
        return _db.Personnages.FirstOrDefault(predicate);
    }

    //public Personnage GetAll(Func<Personnage, bool> predicate)
    //{
    //    return _db.Personnages.Where(predicate);
    //}

    public Personnage? Update(int id, Personnage personnage)
    {
        var personnageFromDb = GetById(id);

        if (personnageFromDb != null)
        {
            return null;
        }

        // Vérifications si chaque champ est modifié -> ne met à jour que les nécessaires
        if (personnageFromDb.Id != personnage.Id) {
            personnageFromDb.Id = personnage.Id;
        }
        if (personnageFromDb.Pseudo != personnage.Pseudo) {
            personnageFromDb.Pseudo = personnage.Pseudo;
        }
        if (personnageFromDb.PointsDeVie != personnage.PointsDeVie) {
            personnageFromDb.PointsDeVie = personnage.PointsDeVie;
        }
        if (personnageFromDb.Armure != personnage.Armure) {
            personnageFromDb.Armure = personnage.Armure;
        }
        if (personnageFromDb.Degats != personnage.Degats)
        {
            personnageFromDb.Degats = personnage.Degats;
        }
        
        _db.SaveChanges();
        return personnageFromDb;
    }


    public void Delete(Personnage entity) // Obsolete
    {
        _db.Personnages.Remove(entity);
    }

    public bool Delete(int id)
    {
        var personnage = GetById(id);
        if (personnage is null)
        {
            return false;
        }
        _db.Personnages.Remove(personnage);

        return _db.SaveChanges() == 1;
    }

    public void Save()
    {
        _db.SaveChanges();
    }
}
