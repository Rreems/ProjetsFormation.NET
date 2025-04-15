using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Extensions
{
    public static class MyExtensions
    {
        public static void ApplyMigration(this  WebApplication app)
        {
            // On récupère le scope de l'ensemble des services ajoutés à notre programme
            using var scope = app.Services.CreateScope();

            // On demande le service concernant le DBContext
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            // On obtient la liste des migrations non effectuées
            var pendingMigrations = dbContext.Database.GetPendingMigrations();

            // Si on en a...
            if (pendingMigrations.Any())
            {
                // On réalise les migrations
                dbContext.Database.Migrate();
            }
        }
    }
}
