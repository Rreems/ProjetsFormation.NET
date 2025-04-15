using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo07Interfaces.Interfaces;

namespace Demo07Interfaces.Classes.Mammiferes
{
    internal class Baleine : Mammifere, INageant
    {
        public void Nager()
        {
            Console.WriteLine("La baleine nage");
        }
    }
}
