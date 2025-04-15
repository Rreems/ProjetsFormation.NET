using Exo01Contacts.Models;

namespace Exo01Contacts.Services
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetAll(string? firstName = null, string? lastName = null, string? phoneNumber = null, string? email = null);
        Task<Contact?> GetById(int id);
        Task<Contact?> GetByLastName(string lastName);
        Task<Contact> Create(Contact contact);
        Task<Contact> Update(int id, Contact contact);
        Task Delete(int id);
    }
}
