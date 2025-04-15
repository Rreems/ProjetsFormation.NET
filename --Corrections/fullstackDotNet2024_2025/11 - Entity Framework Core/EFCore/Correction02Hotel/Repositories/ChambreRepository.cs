using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Correction02Hotel.Data;
using Correction02Hotel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Correction02Hotel.Repositories;

internal class ChambreRepository : IRepository<Chambre, int>
{
    private readonly ApplicationDbContext _db;

    public ChambreRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public Chambre? Add(Chambre chambre)
    {
        EntityEntry<Chambre> chambreEntity = _db.Add(chambre);
        _db.SaveChanges();

        return chambreEntity.Entity;
    }

    public Chambre? GetById(int numero)
    {
        return _db.Chambres
                  .Include(c => c.Reservations)
                  //.Include(c => c.ReservationChambres)
                  .FirstOrDefault(e => e.Numero == numero);
    }

    public Chambre? Get(Func<Chambre, bool> predicate)
    {
        return _db.Chambres
                  .Include(c => c.Reservations)
                  //.Include(c => c.ReservationChambres)
                  .FirstOrDefault(predicate);
    }

    public IEnumerable<Chambre> GetAll()
    {
        return _db.Chambres;
    }

    public IEnumerable<Chambre> GetAll(Func<Chambre, bool> predicate)
    {
        return _db.Chambres.Where(predicate);
    }

    public Chambre? Update(int numero, Chambre chambre)
    {
        var chambreFromDb = GetById(numero);

        if (chambreFromDb is null)
            return null;

        if (chambreFromDb.Statut  == chambre.Statut)
            chambreFromDb.Statut = chambre.Statut;
        if (chambreFromDb.NombreLits == chambre.NombreLits)
            chambreFromDb.NombreLits= chambre.NombreLits;
        if (chambreFromDb.Tarif == chambre.Tarif)
            chambreFromDb.Tarif= chambre.Tarif;

        return chambreFromDb;
    }

    public bool Delete(int numero)
    {
        var chambre = GetById(numero);

        if (chambre is null)
            return false;

        _db.Chambres.Remove(chambre);

        return _db.SaveChanges() == 1;
    }
}
