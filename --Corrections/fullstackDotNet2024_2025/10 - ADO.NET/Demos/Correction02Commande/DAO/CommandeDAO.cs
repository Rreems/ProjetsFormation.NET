using Correction02Commande.Classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Correction02Commande.DAO
{
    internal class CommandeDAO
    {

        private string request = "";

        public Commande Save(Commande commande)
        {
            request = "INSERT INTO commande (total, date_commande, client_id) OUTPUT INSERTED.ID VALUES (@total, @date_commande, @client_id);";

            using SqlConnection connection = DataConnection.GetConnection;

            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@total", commande.Total);
            command.Parameters.AddWithValue("@date_commande", commande.DateCommande);
            command.Parameters.AddWithValue("@client_id", commande.ClientId);

            connection.Open();

            commande.Id = (int)command.ExecuteScalar();

            return commande;
        }

        /// <summary>
        /// Récupérer les commandes d'un client
        /// </summary>
        /// <param name="client">Le client pour lequel on souhaite récupérer les commandes</param>
        /// <returns></returns>
        public List<Commande> GetAllCommandsOfAClient(Client client)
        {
            List<Commande> commandes = new();

            request = "SELECT id, total, date_commande, client_id FROM commande WHERE client_id=@client_id;";

            using SqlConnection connection = DataConnection.GetConnection;

            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@client_id", client.Id);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                commandes.Add(new Commande(reader.GetInt32(0), reader.GetDecimal(1), reader.GetDateTime(2), reader.GetInt32(3)));
            }

            return commandes;
        }

        /// <summary>
        /// Suppression de toutes les commandes d'un client
        /// </summary>
        /// <param name="client">le client pour lequel on souhaite supprimer les commandes</param>
        public void DeleteAllCommandsOfAClient(Client client)
        {
            request = "DELETE FROM commande WHERE client_id=@client_id";

            using SqlConnection connection = DataConnection.GetConnection;

            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@client_id", client.Id);

            connection.Open();

            command.ExecuteNonQuery();
        }

    }
}
