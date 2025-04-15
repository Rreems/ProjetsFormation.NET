using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceVols.Classes
{
    internal class Ville
    {
        public string Nom { get; set; }
        public List<VolDirect> VolsDeparts { get; set; } = new List<VolDirect>();
        public List<VolDirect> VolsArrivees { get; set; } = new List<VolDirect>();
        public Ville(string nom) 
        {
            Nom = nom;
        }
        public override string ToString()
        {
            return Nom;
        }
    }
}
