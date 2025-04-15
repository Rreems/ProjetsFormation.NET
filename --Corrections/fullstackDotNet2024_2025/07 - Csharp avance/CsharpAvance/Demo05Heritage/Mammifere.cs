using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo05Heritage
{
    internal class Mammifere : Animal
    {
        public string Genre { get; set; }
        public Mammifere(string? nom, bool estVivant, string genre) : base(nom, estVivant)
        {
            Genre = genre;
            //base.Crier();
            //Crier();
        }

        //public void Respirer()// ici on vient MASQUER la méthode Respirer de Animal => pas recommandé
        public new void Respirer()// on fait la même chose mais on explique que c'est intentionnel  => toujours pas recommandé
        {
            Console.WriteLine("Le mammifere respire");
        }
    }
}
