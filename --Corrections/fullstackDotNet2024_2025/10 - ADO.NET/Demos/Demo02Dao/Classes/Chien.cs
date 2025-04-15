using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo02Dao.Classes
{
    internal class Chien
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public DateTime DateNaissance { get; set; }
        public Maitre? Maitre { get; set; }

        public Chien(int id, string nom, DateTime dateNaissance)
        {
            Id = id;
            Nom = nom;
            DateNaissance = dateNaissance;
        }

        public Chien(string nom, DateTime dateNaissance)
        {
            Nom = nom;
            DateNaissance = dateNaissance;
        }

        public override string ToString()
        {
            return $"id: {Id}, nom: {Nom} maitre: {(Maitre is null ? "aucun" : Maitre )}";
        }
    }
}
