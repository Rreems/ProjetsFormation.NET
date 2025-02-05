//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Exo01EFCore.Data;
//using Exo02EFCore.Models;
//using Microsoft.EntityFrameworkCore.ChangeTracking;

//namespace Exo02EFCore.Repositories
//{
//    internal class ReservationChambreRepository : IRepository<ReservationChambre, int>
//    {

//        private readonly AppDbContext _db;

//        public ReservationChambreRepository(AppDbContext context)
//        {
//            _db = context;
//        }

//        public ReservationChambre? Add(ReservationChambre entity)
//        {
//            EntityEntry<ReservationChambre> reservationchambre = _db.Add(entity);
//            _db.SaveChanges();
//            return reservationchambre.Entity;
//        }

//        public bool Delete(int id)
//        {
//            var ReservationChambre = GetById(id);
//            if (ReservationChambre is null)
//            {
//                return false;
//            }
//            _db.ReservationChambres.Remove(ReservationChambre);

//            return _db.SaveChanges() == 1;
//        }

//        public ReservationChambre? Get(Func<ReservationChambre, bool> predicate)
//        {
//            return _db.ReservationChambres
//                    .FirstOrDefault(predicate);
//        }

//        public IEnumerable<ReservationChambre> GetAll()
//        {
//            return _db.ReservationChambres;
//        }

//        public IEnumerable<ReservationChambre> GetAll(Func<ReservationChambre, bool> predicate)
//        {
//            return _db.ReservationChambres.Where(predicate);
//        }

//        public ReservationChambre? GetById(int id)
//        {
//            return _db.ReservationChambres
//                    .FirstOrDefault(c => c.Id == id);
//        }

//        public ReservationChambre? Update(int id, ReservationChambre reservationchambre)
//        {
//            var ReservationChambreFromDb = GetById(id);

//            if (ReservationChambreFromDb is null)
//            {
//                return null;
//            }

//            // Vérifications si chaque champ est modifié -> ne met à jour que les nécessaires
//            if (ReservationChambreFromDb.Id != reservationchambre.Id)
//            {
//                ReservationChambreFromDb.Id = reservationchambre.Id;
//            }

//            _db.SaveChanges();
//            return ReservationChambreFromDb;
//        }
//    }
//}
