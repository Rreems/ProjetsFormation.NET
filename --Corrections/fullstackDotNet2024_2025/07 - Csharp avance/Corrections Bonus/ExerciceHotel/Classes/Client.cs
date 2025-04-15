using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceHotel.Classes
{
    public class Client
    {
        private static int _compteur = 0;
        private int _id;
        private string _nom;
        private string _prenom;
        private string _telephone;

        public string Nom { get => _nom; set => _nom = value; }
        public string Prenom { get => _prenom; set => _prenom = value; }
        public string Telephone { get => _telephone; set => _telephone = value; }

        public int Id { get => _id; }
        public Client(string nom, string prenom, string telephone)
        {
            _id = ++_compteur;
            Nom = nom;
            Prenom = prenom;
            Telephone = telephone;
        }
    }
}
