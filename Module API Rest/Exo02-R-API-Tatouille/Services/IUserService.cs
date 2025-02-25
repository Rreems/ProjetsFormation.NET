using Exo02_R_API_Tatouille.DTOs;
using Exo02_R_API_Tatouille.DTOs.Authentification;
using Exo02_R_API_Tatouille.Models;

namespace Exo02_R_API_Tatouille.Services;

public interface IUserService
{
    Task<IEnumerable<User>> GetAll(string? firstName = null, string? lastName = null, string? phoneNumber = null, string? email = null);
    Task<User?> GetById(int id);
    Task<User> Create(User User);
    Task<User> Update(int id, User User);
    Task Delete(int id);

}
