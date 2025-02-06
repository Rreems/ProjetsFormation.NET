using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Exo01EFCore.Data;
using Exo02EFCore.Models;
using Exo02EFCore.Repositories;
namespace Exo02EFCore.UI;


internal class MainUI
{
    private readonly IRepository<Client, int> clientRepository;
    private readonly IRepository<Chambre, int> chambreRepository;
    private readonly IRepository<Hotel, int> hotelRepository;
    private readonly IRepository<Reservation, int> reservationRepository;


    public MainUI()
    {
        using var _db = new AppDbContext();

        this.clientRepository = new ClientRepository(_db);
        this.chambreRepository = new ChambreRepository(_db);
        this.hotelRepository = new HotelRepository(_db);
        this.reservationRepository = new ReservationRepository(_db);
    }


    private static void AfficherMenu()
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Black;
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

        Console.ResetColor();

        Console.WriteLine("1 - Ajouter Client");
        Console.WriteLine("2 - Créer Chambre");
        Console.WriteLine("3 - Créer Hotel");
        Console.WriteLine("4 - Ajouter Réservation");
        Console.WriteLine("5 - Afficher des trucs");
        Console.WriteLine("0 - Quitter");
    }

    private void CreerClient()
    {

        clientRepository.Add(new Client { Nom = "bob", Prenom = "truc", NumeroTelephone = "01010101" });


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

    public void Start()
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