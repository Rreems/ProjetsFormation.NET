using Exo01ado.Classes;
using Microsoft.Data.SqlClient;



Etudiant etud = new Etudiant(3, "Bobby", "Dylannou", 2, "2014-01-29");
//etud.Save();

//etud.Delete();

//Console.WriteLine(Etudiant.GetById(2));
//List<Etudiant> lstEtud = Etudiant.GetEtudiants(3);

//***********************************************************
// IHM 

while (true)
{
    AfficherMenu();
    string choix = Console.ReadLine()!;

    switch (choix)
    {
        case "1":
            AfficherEtudiants();
            break;
        case "2":
            AfficherEtudiantsClasse();
            break;
        case "3":
            SupprimerEtudiant();
            break;
        case "4":
            ModifierEtudiant();
            break;
        case "5":
            AjouterEtudiant();
            break;
        case "0":
            return; // sort de la méthode Start directement
                    //Environment.Exit(0);
        default:
            Console.WriteLine("Erreur de saisie !");
            break;
    }
};

static void AfficherMenu()
{
    Console.WriteLine("===== Gestion des etudiants via SQLServeur =====\n");
    Console.WriteLine("1-- Afficher la totalité des étudiants");
    Console.WriteLine("2-- Afficher les etudiants d'une classe");
    Console.WriteLine("3-- Supprimer un etudiant");
    Console.WriteLine("4-- Mettre à jour un etudiant à partir d'un objet etudiant ");
    Console.WriteLine("5-- Ajouter un étudiant ");
    Console.WriteLine("0-- Quitter");
    Console.Write("\nEntrez votre choix : ");
}





//***********************************************************
//   Fct Affichage
static void AfficherEtudiants()
{
    Console.Clear();

    string connectionString = "Data Source=(localdb)\\demo01ado; Database=ContactDB;";

    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        conn.Open();

        // string request = "SELECT 0, 1, 2, 3 FROM personne;";
        string request = "SELECT id, nom, prenom, numClasse, dateDiplome FROM etudiants;";

        SqlCommand sqlCommand = new SqlCommand(request, conn);

        SqlDataReader reader = sqlCommand.ExecuteReader();

        Console.Clear();
        Console.WriteLine("----------------------\nAffichage de ma table etudiants: ");
        while (reader.Read())
        {
            Console.WriteLine($"id: {reader.GetInt32(0)} nom: {reader.GetString(1)} prenom: {reader.GetString(2)}" +
                              $" numClasse: {reader.GetInt32(3)}, dateDiplome: {reader.GetDateTime(4)}");
        }
    }

    Console.WriteLine("----------------------\n");
}

//***********************************************************
//   Fct Affichage pour une classe
static void AfficherEtudiantsClasse()
{
    Console.Clear();

    string connectionString = "Data Source=(localdb)\\demo01ado; Database=ContactDB;";

    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        Console.Write("Entrez la classe à afficher: ");
        int numClasse;
        int.TryParse(Console.ReadLine(), out numClasse);

        conn.Open();

        // string request = "SELECT 0, 1, 2, 3 FROM personne;";
        string request = "SELECT id, nom, prenom, numClasse, dateDiplome FROM etudiants WHERE numClasse = @numClasse;";


        SqlCommand sqlCommand = new SqlCommand(request, conn);
        sqlCommand.Parameters.AddWithValue("@numClasse", numClasse);

        SqlDataReader reader = sqlCommand.ExecuteReader();

        Console.Clear();
        Console.WriteLine($"----------------------\nAffichage de ma table etudiants de la classe {numClasse}: ");
        while (reader.Read())
        {
            Console.WriteLine($"id: {reader.GetInt32(0)} nom: {reader.GetString(1)} prenom: {reader.GetString(2)}" +
                              $" numClasse: {reader.GetInt32(3)}, dateDiplome: {reader.GetDateTime(4)}");
        }
    }

    Console.WriteLine("----------------------\n");
}





