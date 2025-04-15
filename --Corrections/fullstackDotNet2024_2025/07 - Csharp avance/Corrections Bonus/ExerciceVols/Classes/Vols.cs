using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceVols.Classes
{
    internal class VolsSemaine
    {
        private int _semaine;
        private int _annee;

        public List<VolDirect> VolDirects { get; set; }
        public int Semaine
        {
            get => _semaine; 
            set
            {
                if (value < 0 || value > 54)
                    throw new ArgumentException("Semaine Incorrecte");
                _semaine = value;
            }
        }
        public int Annee
        {
            get => _annee; 
            set
            {
                if (value < 2000)
                    throw new ArgumentException("Annee Incorrecte");
                _annee = value;
            }
        }

        public VolsSemaine(List<VolDirect> volDirects, int semaine, int annee)
        {
            VolDirects = volDirects;
            Semaine = semaine;
            Annee = annee;
        }

        public List<Ville> ListeSuccesseurs(Ville villeDepart)
        {
            return VolDirects
                .Where(vd => vd.Depart == villeDepart)
                .Select(vd => vd.Arrivee)
                .Distinct()
                .ToList();
        }
        public bool Appartient(Ville ville)
        {
            List<Ville> departs = VolDirects.Select(vd => vd.Depart).Distinct().ToList();
            List<Ville> arrivee = VolDirects.Select(vd => vd.Arrivee).Distinct().ToList();
            List<Ville> toutesVilles = departs.Concat(arrivee).Distinct().ToList();

            return toutesVilles.Contains(ville);
        }

        public override string ToString()
        {
            string str = $"Liste des vols de la semaine {Semaine} de l'année {Annee} :";

            // tri par jour et heures
            List<VolDirect> volDirectsOrdonnes = VolDirects.OrderBy(vd => vd.Jour).ThenBy(vd => vd.Heure).ToList();

            foreach (var vd in volDirectsOrdonnes)
                str += "\n" + vd;

            return str.TrimEnd();
        }
    }
}
