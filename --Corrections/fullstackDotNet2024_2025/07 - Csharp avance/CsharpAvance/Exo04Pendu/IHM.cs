using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice04Pendu
{
    internal static class IHM
    {
        private static Pendu _pendu; // la partie en cours pour notre IHM

        public static void Start()
        {
            Console.WriteLine("=== Paramètres de partie ===\n");
            Console.Write("Voulez-vous un nombre d'essais spécifique (10 par défaut) ? Y/n ");
            // possible de faire un contrôle de saisie
            if (Console.ReadLine().ToLower() == "y")
            {
                Console.Write("Combien voulez-vous d'essais ? ");
                // possible de faire un contrôle de saisie
                int nbEssais = int.Parse(Console.ReadLine());
                _pendu = new Pendu(nbEssais);
            }
            else
                _pendu = new Pendu();

            Console.WriteLine("Jeu du pendu généré ! Nombre d'essais : " + _pendu.NbEssaisTotal);

            bool win;
            do
            {
                win = JouerUnTour();
                Console.WriteLine("--------------------------------");
            } while (!win && _pendu.NbEssaisRestants != 0);

            Console.WriteLine(win ? "C'est Gagné, bravo !!!" : "C'est Perdu, dommage...");
        }

        private static bool JouerUnTour() // cette fonction permet de jouer UN tour, elle renvoie true si l'utilisateur a gagné et que la partie est finie
        {
            Console.WriteLine($"Le mot à trouver : {_pendu.Masque}");
            Console.WriteLine($"Il vous reste {_pendu.NbEssaisRestants} essais");

            Console.Write("Veuillez saisir une lettre : ");
            // possible de faire un contrôle de saisie (un seul caractère compris entre a et z)
            char lettre = Console.ReadLine().ToLower()[0]; // premier caractère de la saisie

            string messageTestChar = _pendu.TestChar(lettre);
            Console.WriteLine(messageTestChar);

            _pendu.GenererMasque();

            //affichage pendu en ascii art
            AffichagePendu(_pendu.NbEssaisTotal - _pendu.NbEssaisRestants, _pendu.NbEssaisTotal);

            return _pendu.TestWin();
        }

        public static void AffichagePendu(int noEssai, int nbEssaiMax)
        {
            string[,] penduAscii = {
                {"           ",
                "            ",
                "            ",
                "            ",
                "            ",
                "            ",
                "            "},
                {"           ",
                "            ",
                "            ",
                "            ",
                "            ",
                "            ",
                "--------    "},
                {"           ",
                "            ",
                "            ",
                " |          ",
                " |          ",
                " |          ",
                "--------    "},
                {"           ",
                " |          ",
                " |          ",
                " |          ",
                " |          ",
                " |          ",
                "--------    "},
                {"           ",
                " |/         ",
                " |          ",
                " |          ",
                " |          ",
                " |          ",
                "--------    "},
                {"_____      ",
                " |/         ",
                " |          ",
                " |          ",
                " |          ",
                " |          ",
                "--------    "},
                {"___________",
                " |/         ",
                " |          ",
                " |          ",
                " |          ",
                " |          ",
                "--------    "},
                {"___________ ",
                " |/       | ",
                " |          ",
                " |          ",
                " |          ",
                " |          ",
                "--------    "},
                {"___________ ",
                " |/       | ",
                " |        O ",
                " |       /|\\",
                " |       / \\",
                " |          ",
                "--------    "},
            };
            int noPendu = noEssai == 0 ? 0 : (noEssai * 8 / nbEssaiMax);
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine(penduAscii[noPendu, i]);
            }
        }
    }
}
