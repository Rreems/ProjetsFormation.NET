using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Correction02Commande.DAO
{
    internal class DataConnection
    {
        private static readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB; Integrated Security=True; Database=ECommerce";

        public static SqlConnection GetConnection { get => new(connectionString); }
    }
}
