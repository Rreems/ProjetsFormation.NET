using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exo01_.Entities
{
    public class Hamster
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Le nom est requis")]
        [Display(Name = "Prenom")]
        [StringLength(200)]
        [Column("first_name")]
        [RegularExpression(@"^[A-Z]*$", ErrorMessage ="Nom inccorect (CAPLOCK requis)")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "Le prenom est requis")]
        [Display(Name = "Nom")]
        [StringLength(200)]
        [Column("last_name")]
        [RegularExpression(@"^[A-Za-z]*$", ErrorMessage ="Prénom inccorect")]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "Le genre est requis")]
        [Display(Name = "Genre")]
        [StringLength(1, ErrorMessage="Le genre doit faire 1 caractère, F, M ou N.")]
        [Column("gender")]
        [RegularExpression(@"^[A-Z]*$" , ErrorMessage= "Le genre doit être F, M ou N")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "La date de naissance est requise")]
        [Display(Name = "Date de naissance")]
        [Column("birth_date")]
        [Range(typeof(DateOnly), "1910-01-01" , "9999-12-31", ErrorMessage ="La date est hors limites.")]
        public DateOnly BirthDate { get; set; }

        [Display(Name = "Nom entier")]
        public string fullName => FirstName +" "+ LastName;
        public int age => DateOnly.FromDateTime(DateTime.Now).Year - BirthDate.Year;

        [Display(Name = "Numéro de téléphone")]
        [StringLength(100)]
        [Column("number")]
        public string? Number { get; set; }

        [Display(Name = "Adresse Email")]
        [StringLength(100)]
        [Column("email")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"
        , ErrorMessage= "L'email est incorrect")]
        public string? Email { get; set; }
    }

}
