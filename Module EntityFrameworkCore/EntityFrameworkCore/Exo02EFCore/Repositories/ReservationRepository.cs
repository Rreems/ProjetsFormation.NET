using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exo01EFCore.Data;
using Exo02EFCore.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Exo02EFCore.Repositories
{
    internal class ReservationRepository : IRepository<Reservation, int>
    {

        private readonly AppDbContext _db;

        public ReservationRepository(AppDbContext context)
        {
            _db = context;
        }

        public Reservation? Add(Reservation entity)
        {
            EntityEntry<Reservation> reservation = _db.Add(entity);
            _db.SaveChanges();
            return reservation.Entity;
        }

        public bool Delete(int id)
        {
            var Reservation = GetById(id);
            if (Reservation is null)
            {
                return false;
            }
            _db.Reservations.Remove(Reservation);

            return _db.SaveChanges() == 1;
        }

        public Reservation? Get(Func<Reservation, bool> predicate)
        {
            return _db.Reservations
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

        public Reservation? GetById(int id)
        {
            return _db.Reservations
                    .FirstOrDefault(c => c.Id == id);
        }

        public Reservation? Update(int id, Reservation reservation)
        {
            var ReservationFromDb = GetById(id);

            if (ReservationFromDb is null)
            {
                return null;
            }

            // Vérifications si chaque champ est modifié -> ne met à jour que les nécessaires
            if (ReservationFromDb.Id != reservation.Id)
            {
                ReservationFromDb.Id = reservation.Id;
            }

            if (ReservationFromDb.Statut != reservation.Statut)
            {
                ReservationFromDb.Statut = reservation.Statut;
            }
            //if (ReservationFromDb.ListeChambres != reservation.ListeChambres)
            //{
            //    ReservationFromDb.ListeChambres = reservation.ListeChambres;
            //}
            if (ReservationFromDb.ClientId != reservation.ClientId)
            {
                ReservationFromDb.ClientId = reservation.ClientId;
            }
            if (ReservationFromDb.HotelId != reservation.HotelId)
            {
                ReservationFromDb.HotelId = reservation.HotelId;
            }

            _db.SaveChanges();
            return ReservationFromDb;
        }
    }
}
