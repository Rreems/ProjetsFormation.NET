using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo07Interfaces.Classes.Poissons
{
    internal class Perche : Poisson
    {
        public override void Nager()
        {
            Console.WriteLine("La perche nage");
        }
    }
}
