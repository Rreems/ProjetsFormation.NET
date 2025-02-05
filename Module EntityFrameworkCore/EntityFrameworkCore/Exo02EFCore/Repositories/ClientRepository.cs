using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exo01EFCore.Data;
using Exo02EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Exo02EFCore.Repositories;

internal class ClientRepository : IRepository<Client, int>
{

    private readonly AppDbContext _db;

    public ClientRepository(AppDbContext context)
    {
        _db = context;
    }

    public Client Add(Client entity)
    {
        EntityEntry<Client> client = _db.Add(entity);
        _db.SaveChanges();
        return client.Entity;
    }

    public IEnumerable<Client> GetAll()
    {
        return _db.Clients;
    }

    public Client? GetById(int id)
    {
        return _db.Clients
                            //.Include(p => p.PersoTags) -> récup de chaque relation / liste des objets relations 
                            // .ThenInclude ( " " " )  -> include des listes des objets du 1e Include
                            .FirstOrDefault(c => c.Id == id);

        //return _db.Clients.Find(id);   // Existe aussi, sans LINQ
    }


    public Client? Get(Func<Client, bool> predicate)
    {
        return _db.Clients
                            .FirstOrDefault(predicate);
    }

    public IEnumerable<Client> GetAll(Func<Client, bool> predicate)
    {
        return _db.Clients.Where(predicate);
    }

    //public Client GetAll(Func<Client, bool> predicate)
    //{
    //    return _db.Clients.Where(predicate);
    //}

    public Client? Update(int id, Client Client)
    {
        var ClientFromDb = GetById(id);

        if (ClientFromDb is null)
        {
            return null;
        }

        // Vérifications si chaque champ est modifié -> ne met à jour que les nécessaires
        if (ClientFromDb.Id != Client.Id)
        {
            ClientFromDb.Id = Client.Id;
        }
        if (ClientFromDb.Nom != Client.Nom )
        {
            ClientFromDb.Nom = Client.Nom ;
        }
        if (ClientFromDb.Prenom != Client.Prenom )
        {
            ClientFromDb.Prenom = Client.Prenom ;
        }
        if (ClientFromDb.NumeroTelephone != Client.NumeroTelephone )
        {
            ClientFromDb.NumeroTelephone = Client.NumeroTelephone ;
        }

        _db.SaveChanges();
        return ClientFromDb;
    }


    public void Delete(Client entity) // Obsolete
    {
        _db.Clients.Remove(entity);
    }

    public bool Delete(int id)
    {
        var Client = GetById(id);
        if (Client is null)
        {
            return false;
        }
        _db.Clients.Remove(Client);

        return _db.SaveChanges() == 1;
    }

    public void Save()
    {
        _db.SaveChanges();
    }
}