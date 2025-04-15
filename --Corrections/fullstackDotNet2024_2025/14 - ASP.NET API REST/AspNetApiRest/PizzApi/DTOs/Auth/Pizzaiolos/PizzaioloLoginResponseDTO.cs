using PizzApi.Models.Users;

namespace PizzApi.DTOs.Auth.Pizzaiolos
{
    public class PizzaioloLoginResponseDTO
    {
        public bool IsSuccessful { get; set; }
        public string? ErrorMessage { get; set; }
        public Pizzaiolo? Pizzaiolo { get; set; }
        public string? Token { get; set; }
    }
}
