using ContactWithDtos.Models;

namespace ContactWithDtos.DTOs.Authentification
{
    public class RegisterResponseDTO
    {
        public bool IsSuccessful { get; set; }
        public string? ErrorMessage { get; set; }
        public User? User { get; set; }
    }
}
