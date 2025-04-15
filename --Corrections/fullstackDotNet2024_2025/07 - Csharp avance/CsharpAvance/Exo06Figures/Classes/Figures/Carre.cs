using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo06Figures.Classes.Figures
{
    internal class Carre : Figure
    {

        /*         +cote
         *        A    B
         *  -cote
         *        D    C
         */

        public double Cote { get; set; }

        public Point B => new Point(A.X + Cote, A.Y);
        public Point C => new Point(A.X + Cote, A.Y - Cote);
        public Point D => new Point(A.X, A.Y - Cote);
         
        public Carre(double cote) : base()
        {
            Cote = cote;
        }

        public Carre(Point origin, double cote) : base(origin)
        {
        }

        public Carre(double x, double y, double cote) : base(x, y)
        {
        }
        public override string? ToString()
        {
            return $"Coordonnées du Carré ABCD (Coté = {Cote})" +
                "\nA = " + A +
                "\nB = " + B +
                "\nC = " + C +
                "\nD = " + D;
        }
    }
}
