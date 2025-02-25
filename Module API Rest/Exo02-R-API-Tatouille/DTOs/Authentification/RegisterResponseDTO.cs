using Exo02_R_API_Tatouille.Models;

namespace Exo02_R_API_Tatouille.DTOs.Authentification;

public class RegisterResponseDTO
{
    public bool IsSuccessful { get; set; }
    public string? ErrorMessage { get; set; }
    public User? User { get; set; }
}
