using Exo04.Models;
using Exo04.Repository;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Exo04.Data;


public class MarsupilamiRepository : IRepository<Marsupilami, int>
{

    private readonly AppDbContext _db;

    public MarsupilamiRepository(AppDbContext context)
    {
        _db = context;
    }

    public Marsupilami Add(Marsupilami entity)
    {
        EntityEntry<Marsupilami> client = _db.Add(entity);
        _db.SaveChanges();
        return client.Entity;
    }

    public IEnumerable<Marsupilami> GetAll()
    {
        return _db.Marsupilamis;
    }

    public Marsupilami? GetById(int id)
    {
        return _db.Marsupilamis
                            //.Include(p => p.PersoTags) -> récup de chaque relation / liste des objets relations 
                            // .ThenInclude ( " " " )  -> include des listes des objets du 1e Include
                            .FirstOrDefault(c => c.Id == id);

        //return _db.Marsupilamis.Find(id);   // Existe aussi, sans LINQ
    }


    public Marsupilami? Get(Func<Marsupilami, bool> predicate)
    {
        return _db.Marsupilamis
                            .FirstOrDefault(predicate);
    }

    public IEnumerable<Marsupilami> GetAll(Func<Marsupilami, bool> predicate)
    {
        return _db.Marsupilamis.Where(predicate);
    }

    //public Marsupilami GetAll(Func<Marsupilami, bool> predicate)
    //{
    //    return _db.Marsupilamis.Where(predicate);
    //}

    public Marsupilami? Update(int id, Marsupilami Marsupilami)
    {
        var MarsupilamiFromDb = GetById(id);

        if (MarsupilamiFromDb is null)
        {
            return null;
        }

        // Vérifications si chaque champ est modifié -> ne met à jour que les nécessaires
        if (MarsupilamiFromDb.Id != Marsupilami.Id)
        {
            MarsupilamiFromDb.Id = Marsupilami.Id;
        }
        if (MarsupilamiFromDb.PetitNom != Marsupilami.PetitNom)
        {
            MarsupilamiFromDb.PetitNom = Marsupilami.PetitNom;
        }
        if (MarsupilamiFromDb.Couleur != Marsupilami.Couleur)
        {
            MarsupilamiFromDb.Couleur = Marsupilami.Couleur;
        }

        _db.SaveChanges();
        return MarsupilamiFromDb;
    }


    public void Delete(Marsupilami entity) // Obsolete
    {
        _db.Marsupilamis.Remove(entity);
    }

    public bool Delete(int id)
    {
        var Marsupilami = GetById(id);
        if (Marsupilami is null)
        {
            return false;
        }
        _db.Marsupilamis.Remove(Marsupilami);

        return _db.SaveChanges() == 1;
    }

    public void Save()
    {
        _db.SaveChanges();
    }
}
