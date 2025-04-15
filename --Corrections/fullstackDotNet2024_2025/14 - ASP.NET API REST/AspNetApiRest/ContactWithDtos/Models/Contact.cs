using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ContactWithDtos.Models
{
    [Table("contacts")]
    public class Contact
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("last_name")]
        [Required(ErrorMessage = "Le nom est requis.")]
        [StringLength(30, ErrorMessage = "Le nom fait au maximum {1} caractères.")]
        public string LastName { get; set; } = string.Empty;

        [Column("first_name")]
        [Required(ErrorMessage = "Le prenom est requis.")]
        [StringLength(30, ErrorMessage = "Le prénom fait au maximum {1} caractères.")]
        public string FirstName { get; set; } = string.Empty;

        [Column("gender")]
        [Required(ErrorMessage = "Le genre est requis.")]
        [StringLength(1, ErrorMessage = "Le genre fait exactement {1} caractères.")]
        public string Gender { get; set; } = string.Empty;

        [Column("birth_date")]
        [Required(ErrorMessage = "La date de naissance est requise.")]
        public DateOnly BirthDate { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("phone")]
        public string? PhoneNumber { get; set; }
    }
}
