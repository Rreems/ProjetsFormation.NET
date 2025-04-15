using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Correction01Personnage.UI;

internal static class MainUI
{
    private static void AfficherTitre()
    {
        Console.WriteLine(@"
  ____                     _   _ _   _                  
 |  _ \ ___ _ __ ___  ___ | \ | | \ | | __ _  __ _  ___ 
 | |_) / _ \ '__/ __|/ _ \|  \| |  \| |/ _` |/ _` |/ _ \
 |  __/  __/ |  \__ \ (_) | |\  | |\  | (_| | (_| |  __/
 |_|   \___|_|  |___/\___/|_| \_|_| \_|\__,_|\__, |\___|
                                             |___/ 
");
    }
    private static void AfficherMenu()
    {
        Console.WriteLine("1. Créer un personnage");
        Console.WriteLine("2. Mettre à jour un personnage");
        Console.WriteLine("3. Afficher tous les personnages");
        Console.WriteLine("4. Taper un personnage");
        Console.WriteLine("5. Afficher les personnages ayant des PVs supérieur à la moyenne");
        Console.WriteLine("0. Quitter");
    }

    public static void Start()
    {
        AfficherTitre();

        while (true)
        {
            AfficherMenu();
            string choix = Console.ReadLine()!;

            switch (choix)
            {
                case "1":
                    UIActions.CreateChar();
                    break;
                case "2":
                    UIActions.UpdateChar();
                    break;
                case "3":
                    UIActions.DisplayChars();
                    break;
                case "4":
                    UIActions.HitChar();
                    break;
                case "5":
                    UIActions.DisplayHeathOverAvg();
                    break;
                case "0":
                    return;
                default:
                    break;
            }
        }
    }
}