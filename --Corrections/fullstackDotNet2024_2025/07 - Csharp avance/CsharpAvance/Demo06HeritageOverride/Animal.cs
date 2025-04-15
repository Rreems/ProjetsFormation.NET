using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo06HeritageOverride
{
    internal abstract class Animal
    {
        public string Nom { get; set; }
        public bool EstVivant { get; set; }
        public Animal(string nom, bool estVivant)
        {
            Nom = nom;
            EstVivant = estVivant;
        }
        public abstract void SeDeplacer(); // tout les animaux se déplacent ! COMMENT ? je ne sais pas...  => caractéristique commune 
        public abstract void Respirer(); // juste la signature sans le bloc de code
        public virtual void Crier()
        {
            Console.WriteLine("L'animal crie");
        }
        public virtual void Crier(string cri)
        {
            Console.WriteLine("L'animal crie " + cri);
        }

        public override string ToString()
        {
            return this.GetType().Name
            + $" : Nom = {Nom}"
            + $", EstVivant = {EstVivant}";
        }
    }
}
