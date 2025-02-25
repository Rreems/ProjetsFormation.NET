using System.ComponentModel.DataAnnotations;

namespace Exo02_R_API_Tatouille.DTOs.Authentification;

public class LoginRequestDTO
{
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }
}
