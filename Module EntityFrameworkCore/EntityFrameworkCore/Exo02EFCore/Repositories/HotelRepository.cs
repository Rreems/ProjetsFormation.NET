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
    internal class HotelRepository : IRepository<Hotel, int>
    {

        private readonly AppDbContext _db;

        public HotelRepository(AppDbContext context)
        {
            _db = context;
        }

        public Hotel? Add(Hotel entity)
        {
            EntityEntry<Hotel> hotel = _db.Add(entity);
            _db.SaveChanges();
            return hotel.Entity;
        }

        public bool Delete(int id)
        {
            var Hotel = GetById(id);
            if (Hotel is null)
            {
                return false;
            }
            _db.Hotels.Remove(Hotel);

            return _db.SaveChanges() == 1;
        }

        public Hotel? Get(Func<Hotel, bool> predicate)
        {
            return _db.Hotels
                    .FirstOrDefault(predicate);
        }

        public IEnumerable<Hotel> GetAll()
        {
            return _db.Hotels;
        }

        public IEnumerable<Hotel> GetAll(Func<Hotel, bool> predicate)
        {
            return _db.Hotels.Where(predicate);
        }

        public Hotel? GetById(int id)
        {
            return _db.Hotels
                    .FirstOrDefault(c => c.Id == id);
        }

        public Hotel? Update(int id, Hotel hotel)
        {
            var HotelFromDb = GetById(id);

            if (HotelFromDb is null)
            {
                return null;
            }

            // Vérifications si chaque champ est modifié -> ne met à jour que les nécessaires
            if (HotelFromDb.Id != hotel.Id)
            {
                HotelFromDb.Id = hotel.Id;
            }

            _db.SaveChanges();
            return HotelFromDb;
        }
    }
}
