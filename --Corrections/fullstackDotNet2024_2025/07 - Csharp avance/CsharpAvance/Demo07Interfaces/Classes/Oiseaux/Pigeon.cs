using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo07Interfaces.Interfaces;

namespace Demo07Interfaces.Classes.Oiseaux
{
    internal class Pigeon : Oiseau, IVolant
    {
        public void Atterrir()
        {
            Console.WriteLine("Le Pigeon atterrit.");
        }

        public void SEnvoler()
        {
            Console.WriteLine("Le Pigeon s'envole.");
        }
    }
}
