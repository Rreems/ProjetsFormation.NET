using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Correction02Hotel.Data;
using Correction02Hotel.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Correction02Hotel.Repositories;

internal class ReservationChambreRepository : IRepository<ReservationChambre, (int ReservationId, int ChambreNumero)>
{
    private readonly ApplicationDbContext _db;

    public ReservationChambreRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public ReservationChambre? Add(ReservationChambre reservationchambre)
    {
        EntityEntry<ReservationChambre> reservationchambreEntity = _db.Add(reservationchambre);
        _db.SaveChanges();

        return reservationchambreEntity.Entity;
    }

    public ReservationChambre? GetById((int ReservationId, int ChambreNumero) id)
    {
        return _db.ReservationChambres
                  .FirstOrDefault(e => e.ReservationId == id.ReservationId && e.ChambreNumero == id.ChambreNumero);
                  //.Find(id.ChambreNumero, id.ReservationId); // attention à l'ordre
    }

    public ReservationChambre? Get(Func<ReservationChambre, bool> predicate)
    {
        return _db.ReservationChambres
                  .FirstOrDefault(predicate);
    }

    public IEnumerable<ReservationChambre> GetAll()
    {
        return _db.ReservationChambres;
    }

    public IEnumerable<ReservationChambre> GetAll(Func<ReservationChambre, bool> predicate)
    {
        return _db.ReservationChambres.Where(predicate);
    }

    public ReservationChambre? Update((int ReservationId, int ChambreNumero) id, ReservationChambre reservationchambre)
    {
        var reservationchambreFromDb = GetById(id);

        if (reservationchambreFromDb is null)
            return null;

        // pas de champs à part la PK composite
        // => rien à modifier

        return reservationchambreFromDb;
    }

    public bool Delete((int ReservationId, int ChambreNumero) id)
    {
        var reservationchambre = GetById(id);

        if (reservationchambre is null)
            return false;

        _db.ReservationChambres.Remove(reservationchambre);

        return _db.SaveChanges() == 1;
    }
}
