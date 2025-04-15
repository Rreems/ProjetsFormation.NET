using System.ComponentModel.DataAnnotations;
using IdentityProvider.Validators;
using System.Runtime.Serialization;

namespace IdentityProvider.DTOs
{
    public class RegisterRequestDTO
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is invalid")]
        public string? Email { get; set; }
        [DataType(DataType.Password)]
        [PasswordValidator]
        public string? Password { get; set; }
        public bool IsAdmin { get; set; } = false;
    }
}
