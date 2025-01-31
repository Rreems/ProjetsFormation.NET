using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Exo01ado.Classes;

internal class Etudiant
{
    //static List<Etudiant> ListEtudiants = new List<Etudiant>();

    public int Id { get; set; }
    
    public string Prenom { get; set; }
    public string Nom {  get; set; }
    public int NumeroClasse { get; set; }
    public string DateDiplome { get; set; }


    public Etudiant(string prenom, string nom, int numeroClasse, string dateDiplome)
    {
        this.Nom = nom;
        this.Prenom = prenom;
        this.NumeroClasse = numeroClasse;
        this.DateDiplome = dateDiplome;

        //ListEtudiants.Add(this);
    }
    public Etudiant(int id, string prenom, string nom, int numeroClasse, string dateDiplome)
    {
        this.Id = id;
        this.Nom = nom;
        this.Prenom = prenom;
        this.NumeroClasse = numeroClasse;
        this.DateDiplome = dateDiplome;

    }    
    public Etudiant()
    {
        this.Id = 0;
        this.Nom = "John";
        this.Prenom = "Doe";
        this.NumeroClasse = 0;
        this.DateDiplome = "2000-01-01";

    }


    public bool Save()
    {
        string connectionString = "Data Source=(localdb)\\demo01ado; Database=ContactDB;";

        using SqlConnection conn = new SqlConnection(connectionString);
        
        conn.Open();

        // Création d'une requête SQL avec binding de paramètres pour se protéger de l'injection SQL
        string query = "INSERT INTO etudiants (nom, prenom, numClasse, dateDiplome) VALUES (@nom, @prenom, @numeroClasse, @dateDiplome)";

        // Création d'un objet de commande pour envoyer des requêtes à la base de données
        var command = new SqlCommand(query, conn);

        // Ajout des paramètres de la requête
        command.Parameters.AddWithValue("@id", this.Id);
        command.Parameters.AddWithValue("@nom", this.Nom);
        command.Parameters.AddWithValue("@prenom", this.Prenom);
        command.Parameters.AddWithValue("@numeroClasse", this.NumeroClasse);
        command.Parameters.AddWithValue("@dateDiplome", this.DateDiplome);

        var rowsAffected = command.ExecuteNonQuery();
        
        return true;
    }


    public bool Delete()
    {

        string connectionString = "Data Source=(localdb)\\demo01ado; Database=ContactDB;";

        using SqlConnection conn = new SqlConnection(connectionString)


        conn.Open();


        // Création d'une requête SQL avec binding de paramètres pour se protéger de l'injection SQL
        string query = "DELETE FROM etudiants WHERE id= @idEtudiant";

        // Création d'un objet de commande pour envoyer des requêtes à la base de données
        var command = new SqlCommand(query, conn);

        // Ajout des paramètres de la requête
        command.Parameters.AddWithValue("@idEtudiant", this.Id);

        var rowsAffected = command.ExecuteNonQuery();


        return true;
    }

    public static Etudiant GetById(int id)
    {
        Etudiant etudiant=new Etudiant();
        Console.Clear();

        string connectionString = "Data Source=(localdb)\\demo01ado; Database=ContactDB;";

        using SqlConnection conn = new SqlConnection(connectionString);
        

        conn.Open();

        // string request = "SELECT 0, 1, 2, 3 FROM personne;";
        string request = "SELECT id, nom, prenom, numClasse, dateDiplome FROM etudiants WHERE id = @id;";


        SqlCommand sqlCommand = new SqlCommand(request, conn);
        sqlCommand.Parameters.AddWithValue("@id", id);

        SqlDataReader reader = sqlCommand.ExecuteReader();

        Console.Clear();
        Console.WriteLine($"----------------------\nAffichage de l'étudiant id: {id}: ");
        if (reader.Read())
        {
            Console.WriteLine($"id: {reader.GetInt32(0)} nom: {reader.GetString(1)} prenom: {reader.GetString(2)}" +
                                $" numClasse: {reader.GetInt32(3)}, dateDiplome: {reader.GetDateTime(4)}");
            etudiant = new Etudiant(id, reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetDateTime(4).ToString()); 
        }


        return etudiant;
    }
    


    public static List<Etudiant> GetEtudiants(int? numeroClasse = null)
    {
        List<Etudiant> etudiants = new List<Etudiant>();

        string connectionString = "Data Source=(localdb)\\demo01ado; Database=ContactDB;";

        using SqlConnection conn = new SqlConnection(connectionString);
        


        conn.Open();

        // string request = "SELECT 0, 1, 2, 3 FROM personne;";
        string request = "SELECT id, nom, prenom, numClasse, dateDiplome FROM etudiants WHERE numClasse = @numClasse;";


        SqlCommand sqlCommand = new SqlCommand(request, conn);
        sqlCommand.Parameters.AddWithValue("@numClasse", numeroClasse);

        SqlDataReader reader = sqlCommand.ExecuteReader();

        Console.Clear();
        Console.WriteLine($"----------------------\nAffichage de ma table etudiants de la classe {numeroClasse}: ");
        while (reader.Read())
        {
            Console.WriteLine($"id: {reader.GetInt32(0)} nom: {reader.GetString(1)} prenom: {reader.GetString(2)}" +
                                $" numClasse: {reader.GetInt32(3)}, dateDiplome: {reader.GetDateTime(4)}");
            etudiants.Add(new Etudiant(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetDateTime(4).ToString()));
        }

        


        return etudiants;
    }
}