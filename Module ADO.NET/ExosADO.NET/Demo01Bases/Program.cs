using Microsoft.Data.SqlClient;
using System.Data;

string connectionString = "Data Source=(localdb)\\demo01ado; Database=ContactDB;";

//// Création d'une connexion grâce à la classe SQLConnection de ADO.NET
//var connection = new SqlConnection(connectionString);

//// Ouverture de la connexion
//connection.Open();

//// On peut vérifier l'état de la connexion
//if(connection.State == ConnectionState.Open)
//{
//    Console.WriteLine("La connexion est ouverte!");
//} else
//{
//    Console.WriteLine("Problème de connexion ...");
//}

//// On ferme toujours la connexion à la fin de son utilisation
////connection.Close();

//string prenom = Console.ReadLine() ?? "";
//string nom = Console.ReadLine() ?? "";
//string email = Console.ReadLine() ?? "";

//// Création d'une requête SQL avec binding de paramètres pour se protéger de l'injection SQL
//string query = "INSERT INTO personne (prenom, nom, email) VALUES (@prenom, @nom, @email)";

//// Création d'un objet de commande pour envoyer des requêtes à la base de données
//var command = new SqlCommand(query, connection);

//// Ajout des paramètres de la requête
//command.Parameters.AddWithValue("@prenom", prenom);
//command.Parameters.AddWithValue("@nom", nom);
//command.Parameters.AddWithValue("@email", email);

//// Une commande peut exécuter 3 types de méthodes
//// 1. ExecuteNonQuery : requête qui ne renvoie pas de résultat, elle renvoie le nom de ligne affectées
//// 2. ExecuteScalar : Renvoie une valeur unique, l'équivalent d'une cellule
//// 3. ExecuteReader : Renvoie un tableau de valeurs, pour les requêtes SELECT
//var rowsAffected = command.ExecuteNonQuery();

//Console.WriteLine(rowsAffected);


//// Permet de libérer les ressources
//command.Dispose();

// Lire des enregistrements

using (SqlConnection conn = new SqlConnection(connectionString))
{
    conn.Open();

    // string request = "SELECT 0, 1, 2, 3 FROM personne;";
    string request = "SELECT id, prenom, nom, email FROM personne;";

    SqlCommand sqlCommand = new SqlCommand(request, conn);

    SqlDataReader reader = sqlCommand.ExecuteReader();

    while (reader.Read())
    {
        Console.WriteLine($"id: {reader.GetInt32(0)} prenom: {reader.GetString(1)} nom: {reader.GetString(2)}, email: {reader.GetString(3)}");
    }


}

// Lire une valeur scalaire

using (SqlConnection conn = new SqlConnection(connectionString))
{
    conn.Open();

    // string request = "SELECT 0, 1, 2, 3 FROM personne;";
    string request = "SELECT COUNT(*) FROM personne;";

    SqlCommand sqlCommand = new SqlCommand(request, conn);

    int nombrePersonne = (int) sqlCommand.ExecuteScalar();

    Console.WriteLine($"Il y a {nombrePersonne} d'enregistrés dans la base de données");

}