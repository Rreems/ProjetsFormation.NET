using IdentityProvider.Models;

namespace IdentityProvider.DTOs
{
    public class RegisterResponseDTO
    {
        public bool IsSuccessful { get; set; }
        public string? ErrorMessage { get; set; }
        public User? User { get; set; }
    }
}
