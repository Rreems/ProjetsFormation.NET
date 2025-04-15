using PizzApi.Data;
using PizzApi.Helpers;
using Microsoft.EntityFrameworkCore;
using PizzApi.Models.Users;

namespace PizzApi.Services
{
    public class FirstRunService : IHostedService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly Encryptor _encryptor;

        public FirstRunService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
            _encryptor = new Encryptor(/*appSettings.Value.SecretKey!*/);
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            await dbContext.Database.MigrateAsync(cancellationToken);

            var pizzaiolo = await dbContext.Pizzaiolos.FirstOrDefaultAsync();
            if (pizzaiolo == null)
            {
                pizzaiolo = new Pizzaiolo
                {
                    Email = "root-pizzaiolo@pizzapi.com",
                    Password = _encryptor.EncryptPassword("P@ssWord!12")
                };

                // Ajoute l'administrateur racine à la base de données
                await dbContext.Pizzaiolos.AddAsync(pizzaiolo);
                if (await dbContext.SaveChangesAsync() <= 0)
                {
                    throw new InvalidOperationException("Root Admin could not be created");
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}

