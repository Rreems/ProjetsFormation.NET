
using IdentityProvider.Data;
using IdentityProvider.Helpers;
using IdentityProvider.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace IdentityProvider.Services;
public class FirstRunService : IHostedService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly Encryptor _encryptor;

    public FirstRunService(IServiceScopeFactory scopeFactory, IOptions<AppSettings> appSettings)
    {
        _scopeFactory = scopeFactory;
        _encryptor = new Encryptor(/*appSettings.Value.SecretKey!*/);
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _scopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        // Applique les migrations automatiques au démarrage
        await dbContext.Database.MigrateAsync(cancellationToken);

        // Vérifie s'il existe déjà un administrateur
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.IsAdmin, cancellationToken);
        if (user == null)
        {
            user = new User
            {
                Email = "admin@admin.com",
                IsAdmin = true,
                Password = _encryptor.EncryptPassword("P@ssWord!12"),
                CreatedAt = DateTime.UtcNow,
                CreatedBy = null
            };

            // Ajoute l'administrateur racine à la base de données
            await dbContext.Users.AddAsync(user, cancellationToken);
            if (await dbContext.SaveChangesAsync(cancellationToken) <= 0)
            {
                throw new Exception("Root Admin could not be created");
            }
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
