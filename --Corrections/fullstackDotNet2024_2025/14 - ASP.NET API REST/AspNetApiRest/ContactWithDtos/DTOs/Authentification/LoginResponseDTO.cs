using ContactWithDtos.Models;

namespace ContactWithDtos.DTOs.Authentification
{
    public class LoginResponseDTO
    {
        public bool IsSuccessful { get; set; }
        public string? ErrorMessage { get; set; }
        public User? User { get; set; }
        public string? Token { get; set; }
    }
}
