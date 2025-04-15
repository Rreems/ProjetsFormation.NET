using System.ComponentModel.DataAnnotations;
using PizzApi.Validators;

namespace PizzApi.DTOs.Auth.Pizzaiolos
{
    public class PizzaioloRegisterRequestDTO
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is invalid")]
        public string? Email { get; set; }
        [DataType(DataType.Password)]
        [PasswordValidator]
        public string? Password { get; set; }
    }
}
