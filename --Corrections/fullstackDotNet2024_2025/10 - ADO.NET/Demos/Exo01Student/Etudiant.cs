using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Exo01Student;

internal class Etudiant
{
    public int Id { get; set; }
    public string Prenom { get; set; }
    public string Nom { get; set; }
    public int NumeroClasse { get; set; }
    public DateTime DateDiplome { get; set; }

    private static readonly string connectionString = "Data Source=(localdb)\\ContactDB;Integrated Security=True";

    public Etudiant(string prenom, string nom, int numeroClasse, DateTime dateDiplome)
    {
        Prenom = prenom;
        Nom = nom;
        NumeroClasse = numeroClasse;
        DateDiplome = dateDiplome;
    }

    public Etudiant(int id, string prenom, string nom, int numeroClasse, DateTime dateDiplome) : this(prenom, nom, numeroClasse, dateDiplome)
    {
        Id = id;
    }

    public override string ToString()
    {
        return $"Id:{Id:D3}, prenom:{Prenom}, nom {Nom}, classe:{NumeroClasse}, date diplome {DateDiplome:dd/MM/yyyy}";
    }

    public bool Save()
    {
        using var connection = new SqlConnection(Etudiant.connectionString);
        connection.Open();

        string query = "INSERT INTO etudiant (prenom, nom, numero_classe, date_diplome) " +
                       "VALUES (@prenom, @nom, @numero_classe, @date_diplome) " +
                       "SELECT CAST(SCOPE_IDENTITY() AS INT) "; // récupère l'id du nouvel utilisateur SCOPE_IDENTITY() -> le clé primaire

        using SqlCommand command = new(query, connection);

        command.Parameters.AddWithValue("@prenom", Prenom);
        command.Parameters.AddWithValue("@nom", Nom);
        command.Parameters.AddWithValue("@numero_classe", NumeroClasse);
        command.Parameters.AddWithValue("@date_diplome", DateDiplome);

        try
        {
            int id = (int)command.ExecuteScalar(); // id de l'utilisateur grace à la ligne plus haut
            Id = id; // l'étudiant a été ajouté donc il a désormais un Id
            return id > 0; // si il a un id -> il a bien été ajouté
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return false;
    }
    public bool Delete()
    {
        using SqlConnection connection = new(Etudiant.connectionString);
        string query = "DELETE FROM etudiant WHERE id=@id";

        connection.Open();

        using SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", Id); // propriété Id de l'étudiant

        try
        {
            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected == 1;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message); // écrire l'erreur si l'étudiant n'existe pas ou l'id est incorrect
        }
        return false;
    }
    public static Etudiant? GetById(int id)
    {
        using SqlConnection connection = new(Etudiant.connectionString);
        connection.Open();

        string query = "SELECT id, prenom, nom, numero_classe, date_diplome FROM etudiant WHERE id=@id;";

        using SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", id);

        using SqlDataReader reader = command.ExecuteReader();
        if (reader.Read())
        {
            Etudiant etudiant = new Etudiant(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetDateTime(4));
            return etudiant;
        }

        return null;
    }
    public static List<Etudiant> GetEtudiants(int? numeroClasse = null)
    {
        string query;
        List<Etudiant> etudiants = new();

        using SqlConnection connection = new(Etudiant.connectionString);
        using SqlCommand command = new SqlCommand(); // pas encore de connexion et de commande associées

        command.Connection = connection; // ajout de la connexion 
        connection.Open();

        if (numeroClasse is null)
        {
            query = "SELECT id, prenom, nom, numero_classe, date_diplome FROM etudiant;";
            command.CommandText = query; // ajout de la query
        }
        else
        {
            query = "SELECT id, prenom, nom, numero_classe, date_diplome FROM etudiant WHERE numero_classe=@numero_classe;";
            //query = "SELECT id, prenom, nom, numero_classe, date_diplome FROM etudiant WHERE prenom LIKE '%@prenom%';";
            command.CommandText = query;
            command.Parameters.AddWithValue("@numero_classe", numeroClasse);
        }

        using SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            etudiants.Add(new Etudiant(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetDateTime(4)));
        }

        return etudiants;
    }
    public static bool EditEtudiant(int id, Etudiant etudiant) // bool => réussite ou echec ; possible de retourner l'étudiant modifié
    {
        string query = "UPDATE etudiant SET prenom=@prenom, nom=@nom, numero_classe=@numero_classe, date_diplome=@date_diplome WHERE id=@id;";

        using SqlConnection connection = new(Etudiant.connectionString);
        using SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@prenom", etudiant.Prenom);
        command.Parameters.AddWithValue("@nom", etudiant.Nom);
        command.Parameters.AddWithValue("@numero_classe", etudiant.NumeroClasse);
        command.Parameters.AddWithValue("@date_diplome", etudiant.DateDiplome);
        command.Parameters.AddWithValue("@id", etudiant.Id);

        connection.Open();

        return command.ExecuteNonQuery() == 1;
    }
}
