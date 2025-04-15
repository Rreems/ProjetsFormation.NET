using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverAddress = Environment.GetEnvironmentVariable("DB_HOST");
            var databaseName = Environment.GetEnvironmentVariable("DB_NAME");
            var username = Environment.GetEnvironmentVariable("DB_USER");
            var password = Environment.GetEnvironmentVariable("DB_PASSWORD");

            var connectionString = $"Server={serverAddress};Database={databaseName};Uid={username};Pwd={password};";

            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(9, 0)));
        }
    }
}
