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
    internal class ChambreRepository : IRepository<Chambre, int>
    {

        private readonly AppDbContext _db;

        public ChambreRepository(AppDbContext context)
        {
            _db = context;
        }

        public Chambre? Add(Chambre entity)
        {
            EntityEntry<Chambre> chambre = _db.Add(entity);
            _db.SaveChanges();
            return chambre.Entity;
        }

        public bool Delete(int id)
        {
            var Chambre = GetById(id);
            if (Chambre is null)
            {
                return false;
            }
            _db.Chambres.Remove(Chambre);

            return _db.SaveChanges() == 1;
        }

        public Chambre? Get(Func<Chambre, bool> predicate)
        {
            return _db.Chambres
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

        public Chambre? GetById(int id)
        {
            return _db.Chambres
                    .FirstOrDefault(c => c.NumeroId == id);
        }

        public Chambre? Update(int id, Chambre chambre)
        {
            var ChambreFromDb = GetById(id);

            if (ChambreFromDb is null)
            {
                return null;
            }

            // Vérifications si chaque champ est modifié -> ne met à jour que les nécessaires
            if (ChambreFromDb.NumeroId != chambre.NumeroId)
            {
                ChambreFromDb.NumeroId = chambre.NumeroId;
            }
            if (ChambreFromDb.Statut != chambre.Statut)
            {
                ChambreFromDb.Statut = chambre.Statut;
            }
            if (ChambreFromDb.NombreLits != chambre.NombreLits )
            {
                ChambreFromDb.NombreLits = chambre.NombreLits ;
            }
            if (ChambreFromDb.Tarif != chambre.Tarif )
            {
                ChambreFromDb.Tarif = chambre.Tarif ;
            }
            if (ChambreFromDb.HotelId != chambre.HotelId )
            {
                ChambreFromDb.HotelId = chambre.HotelId ;
            }

            _db.SaveChanges();
            return ChambreFromDb;
        }
    }
}
