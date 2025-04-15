using AutoMapper;
using ContactWithDtos.DTOs;
using ContactWithDtos.Exceptions;
using ContactWithDtos.Models;
using ContactWithDtos.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace ContactWithDtos.Services
{
    public class ContactService : IContactService
    {
        private readonly IRepository<Contact, int> _contactRepository;
        private readonly IMapper _mapper;

        public ContactService(IRepository<Contact,int> contactRepository,
                              IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContactDTO>> GetAll(string? firstName = null, string? lastName = null, string? phoneNumber = null, string? email = null)
        {
            return _mapper.Map</*IEnumerable<Contact>,*/IEnumerable<ContactDTO>>(
                await _contactRepository.GetAll(c => 
                    (firstName.IsNullOrEmpty() || c.FirstName.Contains(firstName!)) &&
                    (lastName.IsNullOrEmpty() || c.LastName.Contains(lastName!)) &&
                    (phoneNumber.IsNullOrEmpty() || c.PhoneNumber!.Contains(phoneNumber!)) &&
                    (email.IsNullOrEmpty() || c.Email!.Contains(email!))
                ));
            
        }

        public async Task<ContactDTO?> GetById(int id) => _mapper.Map<ContactDTO?>(await _contactRepository.GetById(id));

        public async Task<ContactDTO?> GetByLastName(string lastName) => _mapper.Map<ContactDTO?>(await _contactRepository.Get(c => c.LastName.Contains(lastName))); // /!\ en cas de duplicas de nom de famille => lever une exception ou autre ...

        public async Task<ContactDTO> Create(ContactDTO contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);
            try
            {
                return _mapper.Map<ContactDTO>(await _contactRepository.Add(contact));
            }
            catch (Exception e)
            {
                // Ajout du Logging de l'erreur rencontrée
                Console.WriteLine($"Erreur d'ajout pour le contact nommé {contactDto.FullName}: {e.Message}");
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public async Task<ContactDTO> Update(int id, ContactDTO contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);
            try
            {
                contact.Id = id;
                return _mapper.Map<ContactDTO>(await _contactRepository.Update(contact)) ?? throw new NotFoundException($"Contact avec l'id {id} non trouvé.");
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
