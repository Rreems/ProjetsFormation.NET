using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exo01_.Entities
{
    public class Hamster
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Prenom")]
        [StringLength(200)]
        [Column("TODO ")]
        public required string FirstName { get; set; }

        [Required]
        [Display(Name = "Nom")]
        [StringLength(200)]
        public required string LastName { get; set; }

        [Required]
        [Display(Name = "Genre")]
        [StringLength(100)]
        public string? Gender { get; set; }

        [Required]
        [Display(Name = "Date de naissance")]
        public DateOnly BirthDate { get; set; }

        [Display(Name = "Nom entier")]
        public string fullName => FirstName + LastName;
        public int age => DateOnly.FromDateTime(DateTime.Now).Year - BirthDate.Year;


        public string 
    }

}
