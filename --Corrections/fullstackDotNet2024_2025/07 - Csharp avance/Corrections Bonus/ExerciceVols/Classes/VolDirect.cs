using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceVols.Classes
{
    internal class VolDirect
    {
        private int _heure;
        private static int _nbVols = 0;

        public VolDirect(Ville depart, Ville arrivee, Jour jour, int heure)
        {
            Id = ++_nbVols;
            Depart = depart;
            Depart.VolsDeparts.Add(this);
            Arrivee = arrivee;
            Arrivee.VolsArrivees.Add(this);
            Jour = jour;
            Heure = heure;
        }

        public int Id { get; set; }
        public Ville Depart { get; private set; }
        public Ville Arrivee { get; private set; }
        public Jour Jour { get; set; }
        public int Heure
        {
            get => _heure; 
            set
            {
                if (value < 0 || value > 23)
                    throw new ArgumentException("Heure Incorrecte");
                _heure = value;
            }
        }

        public override string ToString()
        {
            return $"Le vol n°{Id} part de {Depart} vers {Arrivee} le {Jour} à {Heure} heures";
        }

    }
    enum Jour
    {
        Lundi,
        Mardi,
        Mercredi,
        Jeudi,
        Vendredi,
        Samedi,
        Dimanche
    }
}
