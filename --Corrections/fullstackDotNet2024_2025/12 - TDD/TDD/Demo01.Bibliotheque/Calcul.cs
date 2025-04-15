using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo01.Bibliotheque
{
    // /!\ ne pas oublier le public (au lie d'internal)
    // ET la références de projet DEPUIS Tests VERS Bibliothèque
    public class Calcul
    {
        public double Addition(double x, double y)
        {
            return x + y;
        }

        public double Division(double x, double y)
        {
            if (y != 0)
                return x / y;

            throw new DivideByZeroException("Division par 0 impossible");
        }
    }
}
