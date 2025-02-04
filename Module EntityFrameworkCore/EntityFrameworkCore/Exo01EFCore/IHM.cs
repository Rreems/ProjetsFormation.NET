using Exo01EFCore.Models;

internal static class IHM
{

    private static void AfficherMenu()
    {
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine(@"
'  ██████╗ ███████╗██████╗ ███████╗ ██████╗     ██████╗ ██████╗  ██████╗ 
'  ██╔══██╗██╔════╝██╔══██╗██╔════╝██╔═══██╗    ██╔══██╗██╔══██╗██╔════╝ 
'  ██████╔╝█████╗  ██████╔╝███████╗██║   ██║    ██████╔╝██████╔╝██║  ███╗
'  ██╔═══╝ ██╔══╝  ██╔══██╗╚════██║██║   ██║    ██╔══██╗██╔═══╝ ██║   ██║
'  ██║     ███████╗██║  ██║███████║╚██████╔╝    ██║  ██║██║     ╚██████╔╝
'  ╚═╝     ╚══════╝╚═╝  ╚═╝╚══════╝ ╚═════╝     ╚═╝  ╚═╝╚═╝      ╚═════╝ ");
        Console.WriteLine("1 - Créer un personnage");
        Console.WriteLine("2 - Mettre à jour un personnage");
        Console.WriteLine("3 - Afficher tous les personnages");
        Console.WriteLine("4 - Frapper un personnage");
        Console.WriteLine("5 - Afficher les personnages ayant des PVs (PV + armure) supérieurs à la moyenne");
        Console.WriteLine("0 - Quitter");
    }

    private static void AjouterPersonnage()
    {
        Personnage personnage = new Personnage();

        Console.Write("Saisir le pseudo: ");
        personnage.Pseudo = Console.ReadLine()!;

        Console.Write("Saisir les PointsDeVie: ");
        int.TryParse(Console.ReadLine()!, out int pv);
        personnage.PointsDeVie = pv;

        Console.Write("Saisir l'Armure: ");
        int.TryParse(Console.ReadLine()!, out int arm);
        personnage.Armure = arm;

        Console.Write("Saisir les Degats: ");
        int.TryParse(Console.ReadLine()!, out int deg);
        personnage.Degats = deg;


        personnage.DateCreation = DateTime.Now;


        Console.Write("Saisir le NombrePersonnesTues: ");
        int.TryParse(Console.ReadLine()!, out int nbP);
        personnage.NombrePersonnesTues = nbP;


        // On envoie les modifs en base:
        Personnage.Ajouter(personnage);

    }

    private static void MettreAJourPersonnage()
    {
        Personnage personnage = new Personnage();
        Console.Write("Saisir l'ID de Personnage à modifier : ");
        int id;
        while (!int.TryParse(Console.ReadLine()!, out id))
            Console.Write("Erreur de saisie, réessayez :");
        personnage.Id = id;

        Console.Write("Saisir le pseudo (laissez vide pour ne pas modifier): ");
        personnage.Pseudo = Console.ReadLine()!;


        Console.Write("Saisir les PointsDeVie : ");
        int.TryParse(Console.ReadLine()!, out int pv);
        personnage.PointsDeVie = pv;

        Console.Write("Saisir l'Armure: ");
        int.TryParse(Console.ReadLine()!, out int arm);
        personnage.Armure = arm;

        Console.Write("Saisir les Degats : ");
        int.TryParse(Console.ReadLine()!, out int deg);
        personnage.Degats = deg;

        Console.Write("Saisir la DateCreation : ");
        DateTime dateCrea;
        // contrôle de saisie : mauvaise saisie 
        while (!DateTime.TryParse(Console.ReadLine()!, out dateCrea))
            Console.WriteLine("Erreur de saisie, réessayez :");
        personnage.DateCreation = dateCrea;


        Console.Write("Saisir le NombrePersonnesTues : ");
        int.TryParse(Console.ReadLine()!, out int nbP);
        personnage.NombrePersonnesTues = nbP;

        // On envoie les modifs en base:
        if (!Personnage.Modifier(personnage))
        {
            Console.WriteLine("L'ID de Personnage n'existe pas en base.");
        }

    }

    private static void AfficherToutPersonnages()
    {
        Console.Clear();
        Console.WriteLine("-------------------");
        Console.WriteLine("Liste de personnages en base: ");
        Personnage.Afficher().ForEach(p => Console.WriteLine(p));
        Console.WriteLine("-------------------");
    }

    private static void FrapperPersonnage()
    {
        Console.WriteLine("Qui frappe ? (par Id)");
        int idFrappeur;
        while (!int.TryParse(Console.ReadLine()!, out idFrappeur))
            Console.Write("Erreur de saisie, réessayez :");

        Console.WriteLine("Qui est frappé ? (par Id)");
        int idFrappe;
        while (!int.TryParse(Console.ReadLine()!, out idFrappe))
            Console.Write("Erreur de saisie, réessayez :");

        try
        {
            Personnage.Frapper(idFrappe, idFrappeur);
        }
        catch (NullReferenceException e)
        {
            Console.Write(e.Message);
        }
    }

    private static void AfficherPersonnagesTanks()
    {
        Console.Clear();
        Console.WriteLine("-------------------");
        Console.WriteLine("Liste de personnages dont PV + armure > moyenne : ");
        Personnage.AfficherTanks().ForEach(p => Console.WriteLine(p));
        Console.WriteLine("-------------------");
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
                    AjouterPersonnage();
                    break;
                case "2":
                    MettreAJourPersonnage();
                    break;
                case "3":
                    AfficherToutPersonnages();
                    break;
                case "4":
                    FrapperPersonnage();
                    break;
                case "5":
                    AfficherPersonnagesTanks();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Erreur de saisie");
                    break;
            }
        }
        Console.ReadKey();
        Console.Clear();
    }
}