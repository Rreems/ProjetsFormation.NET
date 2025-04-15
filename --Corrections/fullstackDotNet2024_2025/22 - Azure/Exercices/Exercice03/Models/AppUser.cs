using System.ComponentModel.DataAnnotations;

namespace Exercice03.Models
{
    public class AppUser
    {
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(100)]

        public string Email { get; set; }
        [MaxLength(30)]
        public string PhoneNumber { get; set; }
    }
}
