using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo04Polymorphisme2
{
    internal class Additionneur
    {
        public static int Additionner(int a, int b)
        {
            return a + b;
        }
        public static int Additionner(double a, double b)
        {
            return (int) (a + b);
        }
        public static string Additionner(string a, string b)
        {
            return a + b; // concaténation
        }
    }
}
