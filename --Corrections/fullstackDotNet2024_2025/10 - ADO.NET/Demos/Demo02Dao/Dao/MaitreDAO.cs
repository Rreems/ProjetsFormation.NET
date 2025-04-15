using Demo02Dao.Classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo02Dao.Dao
{
    internal class MaitreDAO : BaseDAO<Maitre>
    {
        public override List<Maitre> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Maitre? GetOneById(int id)
        {
            Maitre? maitre = null;

            request = "SELECT id, nom, prenom FROM maitre WHERE id=@id";

            using SqlConnection connection = DataConnection.GetConnection;

            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@id", id);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            if(reader.Read())
            {
                ChienDAO chienDAO = new ChienDAO();
                maitre = new Maitre(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                // Ajout du maître en cours au chien
                maitre.Chiens = chienDAO.GetAllByMaster(maitre);
                
            }

            return maitre;

        }

        public override Maitre Save(Maitre element)
        {
            request = "INSERT INTO maitre (prenom, nom) OUTPUT INSERTED.ID VALUES (@prenom, @nom);"; 
            // OUTPUT INSERTED.ID ou à la fin "SELECT CAST(SCOPE_IDENTITY() AS INT)"

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@prenom", element.Prenom);
            command.Parameters.AddWithValue("@nom", element.Nom);

            connection.Open();

            element.Id = (int) command.ExecuteScalar();

            element.Chiens.ForEach(chien =>
            {
                ChienDAO chienDAO = new();
                chien.Maitre = element;

                // On change l'id du maître si le chien existe déjà
                if (chien.Id > 0)
                {
                    chien = chienDAO.Update(chien);
                } 
                else
                {
                    // On ajoute le nouveau chien à la base de données
                    chien = chienDAO.Save(chien);
                }
            });

            return element;

        }

        public override Maitre Update(Maitre element)
        {
            throw new NotImplementedException();
        }
    }
}
