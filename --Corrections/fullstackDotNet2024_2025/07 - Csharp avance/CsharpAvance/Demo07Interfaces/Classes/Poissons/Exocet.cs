using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo07Interfaces.Interfaces;

namespace Demo07Interfaces.Classes.Poissons
{
    internal class Exocet : Poisson, IVolant
    {

        public void Atterrir()
        {
            Console.WriteLine("L'exocet retombe dans l'eau.");
            Nager();
        }

        public override void Nager()
        {
            Console.WriteLine("L'exocet nage");
        }

        public void SEnvoler()
        {
            Console.WriteLine("L'exocet s'envole en sortant de l'eau.");
        }
    }
}
