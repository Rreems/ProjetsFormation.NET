using Microsoft.EntityFrameworkCore;
using WebAPI.Data;

namespace WebAPI.Extensions
{
    public static class MyExtentions
    {
        public static void AddDepedencies(this WebApplicationBuilder builder)
        {
            var dbHostname = Environment.GetEnvironmentVariable("DB_HOSTNAME") ?? "localhost";
            var dbName = Environment.GetEnvironmentVariable("DB_NAME") ?? "testdb";
            var dbUser = Environment.GetEnvironmentVariable("DB_USER") ?? "user";
            var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "user-password";

            var connectionString = $"Server={dbHostname}; Database={dbName}; User= {dbUser}; Password={dbPassword};";

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(connectionString, new MySqlServerVersion(new Version(9, 0, 1)))
            );
        }

        public static void ApplyMigrations(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            var pendingMigrations = dbContext.Database.GetPendingMigrations();

            if (pendingMigrations.Any())
            {
                // Update-Database
                dbContext.Database.Migrate();
            }
        }
    }
}
