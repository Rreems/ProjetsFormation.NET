using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo08Generiques.Tourneviss.Visses
{
    public class VisPlate : Vis
    {
        public VisPlate(string taille) : base(taille) { }
        public override void Serrer()
        {
            Console.WriteLine("Serrer la vis plate de taille " + taille);
        }
        public override void Desserrer()
        {
            Console.WriteLine("Desserrer la vis plate de taille " + taille);
        }
    }
}
