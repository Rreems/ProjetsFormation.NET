using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
namespace Exo02EFCore.UI;


internal class MainUI
{
    //private readonly IRepository<Blog, int> blogRepository;
    //private readonly IRepository<Post, int> postRepository;

    //public MainUI(IRepository<Blog, int> blogRepository, // un CRUD de blogs, peut importe comment il est fait derrière
    //              IRepository<Post, int> postRepository)
    //{
    //    this.blogRepository = blogRepository;
    //    this.postRepository = postRepository;
    //}


    private static void AfficherMenu()
    {
        Console.WriteLine(@" 
 ██░ ██  ▒█████  ▄▄▄█████▓▓█████  ██▓         ██████ ▓█████  ███▄    █   ██████  ▄▄▄        ██████   ██████ 
▓██░ ██▒▒██▒  ██▒▓  ██▒ ▓▒▓█   ▀ ▓██▒       ▒██    ▒ ▓█   ▀  ██ ▀█   █ ▒██    ▒ ▒████▄    ▒██    ▒ ▒██    ▒ 
▒██▀▀██░▒██░  ██▒▒ ▓██░ ▒░▒███   ▒██░       ░ ▓██▄   ▒███   ▓██  ▀█ ██▒░ ▓██▄   ▒██  ▀█▄  ░ ▓██▄   ░ ▓██▄   
░▓█ ░██ ▒██   ██░░ ▓██▓ ░ ▒▓█  ▄ ▒██░         ▒   ██▒▒▓█  ▄ ▓██▒  ▐▌██▒  ▒   ██▒░██▄▄▄▄██   ▒   ██▒  ▒   ██▒
░▓█▒░██▓░ ████▓▒░  ▒██▒ ░ ░▒████▒░██████▒   ▒██████▒▒░▒████▒▒██░   ▓██░▒██████▒▒ ▓█   ▓██▒▒██████▒▒▒██████▒▒
 ▒ ░░▒░▒░ ▒░▒░▒░   ▒ ░░   ░░ ▒░ ░░ ▒░▓  ░   ▒ ▒▓▒ ▒ ░░░ ▒░ ░░ ▒░   ▒ ▒ ▒ ▒▓▒ ▒ ░ ▒▒   ▓▒█░▒ ▒▓▒ ▒ ░▒ ▒▓▒ ▒ ░
 ▒ ░▒░ ░  ░ ▒ ▒░     ░     ░ ░  ░░ ░ ▒  ░   ░ ░▒  ░ ░ ░ ░  ░░ ░░   ░ ▒░░ ░▒  ░ ░  ▒   ▒▒ ░░ ░▒  ░ ░░ ░▒  ░ ░
 ░  ░░ ░░ ░ ░ ▒    ░         ░     ░ ░      ░  ░  ░     ░      ░   ░ ░ ░  ░  ░    ░   ▒   ░  ░  ░  ░  ░  ░  
 ░  ░  ░    ░ ░              ░  ░    ░  ░         ░     ░  ░         ░       ░        ░  ░      ░        ░  
                                                                                                            ");

        Console.WriteLine("1 - Ajouter Client");
        Console.WriteLine("2 - Créer Chambre");
        Console.WriteLine("3 - Créer Hotel");
        Console.WriteLine("4 - Ajouter Réservation");
        Console.WriteLine("5 - Afficher des trucs");
        Console.WriteLine("0 - Quitter");
    }

    private static void CreerClient()
    {
    }

    private static void CreerChambre()
    {
    }

    private static void CreerHotel()
    {
    }

    private static void CreerReservation()
    {
    }

    private static void AfficherTruc()
    {
    }

    public static void Start()
    {
        while (true)
        {
            AfficherMenu();
            string choix = Console.ReadLine()!;

            switch (choix)
            {
                case "1":
                    CreerClient();
                    break;
                case "2":
                    CreerChambre();
                    break;
                case "3":
                    CreerHotel();
                    break;
                case "4":
                    CreerReservation();
                    break;
                case "5":
                    AfficherTruc();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Erreur de saisie");
                    break;
            }
        }
    }
}