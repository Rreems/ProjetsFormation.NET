using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo07Interfaces.Interfaces;

namespace Demo07Interfaces.Classes.Mammiferes
{
    internal class ChauveSouris : Mammifere, IVolant
    {
        public void Atterrir()
        {
            Console.WriteLine("La chauve-souris atterrit sur le plafond.");
        }

        public void SEnvoler()
        {
            Console.WriteLine("La chauve-souris s'envole vers le bas.");
        }
    }
}
