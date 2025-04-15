using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exo06Figures.Interfaces;

namespace Exo06Figures.Classes
{
    internal class Point : IDeplacable
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x = 0, double y = 0)
        {
            X = x;
            Y = y;
        }

        public override string? ToString()
        {
            return $"{X};{Y}";
        }

        public void Deplacement(double x, double y)
        {
            X += x;
            Y += y;
        }
    }
}
