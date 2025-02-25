using Exo02_R_API_Tatouille.DTOs;
using Exo02_R_API_Tatouille.DTOs.Authentification;

namespace Exo02_R_API_Tatouille.Services;

public interface IAuthenticationService
{
    Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
    Task<RegisterResponseDTO> Register(RegisterRequestDTO registerRequestDTO, string userClaimRole, string userClaimId);
}
