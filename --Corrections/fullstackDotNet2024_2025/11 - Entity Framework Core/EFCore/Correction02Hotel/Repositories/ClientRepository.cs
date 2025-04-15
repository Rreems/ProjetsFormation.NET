using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Correction02Hotel.Data;
using Correction02Hotel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Correction02Hotel.Repositories;

internal class ClientRepository : IRepository<Client, int>
{
    private readonly ApplicationDbContext _db;

    public ClientRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public Client? Add(Client client)
    {
        EntityEntry<Client> clientEntity = _db.Add(client);
        _db.SaveChanges();

        return clientEntity.Entity;
    }

    public Client? GetById(int identifiant)
    {
        return _db.Clients
                  .Include(c => c.Reservations)
                  .FirstOrDefault(e => e.Identifiant == identifiant);
    }

    public Client? Get(Func<Client, bool> predicate)
    {
        return _db.Clients
                  .Include(c => c.Reservations)
                  .FirstOrDefault(predicate);
    }

    public IEnumerable<Client> GetAll()
    {
        return _db.Clients;
    }

    public IEnumerable<Client> GetAll(Func<Client, bool> predicate)
    {
        return _db.Clients.Where(predicate);
    }

    public Client? Update(int identifiant, Client client)
    {
        var clientFromDb = GetById(identifiant);

        if (clientFromDb is null)
            return null;

        if (clientFromDb.Nom  == client.Nom)
            clientFromDb.Nom = client.Nom;
        if (clientFromDb.Prenom == client.Prenom)
            clientFromDb.Prenom= client.Prenom;
        if (clientFromDb.Telephone == client.Telephone)
            clientFromDb.Telephone= client.Telephone;

        return clientFromDb;
    }

    public bool Delete(int identifiant)
    {
        var client = GetById(identifiant);

        if (client is null)
            return false;

        _db.Clients.Remove(client);

        return _db.SaveChanges() == 1;
    }
}
