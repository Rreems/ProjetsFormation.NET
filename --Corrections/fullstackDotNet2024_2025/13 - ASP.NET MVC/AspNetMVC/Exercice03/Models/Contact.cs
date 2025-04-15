using System.ComponentModel.DataAnnotations;

namespace Exercice03.Models
{
    public class Contact
    {
        [Key]
        public long Id { get; set; } = 1L;
        [Required]
        [Display(Name = "Prénom")]
        public string FirstName { get; set; } = "John";
        [Required]
        [Display(Name = "Nom")]

        public string LastName { get; set; } = "DUPONT";
        [Display(Name = "Email")]

        public string? Email { get; set; }
        [Display(Name = "Numéro de téléphone")]

        public string? PhoneNumber { get; set; }

    }
}
