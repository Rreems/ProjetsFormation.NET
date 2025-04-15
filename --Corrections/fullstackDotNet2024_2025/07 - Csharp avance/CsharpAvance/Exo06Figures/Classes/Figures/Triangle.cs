using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo06Figures.Classes.Figures
{
    internal class Triangle : Figure
    {
        /*
         *                   A          
         * 
         *      -hauteur
         * 
         *              C         B
         *           -base/2   +base/2
         */
        public double Base { get; set; }
        public double Hauteur { get; set; }

        public Point B => new Point(A.X + Base/2, A.Y - Hauteur);
        public Point C => new Point(A.X - Base / 2, A.Y - Hauteur);

        public Triangle(double baseTr, double hauteur) : base()
        {
            Base = baseTr;
            Hauteur = hauteur;
        }

        public Triangle(Point origin, double baseTr, double hauteur) : base(origin)
        {
            Base = baseTr;
            Hauteur = hauteur;
        }

        public Triangle(double x, double y, double baseTr, double hauteur) : base(x, y)
        {
            Base = baseTr;
            Hauteur = hauteur;
        }

        public override string ToString()
        {
            return $"Coordonnées du Triangle ABC (Base = {Base}, Hauteur = {Hauteur})" +
                "\nA = " + A +
                "\nB = " + B +
                "\nC = " + C;
        }
    }
}
