using Exercice03.Data;
using Microsoft.EntityFrameworkCore;

namespace Exercice03.Extensions
{
    public static class MyExtensions
    {
        public static void DependencyInjection(this WebApplicationBuilder builder)
        {
            var dbHostname = Environment.GetEnvironmentVariable("DB_HOSTNAME") ?? "m2idbserver.database.windows.net";
            var dbName = Environment.GetEnvironmentVariable("DB_NAME") ?? "ExerciceDb";
            var dbUsername = Environment.GetEnvironmentVariable("DB_USERNAME") ?? "serveradmin";
            var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "Pa$$w0rd";

            var connectionString = $"Server=tcp:{dbHostname},1433;Initial Catalog={dbName};Persist Security Info=False;User ID={dbUsername};Password={dbPassword};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            builder.Services.AddDbContext<ApplicationDbContext>(options 
                => options.UseSqlServer(connectionString)
            );
        }
    }
}
