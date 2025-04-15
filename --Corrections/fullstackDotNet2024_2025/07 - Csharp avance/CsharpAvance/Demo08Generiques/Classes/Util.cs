using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo08Generiques.Classes
{
    public class Util
    {
        public static void ImprimerTableau<T>(T[] tableau)
        {
            foreach (T élément in tableau)
            {
                Console.Write(élément + " ");
            }
            Console.WriteLine();
        }

        public static void ImprimerNombres<T>(T[] tableau) where T : struct, IComparable
        {
            foreach (T nombre in tableau)
            {
                Console.Write(nombre + " ");
            }
            Console.WriteLine();
        }
    }
}
