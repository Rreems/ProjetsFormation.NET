using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo07Interfaces.Interfaces;

namespace Demo07Interfaces.Classes.Poissons
{
    internal abstract class Poisson : Animal, INageant
    {
        public abstract void Nager();
        //public virtual void Nager()
        //{
        //    Console.WriteLine($"Le/la {GetType().Name} nage");
        //}
    }
}
