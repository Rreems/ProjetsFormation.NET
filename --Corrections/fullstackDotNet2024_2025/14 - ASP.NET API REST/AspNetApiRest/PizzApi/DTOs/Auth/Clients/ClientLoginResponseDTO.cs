using PizzApi.Models.Users;

namespace PizzApi.DTOs.Auth.Clients
{
    public class ClientLoginResponseDTO
    {
        public bool IsSuccessful { get; set; }
        public string? ErrorMessage { get; set; }
        public Client? Client { get; set; }
        public string? Token { get; set; }
    }
}
