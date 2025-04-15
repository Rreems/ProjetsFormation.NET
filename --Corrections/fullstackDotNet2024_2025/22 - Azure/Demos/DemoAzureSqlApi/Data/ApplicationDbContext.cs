using DemoAzureSqlApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoAzureSqlApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Cat> Cats { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbHostname = Environment.GetEnvironmentVariable("DB_HOSTNAME") ?? "<server-name>.database.windows.net";
            var dbName = Environment.GetEnvironmentVariable("DB_NAME") ?? "<db-name>";
            var dbUsername = Environment.GetEnvironmentVariable("DB_USERNAME") ?? "<username>";
            var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "<password>";

            var connectionString = $"Server=tcp:{dbHostname},1433;Initial Catalog={dbName};Persist Security Info=False;User ID={dbUsername};Password={dbPassword};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
