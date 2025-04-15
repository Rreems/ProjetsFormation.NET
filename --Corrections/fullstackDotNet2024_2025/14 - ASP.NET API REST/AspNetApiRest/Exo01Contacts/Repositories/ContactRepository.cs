using System.Linq.Expressions;
using Exo01Contacts.Data;
using Exo01Contacts.Models;
using Microsoft.EntityFrameworkCore;

namespace Exo01Contacts.Repositories
{
    public class ContactRepository : IRepository<Contact, int>
    {
        private readonly AppDbContext _db;

        public ContactRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Contact> Add(Contact contact)
        {
            await _db.Contacts.AddAsync(contact);
            await _db.SaveChangesAsync();
            return contact;
        }

        public async Task<Contact?> GetById(int id) => await _db.Contacts.FindAsync(id);

        public async Task<Contact?> Get(Expression<Func<Contact, bool>> predicate) => await _db.Contacts.FirstOrDefaultAsync(predicate);

        public async Task<IEnumerable<Contact>> GetAll() => _db.Contacts;

        public async Task<IEnumerable<Contact>> GetAll(Expression<Func<Contact, bool>> predicate) => _db.Contacts.Where(predicate);

        public async Task<Contact?> Update(Contact contact)
        {
            var contactFromDb = await GetById(contact.Id);
            if (contactFromDb is null)
                return null;

            if (contactFromDb.FirstName != contact.FirstName)
                contactFromDb.FirstName = contact.FirstName;
            if (contactFromDb.LastName != contact.LastName)
                contactFromDb.LastName = contact.LastName;
            if (contactFromDb.Gender != contact.Gender)
                contactFromDb.Gender = contact.Gender;
            if (contactFromDb.BirthDate != contact.BirthDate)
                contactFromDb.BirthDate = contact.BirthDate;
            if (contactFromDb.Email != contact.Email)
                contactFromDb.Email = contact.Email;
            if (contactFromDb.PhoneNumber != contact.PhoneNumber)
                contactFromDb.PhoneNumber = contact.PhoneNumber;

            await _db.SaveChangesAsync();
            return contactFromDb;
        }

        public async Task<bool> Delete(int id)
        {
            var contact = await GetById(id);
            if (contact is null)
                return false;

            _db.Contacts.Remove(contact);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