//***********************************************************
//   Fct Supprimer Etudiant
static void SupprimerEtudiant()
{
    Console.Clear();

    string connectionString = "Data Source=(localdb)\\demo01ado; Database=ContactDB;";

    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        conn.Open();

        Console.Write("Entrez l'id à supprimer: ");
        int idEtudiant;
        int.TryParse(Console.ReadLine(), out idEtudiant);


        // Création d'une requête SQL avec binding de paramètres pour se protéger de l'injection SQL
        string query = "DELETE FROM etudiants WHERE id= @idEtudiant";

        // Création d'un objet de commande pour envoyer des requêtes à la base de données
        var command = new SqlCommand(query, conn);

        // Ajout des paramètres de la requête
        command.Parameters.AddWithValue("@idEtudiant", idEtudiant);

        var rowsAffected = command.ExecuteNonQuery();
    }

    Console.WriteLine("----------------------\n");
}



//***********************************************************
//   Fct Supprimer Etudiant
static void ModifierEtudiant()
{
    Console.Clear();

    string connectionString = "Data Source=(localdb)\\demo01ado; Database=ContactDB;";

    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        conn.Open();


        Console.Write("Entrez l'id de l'étudiant à modifier: ");
        int idEtudiant;
        int.TryParse(Console.ReadLine(), out idEtudiant);

        Console.Write("Entrez le 'prenom': ");
        string prenom = Console.ReadLine()!;
        Console.Write("Entrez le 'nom': ");
        string nom = Console.ReadLine()!;
        Console.Write("Entrez la 'numClasse': ");

        int numClasse;
        int.TryParse(Console.ReadLine(), out numClasse);
        Console.Write("Entrez la 'dateDiplome' au format YYYY-MM-DD: ");
        string dateDiplome = Console.ReadLine()!;

        // Création d'une requête SQL avec binding de paramètres pour se protéger de l'injection SQL
        string query = "UPDATE etudiants SET nom = @nom , prenom = @prenom , numClasse = @numClasse, dateDiplome = @dateDiplome WHERE id = @id";

        // Création d'un objet de commande pour envoyer des requêtes à la base de données
        var command = new SqlCommand(query, conn);

        // Ajout des paramètres de la requête
        command.Parameters.AddWithValue("@id", idEtudiant);
        command.Parameters.AddWithValue("@nom", nom);
        command.Parameters.AddWithValue("@prenom", prenom);
        command.Parameters.AddWithValue("@numClasse", numClasse);
        command.Parameters.AddWithValue("@dateDiplome", dateDiplome);

        var rowsAffected = command.ExecuteNonQuery();
    }

    Console.WriteLine("----------------------\n");
}



//***********************************************************
//   Fct Ajout Etudiant
static void AjouterEtudiant()
{
    Console.Clear();

    string connectionString = "Data Source=(localdb)\\demo01ado; Database=ContactDB;";

    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        conn.Open();

        Console.Write("Entrez le 'prenom': ");
        string prenom = Console.ReadLine()!;
        Console.Write("Entrez le 'nom': ");
        string nom = Console.ReadLine()!;
        Console.Write("Entrez la 'numClasse': ");

        int numClasse;
        int.TryParse(Console.ReadLine(), out numClasse);
        Console.Write("Entrez la 'dateDiplome' au format YYYY-MM-DD: ");
        string dateDiplome = Console.ReadLine()!;

        // Création d'une requête SQL avec binding de paramètres pour se protéger de l'injection SQL
        string query = "INSERT INTO etudiants (nom, prenom, numClasse, dateDiplome) VALUES (@nom, @prenom, @numClasse, @dateDiplome)";

        // Création d'un objet de commande pour envoyer des requêtes à la base de données
        var command = new SqlCommand(query, conn);

        // Ajout des paramètres de la requête
        command.Parameters.AddWithValue("@nom", nom);
        command.Parameters.AddWithValue("@prenom", prenom);
        command.Parameters.AddWithValue("@numClasse", numClasse);
        command.Parameters.AddWithValue("@dateDiplome", dateDiplome);


        var rowsAffected = command.ExecuteNonQuery();
    }

    Console.WriteLine("----------------------\n");
}

