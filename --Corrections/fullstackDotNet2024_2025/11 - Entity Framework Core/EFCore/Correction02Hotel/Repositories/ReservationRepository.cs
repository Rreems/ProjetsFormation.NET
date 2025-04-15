using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Correction02Hotel.Data;
using Correction02Hotel.Models;
using Correction02Hotel.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Correction02Hotel.Repositories;

internal class ReservationRepository : IRepository<Reservation, int>
{
    private readonly ApplicationDbContext _db;

    public ReservationRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public Reservation? Add(Reservation reservation)
    {
        EntityEntry<Reservation> reservationEntity = _db.Add(reservation);
        _db.SaveChanges();

        return reservationEntity.Entity;
    }

    public Reservation? GetById(int id)
    {
        return _db.Reservations
                  .Include(r => r.Chambres)
                  //.Include(r => r.ReservationChambres)
                  .FirstOrDefault(e => e.Id == id);
    }

    public Reservation? Get(Func<Reservation, bool> predicate)
    {
        return _db.Reservations
                  .Include(r => r.Chambres)
                  //.Include(r => r.ReservationChambres)
                  .FirstOrDefault(predicate);
    }

    public IEnumerable<Reservation> GetAll()
    {
        return _db.Reservations;
    }

    public IEnumerable<Reservation> GetAll(Func<Reservation, bool> predicate)
    {
        return _db.Reservations.Where(predicate);
    }

    public Reservation? Update(int id, Reservation reservation)
    {
        var reservationFromDb = GetById(id);

        if (reservationFromDb is null)
            return null;

        if(reservationFromDb.StatutReservation == reservation.StatutReservation)
            reservationFromDb.StatutReservation = reservation.StatutReservation;
        if (reservationFromDb.ClientIdentifiant == reservation.ClientIdentifiant)
            reservationFromDb.ClientIdentifiant = reservation.ClientIdentifiant;

        return reservationFromDb;
    }

    public bool Delete(int id)
    {
        var reservation = GetById(id);

        if (reservation is null)
            return false;

        _db.Reservations.Remove(reservation);

        return _db.SaveChanges() == 1;
    }
}
