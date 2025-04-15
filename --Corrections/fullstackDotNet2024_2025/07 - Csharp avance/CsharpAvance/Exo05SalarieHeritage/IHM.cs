namespace Exo05SalarieHeritage;

internal static class IHM
{
    private static int _tailleEntreprise = 20;
    private static List<Salarie> _salaries = new List<Salarie>()
     {
         new Salarie(),
         new Commercial(),
     };

    public static void Start()
    {
        while (true)
        {
            AfficherMenu();
            string choix = Console.ReadLine()!;

            switch (choix)
            {
                case "1":
                    if (_salaries.Count == _tailleEntreprise)
                    {
                        Console.WriteLine("L'entreprise est complète !");
                        break;
                    }
                    AjouterSalarie();
                    break;
                case "2":
                    AfficherSalaires();
                    break;
                case "3":
                    RechercherSalarie();
                    break;
                case "0":
                    return; // sort de la méthode Start directement
                            //Environment.Exit(0);
                default:
                    Console.WriteLine("Erreur de saisie !");
                    break;
            }
        };
        // Start(); //permet de faire de la récursivité => Start s'apelle elle même => on boucle (/!\ StackOverflow)
    }

    private static void AfficherMenu()
    {
        Console.WriteLine("===== Gestion des employés =====\n");
        Console.WriteLine("1-- Ajouter un employé");
        Console.WriteLine("2-- Afficher le salaire des employés");
        Console.WriteLine("3-- Rechercher un employé");
        Console.WriteLine("0-- Quitter");
        Console.Write("\nEntrez votre choix : ");
    }

    private static void AjouterSalarie()
    {
        do
        {
            AfficherMenuAjouterSalarie();
            string choix = Console.ReadLine()!;

            switch (choix)
            {
                case "1":
                    var tuple = SaisieChampsSalarie();

                    Salarie salarie = new Salarie(tuple.Matricule, tuple.Service, tuple.Categorie, tuple.Nom, tuple.Salaire);

                    _salaries.Add(salarie);

                    return; // sort de la fonction directement et retourne au menu principal
                case "2":
                    var tupleSalarie = SaisieChampsSalarie();
                    var tupleCommercial = SaisieChampsCommercial();

                    Commercial comercial = new Commercial(tupleSalarie.Matricule, tupleSalarie.Service, tupleSalarie.Categorie, tupleSalarie.Nom, tupleSalarie.Salaire, tupleCommercial.ChiffreDAffaire, tupleCommercial.Commission);

                    _salaries.Add(comercial);

                    return;
                case "0":
                    return;
                default:
                    Console.WriteLine("Erreur de saisie !");
                    break; // fin du switch => boucle suivante
            }
        } while (true);
    }

    private static void AfficherMenuAjouterSalarie()
    {
        Console.WriteLine("=== Ajouter un employé ===");
        Console.WriteLine("1-- Salarié");
        Console.WriteLine("2-- Commercial");
        Console.WriteLine("0-- Retour au menu principal");
        Console.Write("\nEntrez votre choix : ");
    }
    private static (string Matricule, string Nom, string Service, string Categorie, decimal Salaire) SaisieChampsSalarie()
    {
        Console.Write("Merci de saisir le nom :");
        string nom = Console.ReadLine()!;
        Console.Write("Merci de saisir le matricule :");
        string matricule = Console.ReadLine()!;
        Console.Write("Merci de saisir la catégorie :");
        string categorie = Console.ReadLine()!;
        Console.Write("Merci de saisir le service :");
        string service = Console.ReadLine()!;
        Console.Write("Merci de saisir le salaire :");
        //decimal salaire = decimal.Parse(Console.ReadLine()!); // penser à ajouter un contrôle de saisie
        decimal salaire;
        while (!decimal.TryParse(Console.ReadLine()!, out salaire) || salaire <= 0)
            Console.Write("Erreur de Saisie! Réessayez : ");

        return (matricule, nom, service, categorie, salaire);
    }
    private static (decimal ChiffreDAffaire, decimal Commission) SaisieChampsCommercial()
    {
        Console.Write("Merci de saisir le chiffre d'affaire du commercial :");
        decimal chiffreDAffaire;
        while (!decimal.TryParse(Console.ReadLine()!, out chiffreDAffaire) || chiffreDAffaire <= 0)
            Console.Write("Erreur de Saisie! Réessayez : ");

        Console.Write("Merci de saisir la commission (%) :");
        decimal commission;
        while (!decimal.TryParse(Console.ReadLine()!, out commission) || commission <= 0)
            Console.Write("Erreur de Saisie! Réessayez : ");

        return (chiffreDAffaire, commission);
    }

    private static void AfficherSalaires()
    {
        Console.WriteLine("=== Salaire des employés ===");

        foreach (Salarie salarie in _salaries)
        {
            Console.WriteLine("-----------");
            Console.WriteLine(salarie);
            salarie.AfficherSalaire();
            Console.WriteLine("-----------");
        }
    }

    private static void RechercherSalarie()
    {
        // RECHERCHE D'UN SEUL EMPLOYE
        //Console.WriteLine("=== Recherche d'un employé par nom ===");

        //Console.Write("Merci de saisir le nom : ");
        //string recherche = Console.ReadLine()!.ToLower();

        //foreach (Salarie salarie in _salaries)
        //{
        //    //if(salarie.Nom.ToLower() == recherche) // le nom saisi est identique au nom du salarié
        //    if (salarie.Nom.ToLower().Contains(recherche))
        //    {
        //        Console.WriteLine(salarie);
        //        salarie.AfficherSalaire();
        //        return;
        //    }
        //}

        //Console.WriteLine("Salarie non trouvé !");


        // Débuts avec LINQ

        //Salarie? salarie = _salaries.Find(sal => sal.Nom.ToLower().Contains(recherche));
        // Find est une méthode de LINQ, elle permet de chercher un élément selon un prédicat
        // Un predicat est un genre de fonction qui prend chaque salarié et s'assure si une condition est vrai ou fausse


        Console.WriteLine("=== Recherche de plusieurs employés par nom ===");

        Console.Write("Merci de saisir le nom : ");
        string recherche = Console.ReadLine()!.ToLower();

        List<Salarie> salariesCorrespondants = _salaries.Where(sal => sal.Nom.ToLower().Contains(recherche)).ToList();
        // Where(predicat).Tolist() nous permet de filtrer une liste ou un tableau selon une condition

        if (salariesCorrespondants.Count == 0)
        {
            Console.WriteLine("Aucun salarié trouvé !");
        }
        else
        {
            Console.WriteLine("Liste des salariés trouvés :");
            foreach (Salarie salarie in salariesCorrespondants)
            {
                Console.WriteLine("-----------");
                Console.WriteLine(salarie);
                salarie.AfficherSalaire();
                Console.WriteLine("-----------");
            }
        }

    }
}
