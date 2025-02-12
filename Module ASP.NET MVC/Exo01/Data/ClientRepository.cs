using Exo01.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Exo01.Data;


internal class ContactRepository : IRepository<Contact, string>
{

    private readonly AppDbContext _db;

    public ContactRepository(AppDbContext context)
    {
        _db = context;
    }

    public Contact Add(Contact entity)
    {
        EntityEntry<Contact> client = _db.Add(entity);
        _db.SaveChanges();
        return client.Entity;
    }

    public IEnumerable<Contact> GetAll()
    {
        return _db.Contacts;
    }

    public Contact? GetById(string id)
    {
        return _db.Contacts
                            //.Include(p => p.PersoTags) -> récup de chaque relation / liste des objets relations 
                            // .ThenInclude ( " " " )  -> include des listes des objets du 1e Include
                            .FirstOrDefault(c => c.Id == id);

        //return _db.Contacts.Find(id);   // Existe aussi, sans LINQ
    }


    public Contact? Get(Func<Contact, bool> predicate)
    {
        return _db.Contacts
                            .FirstOrDefault(predicate);
    }

    public IEnumerable<Contact> GetAll(Func<Contact, bool> predicate)
    {
        return _db.Contacts.Where(predicate);
    }

    //public Contact GetAll(Func<Contact, bool> predicate)
    //{
    //    return _db.Contacts.Where(predicate);
    //}

    public Contact? Update(string id, Contact Contact)
    {
        var ContactFromDb = GetById(id);

        if (ContactFromDb is null)
        {
            return null;
        }

        // Vérifications si chaque champ est modifié -> ne met à jour que les nécessaires
        if (ContactFromDb.Id != Contact.Id)
        {
            ContactFromDb.Id = Contact.Id;
        }
        if (ContactFromDb.Nom != Contact.Nom)
        {
            ContactFromDb.Nom = Contact.Nom;
        }
        if (ContactFromDb.Prenom != Contact.Prenom)
        {
            ContactFromDb.Prenom = Contact.Prenom;
        }
        if (ContactFromDb.Numero != Contact.Numero)
        {
            ContactFromDb.Numero = Contact.Numero;
        }

        _db.SaveChanges();
        return ContactFromDb;
    }


    public void Delete(Contact entity) // Obsolete
    {
        _db.Contacts.Remove(entity);
    }

    public bool Delete(string id)
    {
        var Contact = GetById(id);
        if (Contact is null)
        {
            return false;
        }
        _db.Contacts.Remove(Contact);

        return _db.SaveChanges() == 1;
    }

    public void Save()
    {
        _db.SaveChanges();
    }
}
