using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo02Dao.Classes
{
    internal class Maitre
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public List<Chien> Chiens { get; set; } = new();

        public Maitre(int id, string nom, string prenom)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
        }

        public Maitre(string nom, string prenom)
        {
            Nom = nom;
            Prenom = prenom;
        }

        public override string ToString()
        {
            return $"id: {Id}, identité: {Prenom} {Nom.ToUpper()}";
        }
    }
}
