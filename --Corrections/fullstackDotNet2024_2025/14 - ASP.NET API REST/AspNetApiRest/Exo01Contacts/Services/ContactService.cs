using Exo01Contacts.Exceptions;
using Exo01Contacts.Models;
using Exo01Contacts.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace Exo01Contacts.Services
{
    public class ContactService : IContactService
    {
        private readonly IRepository<Contact, int> _contactRepository;

        public ContactService(IRepository<Contact,int> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<IEnumerable<Contact>> GetAll(string? firstName = null, string? lastName = null, string? phoneNumber = null, string? email = null)
        {
            return await _contactRepository.GetAll(c => 
                (firstName.IsNullOrEmpty() || c.FirstName.Contains(firstName!)) &&
                (lastName.IsNullOrEmpty() || c.LastName.Contains(lastName!)) &&
                (phoneNumber.IsNullOrEmpty() || c.PhoneNumber!.Contains(phoneNumber!)) &&
                (email.IsNullOrEmpty() || c.Email!.Contains(email!))
                );
        }

        public async Task<Contact?> GetById(int id) => await _contactRepository.GetById(id);

        public async Task<Contact?> GetByLastName(string lastName) => await _contactRepository.Get(c => c.LastName.Contains(lastName)); // /!\ en cas de duplicas de nom de famille => lever une exception ou autre ...

        public async Task<Contact> Create(Contact contact)
        {
            try
            {
                return await _contactRepository.Add(contact);
            }
            catch (Exception e)
            {
                // Ajout du Logging de l'erreur rencontrée
                Console.WriteLine($"Erreur d'ajout pour le contact nommé {contact.FullName}: {e.Message}");
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public async Task<Contact> Update(int id, Contact contact)
        {
            try
            {
                contact.Id = id;
                return await _contactRepository.Update(contact) ?? throw new NotFoundException($"Contact avec l'id {id} non trouvé.");
            }
            catch (Exception e)
            {
                // Ajout du Logging de l'erreur rencontrée
                Console.WriteLine($"Erreur de modification pour le contact avec l'id {id}: {e.Message}");
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                if(!await _contactRepository.Delete(id))
                    throw new NotFoundException($"Contact avec l'id {id} non trouvé.");
            }
            catch (Exception e)
            {
                // Ajout du Logging de l'erreur rencontrée
                Console.WriteLine($"Erreur de modification pour le contact avec l'id {id}: {e.Message}");
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }
    }
}
