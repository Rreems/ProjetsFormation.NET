using System.ComponentModel.DataAnnotations;

namespace PizzApi.Models.Users
{
    public class Client : UserBase
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? Address { get; set; }
    }
}
