using Demo02Dao.Classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo02Dao.Dao
{
    internal class ChienDAO : BaseDAO<Chien>
    {
        public override List<Chien> GetAll()
        {
            List<Chien> chiens = new();

            using SqlConnection connection = DataConnection.GetConnection;

            request = "SELECT id, nom, date_naissance, maitre_id FROM chien;";

            using SqlCommand command = new SqlCommand(request, connection);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Chien chien = new Chien(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2));

                // On vérifie si le chien à un maitre !
                if(!reader.IsDBNull(3))
                {
                    // chargement du maitre dans le chien
                    MaitreDAO maitreDAO = new MaitreDAO();
                    chien.Maitre = maitreDAO.GetOneById(reader.GetInt32(3));
                }

                chiens.Add(chien);
            }

            return chiens;
        }

        /// <summary>
        /// Permet de récupérer tous les chiens d'un maître
        /// </summary>
        /// <param name="maitre">le maitre dont on veut récupérer les chiens</param>
        /// <returns>Une liste de Chien</returns>
        public List<Chien> GetAllByMaster(Maitre maitre)
        {
            List<Chien> chiens = new();

            using SqlConnection connection = DataConnection.GetConnection;

            request = "SELECT id, nom, date_naissance, maitre_id FROM chien WHERE maitre_id=@maitre_id;";

            using SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.AddWithValue("@maitre_id", maitre.Id);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Chien chien = new Chien(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2));
                chien.Maitre = maitre;

                chiens.Add(chien);
            }
            maitre.Chiens = chiens;

            return chiens;
        }

        /// <summary>
        /// Récupération d'un chien par son ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Chien? GetOneById(int id)
        {
            Chien? chien = null;

            request = "SELECT id, nom, date_naissance, maitre_id FROM chien WHERE id=@id";

            using SqlConnection connection = DataConnection.GetConnection;

            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@id", id);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                //chien = new Chien(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2));
                chien = new Chien((int)reader["id"], (string)reader["nom"], (DateTime)reader["date_naissance"]);

                if (!reader.IsDBNull(3))
                {
                    MaitreDAO maitreDAO = new MaitreDAO();
                    chien.Maitre = maitreDAO.GetOneById(reader.GetInt32(3));
                }

            }

            return chien;
        }

        /// <summary>
        /// Sauvegarde d'un chien
        /// </summary>
        /// <param name="element">une instance Chien</param>
        /// <returns>Le chien avec l'ID généré en base de données</returns>
        public override Chien Save(Chien element)
        {

            using SqlConnection connection = DataConnection.GetConnection;

            using SqlCommand command = new SqlCommand();

            // La requête n'est pas la même en fonction de si un chien a un maître ou non
            if(element.Maitre is null)
            {
                // OUTPUT INSERTED.ID retourne l'id généré par la base sous forme de int
                request = "INSERT INTO chien (nom, date_naissance) OUTPUT INSERTED.ID VALUES (@nom, @date_naissance);";
                command.CommandText = request;
            }
            else
            {
                request = "INSERT INTO chien (nom, date_naissance, maitre_id) OUTPUT INSERTED.ID VALUES (@nom, @date_naissance, @maitre_id);";
                command.CommandText = request;
                command.Parameters.AddWithValue("@maitre_id", element.Maitre.Id);
            }

            command.Parameters.AddWithValue("@nom", element.Nom);
            command.Parameters.AddWithValue("@date_naissance", element.DateNaissance);

            command.Connection = connection;

            connection.Open();

            element.Id = (int) command.ExecuteScalar();

            return element;
        }

        public override Chien Update(Chien element)
        {
            using SqlConnection connection = DataConnection.GetConnection;

            using SqlCommand command = new SqlCommand();

            if (element.Maitre is null)
            {
                request = "UPDATE chien SET nom=@nom, date_naissance=@date_naissance WHERE id=@id;";
                command.CommandText = request;
            }
            else
            {
                request = "UPDATE chien SET nom=@nom, date_naissance=@date_naissance, maitre_id=@maitre_id WHERE id=@id;"; ;
                command.CommandText = request;
                command.Parameters.AddWithValue("@maitre_id", element.Maitre.Id);
            }

            command.Parameters.AddWithValue("@nom", element.Nom);
            command.Parameters.AddWithValue("@date_naissance", element.DateNaissance);
            command.Parameters.AddWithValue("@id", element.Id);

            command.Connection = connection;

            connection.Open();

            command.ExecuteNonQuery();

            return element;
        }
    }
}
