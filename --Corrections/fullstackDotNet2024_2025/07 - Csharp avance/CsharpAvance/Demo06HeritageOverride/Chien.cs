using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo06HeritageOverride
{
    internal class Chien : Mammifere
    {
        public string? Race { get; set; }
        public Chien(string nom, bool estVivant, string genre, string race) : base(nom, estVivant, genre)
        {
            Race = race;
        }

        public Chien() : base(true)
        {
            Race = "Chihuahua";
        }

        public sealed override void SeDeplacer() // sealed => si on hérite de chien, cette méthode ne pourra pas être override
        {
            Console.WriteLine("Le chien court sur ses 4 pattes");
        }

        public override void Crier()
        {
            //base.Crier();
            Console.WriteLine("Le chien aboie !");
        }
    }
}
