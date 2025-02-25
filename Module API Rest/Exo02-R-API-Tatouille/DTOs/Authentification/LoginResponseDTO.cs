using Exo02_R_API_Tatouille.Models;

namespace Exo02_R_API_Tatouille.DTOs.Authentification;

public class LoginResponseDTO
{
    public bool IsSuccessful { get; set; }
    public string? ErrorMessage { get; set; }
    public User? User { get; set; }
    public string? Token { get; set; }
}
