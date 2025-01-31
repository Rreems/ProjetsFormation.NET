using Microsoft.Data.SqlClient;
using System.Data;

string connectionString = "Data Source=(localdb)\\demo01ado; Database=ContactDB;";



//// Création d'une connexion grâce à la classe SQLConnection de ADO.NET
//var connection = new SqlConnection(connectionString);

//// Ouverture de la connexion
//connection.Open();

//Microsoft.Data.SqlClient.SqlException : 'Une connexion a été établie avec le serveur, mais une erreur s'est
//ensuite produite pendant le processus d'ouverture de session. (provider: Fournisseur de canaux nommés, error: 0
//- Il n’y a pas de processus à l’autre extrémité du canal.)'

//// On peut vérifier l'état de la connexion
//if (connection.State == ConnectionState.Open)
//{
//    Console.WriteLine("La connexion est ouverte!");
//}
//else
//{
//    Console.WriteLine("Problème de connexion ...");
//}
////On ferme toujours la connexion à la fin de son utilisation
//connection.Close();




//---------------------------------------------
// Insert

// Création d'une connexion grâce à la classe SQLConnection de ADO.NET
var connection = new SqlConnection(connectionString);

// Ouverture de la connexion
connection.Open();

Console.Write("Entrez le 'prenom': ");
string prenom = Console.ReadLine()!;
Console.Write("Entrez le 'nom': ");
string nom = Console.ReadLine()!;
Console.Write("Entrez le 'email': ");
string email = Console.ReadLine()!;

// Création d'une requête SQL avec binding de paramètres pour se protéger de l'injection SQL
string query = "INSERT INTO personne (prenom, nom, email) VALUES (@prenom, @nom, @email)";

// Création d'un objet de commande pour envoyer des requêtes à la base de données
var command = new SqlCommand(query, connection);

// Ajout des paramètres de la requête
command.Parameters.AddWithValue("@prenom", prenom);
command.Parameters.AddWithValue("@nom", nom);
command.Parameters.AddWithValue("@email", email);

var rowsAffected = command.ExecuteNonQuery();

Console.WriteLine(rowsAffected);

// Permet de libérer les ressources
command.Dispose();
connection.Close();

//---------------------------------------------
//  Select

using (SqlConnection conn = new SqlConnection(connectionString))
{
    conn.Open();

    // string request = "SELECT 0, 1, 2, 3 FROM personne;";
    string request = "SELECT id, prenom, nom, email FROM personne;";

    SqlCommand sqlCommand = new SqlCommand(request, conn);

    SqlDataReader reader = sqlCommand.ExecuteReader();

    Console.WriteLine("----------------------\nAffichage de ma table personne: ");
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

    int nombrePersonne = (int)sqlCommand.ExecuteScalar();

    Console.WriteLine($"\nIl y a {nombrePersonne} personnes d'enregistrés dans la base de données");

}
Console.WriteLine("Fin du programme... Entrée pour quitter.");
Console.ReadLine();