using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo03Polymorphisme1
{
    internal class Dinosaur
    {
        private static int _nombreDeDinos = 0;

        public string Nom { get; set; } = "Dino par défaut";
        public int Age { get; set; } = 0;
        public string Espece { get; set; } = "Espèce par défaut";
        public int NbPates { get; set; } = 4;
        public double Poids { get; set; } = 12;
        public bool PeutVoler { get; set; } = false;
        public string RegimeAlimentaire { get; set; } = "Omnivore";

        public static int NombreDeDinos { get => _nombreDeDinos; }

        public Dinosaur()
        {
            _nombreDeDinos++;
        }

        // 2e forme du constructeur
        public Dinosaur(string nom, int age, string espece, bool peutVoler) : this()
        {
            Nom = nom;
            Age = age;
            Espece = espece;
            PeutVoler = peutVoler;
        }

        // 3e forme => appellée constructeur de recopie
        public Dinosaur(Dinosaur dinoACopier) : this()
        {
            Nom = dinoACopier.Nom;
            Age = dinoACopier.Age;
            Espece = dinoACopier.Espece;
            PeutVoler = dinoACopier.PeutVoler;
        }

        public void SEnvoler()
        {
            if (PeutVoler)
            {
                Console.WriteLine($"Le dinosaur {Nom} s'envole majestueusement !");
                return;
            }

            Console.WriteLine($"Le dinosaur {Nom} saute et s'écrase sur le sol lamentablement...");
        }

        public override string ToString()
        {
            return $"Le Dinosaur {Nom} est agé de {Age} ans et est de l'espèce {Espece}";
        }
    }
}
