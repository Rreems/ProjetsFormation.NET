using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.Data.SqlClient;

namespace Demo02Dao.Dao
{
    internal class DataConnection
    {
        private static readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB; Integrated Security=True; Database=SPADB";

        public static SqlConnection GetConnection => new(connectionString); 
    }
}
