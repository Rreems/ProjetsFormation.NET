using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using PizzApi.Validators;

namespace PizzApi.Models.Users
{
    public abstract class UserBase
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [PasswordValidator]
        [JsonIgnore]
        public string? Password { get; set; }
    }
}
