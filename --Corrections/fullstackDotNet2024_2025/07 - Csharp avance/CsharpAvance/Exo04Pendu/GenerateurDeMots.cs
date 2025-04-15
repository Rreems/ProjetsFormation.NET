using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice04Pendu
{
    internal static class GenerateurDeMots
    {
        private static readonly string[] _listeDeMots =
        {
            "poubelle",
            "friture",
            "shampoing",
            "chaussettes",
            "parapluie",
            "canard",
            "moufette",
            "pretendant",
            "cameleon",
            "brique",
            "ciseaux",
            "crabe",
            "brosse",
            "dentifrice",
            "niche",
            "soupe",
            "crepiere",
            "ordinateur",
            "souffleuse",
            "filiere",
            "allumettes",
            "grattoir",
            "xylophone",
            "guitare",
            "feuille",
            "guignol",
            "jetable",
            "figaro",
            "institution",
            "karaoke",
            "toilette",
            "chansons",
            "kimono",
            "trouillard",
            "chipolata",
            "questionnement",
            "partir",
            "chipoter",
            "jeton",
            "fournitures",
            "wazabi"
        };

        public static string GenererMot()
        {
            return _listeDeMots[new Random().Next(_listeDeMots.Length)];

            // équivalent :
            //Random random = new Random();
            //int nbAleatoire = random.Next(_listeDeMots.Length);
            //return _listeDeMots[nbAleatoire];
        }
    }
}
