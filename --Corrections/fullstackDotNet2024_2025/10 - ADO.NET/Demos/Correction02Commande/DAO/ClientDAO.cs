using Correction02Commande.Classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Correction02Commande.DAO
{
    internal class ClientDAO
    {
        private string request = "";

        public Client Save(Client client)
        {
            request = "INSERT INTO client (prenom, nom, adresse, code_postal, ville, telephone) OUTPUT INSERTED.ID VALUES (@prenom, @nom, @adresse, @code_postal, @ville, @telephone);";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@prenom", client.Prenom);
            command.Parameters.AddWithValue("@nom", client.Nom);
            command.Parameters.AddWithValue("@adresse", client.Adresse);
            command.Parameters.AddWithValue("@code_postal", client.CodePostal);
            command.Parameters.AddWithValue("@ville", client.Ville);
            command.Parameters.AddWithValue("@telephone", client.Telephone);

            connection.Open();

            // Récupère l'ID du client qui a été généré grâce à l'instruction "OUTPUT INSERTED.ID"
            client.Id = (int)command.ExecuteScalar();

            return client;
        }

        public Client Update(Client client)
        {
            request = "UPDATE client SET prenom=@prenom, nom=@nom, adresse=@adresse, code_postal=@code_postal, ville=@ville, telephone=@telephone WHERE id=@id;";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@prenom", client.Prenom);
            command.Parameters.AddWithValue("@nom", client.Nom);
            command.Parameters.AddWithValue("@adresse", client.Adresse);
            command.Parameters.AddWithValue("@code_postal", client.CodePostal);
            command.Parameters.AddWithValue("@ville", client.Ville);
            command.Parameters.AddWithValue("@telephone", client.Telephone);
            command.Parameters.AddWithValue("@id", client.Id);

            connection.Open();

            command.ExecuteNonQuery();

            return client;
        }

        public bool Delete(Client client)
        {
            // Suppression des commandes du client
            CommandeDAO commandeDAO = new CommandeDAO();
            commandeDAO.DeleteAllCommandsOfAClient(client);

            // Suppression du client
            request = "DELETE FROM client WHERE id=@id";
            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@id", client.Id);

            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected > 0;
        }

        public Client? GetOneById(int id)
        {
            Client? client = null;

            request = "SELECT id, prenom, nom, adresse, code_postal, ville, telephone FROM client WHERE id=@id;";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@id", id);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                client = new Client(reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.GetString(5),
                    reader.GetString(6));
            }

            if (client is not null)
            {
                CommandeDAO commandeDAO = new CommandeDAO();
                client.Commandes = commandeDAO.GetAllCommandsOfAClient(client);
            }

            return client;
        }

        public List<Client> GetAll()
        {
            List<Client> clients = new();

            request = "SELECT id, prenom, nom, adresse, code_postal, ville, telephone FROM client;";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                clients.Add(
                    new Client(reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.GetString(5),
                    reader.GetString(6)));
            }

            return clients;
        }
    }
}
