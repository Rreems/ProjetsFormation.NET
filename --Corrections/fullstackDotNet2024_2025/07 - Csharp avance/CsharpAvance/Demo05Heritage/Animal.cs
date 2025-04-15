using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo05Heritage;

internal class Animal
{
    public string? Nom { get; set; }
    public bool EstVivant { get; set; }

    public Animal(string? nom, bool estVivant)
    {
        Nom = nom;
        EstVivant = estVivant;
    }

    public void SeDeplacer()
    {
        Console.WriteLine("L'animal se déplace");
    }
    public void Respirer()
    {
        Console.WriteLine("L'animal respire");
    }
    public void Crier()
    {
        Console.WriteLine("L'animal crie");
    }
}
