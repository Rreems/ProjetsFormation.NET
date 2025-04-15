//using System.Data;
//using Microsoft.Data.SqlClient;


using Exo01Student;

internal class IHM
{
    private static void AfficherMenu()
    {
        Console.WriteLine("1 - Ajouter étudiant");
        Console.WriteLine("2 - Afficher tous les étudiants");
        Console.WriteLine("3 - Afficher les étudiants d'une classe");
        Console.WriteLine("4 - Supprimer un étudiant");
        Console.WriteLine("5 - Mettre à jour un étudiant");
        Console.WriteLine("0 - Quitter");
    }

    private static void AfficherEtudiants()
    {
        //Etudiant.GetEtudiants().ForEach(e => Console.WriteLine(e.ToString()));
        Console.WriteLine("Liste des étudiants :");
        Etudiant.GetEtudiants().ForEach(Console.WriteLine);
    }

    private static void AfficherEtudiantsClasse()
    {
        Console.Write("Saisir le n° de la classe: ");
        int numeroClasse = int.Parse(Console.ReadLine()!);
        Etudiant.GetEtudiants(numeroClasse).ForEach(Console.WriteLine);
    }

    private static void AjouterEtudiant()
    {
        string prenom;
        string nom;
        int numeroClasse;
        DateTime dateDiplome;

        Console.Write("Prénom:");
        prenom = Console.ReadLine()!;

        Console.Write("Nom:");
        nom = Console.ReadLine()!;

        Console.Write("Numéro classe:");
        numeroClasse = int.Parse(Console.ReadLine()!);

        Console.Write("Date diplome:");
        dateDiplome = DateTime.Parse(Console.ReadLine()!);

        Etudiant etudiant = new Etudiant(prenom, nom, numeroClasse, dateDiplome); // création d'une instance

        if (etudiant.Save()) // sauvegarde et mets à jour l'id > retourne un bool de réussite
        {
            Console.WriteLine($"{etudiant.Prenom} a bien été enregistré avec l'id {etudiant.Id} !"); 
        }
        else
        {
            Console.WriteLine($"Erreur lors de l'enregistrement de {etudiant.Prenom}");
        };
    }

    private static void SupprimerEtudiant()
    {
        Console.Write("Saisir l'id de l'étudiant à supprimer: ");
        int id;
        while (!int.TryParse(Console.ReadLine()!, out id))
            Console.Write("Erreur de saisie, réessayez :");

        var etudiant = Etudiant.GetById(id);

        if (etudiant is null)
        {
            Console.WriteLine("Etudiant introuvable !");
            return;
        }

        if (etudiant.Delete()) // supprime > retourne un bool de réussite
        {
            Console.WriteLine($"{etudiant.Prenom} supprimé avec succès!");
        }
        else
        {
            Console.WriteLine($"Erreur lors de la suppression de {etudiant.Prenom}");
        }
    }

    private static void EditEtudiant()
    {
        Console.Write("Saisir l'id de l'étudiant à éditer:");
        int id;
        while (!int.TryParse(Console.ReadLine()!, out id))
            Console.Write("Erreur de saisie, réessayez :");

        var etudiant = Etudiant.GetById(id);

        if (etudiant is null)
        {
            Console.WriteLine("Etudiant introuvable !");
            return;
        }

        Console.WriteLine(etudiant);

        Console.Write("Saisir le prénom (laissez vide pour ne pas modifier): ");
        string p = Console.ReadLine()!;
        etudiant.Prenom = string.IsNullOrEmpty(p) ? etudiant.Prenom : p; // si vide => on laisse le même

        Console.Write("Saisir le nom (laissez vide pour ne pas modifier): ");
        string n = Console.ReadLine()!;
        //etudiant.Nom = string.IsNullOrEmpty(n) ? etudiant.Nom : n;
        if(!string.IsNullOrEmpty(n))// si pas vide => on remplace
            etudiant.Nom = n;

        Console.Write("Saisir le numéro de classe (laissez vide pour ne pas modifier): ");
        int.TryParse(Console.ReadLine()!, out int c);
        etudiant.NumeroClasse = c > 0 ? c : etudiant.NumeroClasse;

        Console.Write("Saisir date: ");
        DateTime dateDiplome;
        // contrôle de saisie : mauvaise saisie ou date plus vieille que 50 ans avant aujourd'hui
        while (!DateTime.TryParse(Console.ReadLine()!, out dateDiplome) || dateDiplome < DateTime.Now.AddYears(-50)) 
            Console.WriteLine("Erreur de saisie, réessayez :");
        etudiant.DateDiplome = dateDiplome;

        if (Etudiant.EditEtudiant(id, etudiant))
        {
            Console.WriteLine($"{etudiant.Prenom} édité avec succès!");
        }
        else
        {
            Console.WriteLine($"Erreur lors de l'édition de {etudiant.Prenom}");
        };
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
                    AjouterEtudiant();
                    break;
                case "2":
                    AfficherEtudiants();
                    break;
                case "3":
                    AfficherEtudiantsClasse();
                    break;
                case "4":
                    SupprimerEtudiant();
                    break;
                case "5":
                    EditEtudiant();
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
