using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceHotel.Classes
{
    public class Chambre
    {
        private static int _compteur = 0;
        private int _numero;
        private decimal _tarif;
        private int _nb_personne;

        public int Numero { get => _numero; set => _numero = value; }
        public decimal Tarif { get => _tarif; set => _tarif = value; }
        public int Nb_personne { get => _nb_personne; set => _nb_personne = value; }

        public StatutChambre Statut { get; set; }

        public Chambre(decimal tarif, int nb)
        {
            _numero = ++_compteur;
            Tarif = tarif;
            Nb_personne = nb;
            Statut = StatutChambre.Libre;
        }

        

    }
    public enum StatutChambre // possible de le mettre dans un fichier à part
    {
        Libre,
        Occupe,
        Nettoyage
    }


}
