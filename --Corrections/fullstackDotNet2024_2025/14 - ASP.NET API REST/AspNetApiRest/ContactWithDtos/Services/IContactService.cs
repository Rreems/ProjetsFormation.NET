using ContactWithDtos.DTOs;

namespace ContactWithDtos.Services
{
    public interface IContactService
    {
        Task<IEnumerable<ContactDTO>> GetAll(string? firstName = null, string? lastName = null, string? phoneNumber = null, string? email = null);
        Task<ContactDTO?> GetById(int id);
        Task<ContactDTO?> GetByLastName(string lastName);
        Task<ContactDTO> Create(ContactDTO contactDto);
        Task<ContactDTO> Update(int id, ContactDTO contactDto);
        Task Delete(int id);
    }
}
