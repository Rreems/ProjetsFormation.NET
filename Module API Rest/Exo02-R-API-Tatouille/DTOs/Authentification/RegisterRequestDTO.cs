using System.ComponentModel.DataAnnotations;
using Exo02_R_API_Tatouille.Helpers;
using Exo02_R_API_Tatouille.Validator;

namespace Exo02_R_API_Tatouille.DTOs.Authentification;

public class RegisterRequestDTO
{
    // le Data Transfert Object sert à transférer de la donnée
    // il peut être une version modifiée d'un model ou une nouvelle classe 
    // il est dédié à l'interraction avec l'API
    // on y retrouve des data annotations liée à la validation par exemple

    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Email is invalid")]
    public string? Email { get; set; }


    [DataType(DataType.Password)]
    [PasswordValidator]
    public string? Password { get; set; }


    [Required(ErrorMessage = "Le rôle est requis.")]
    public string Role { get; set; } = Constants.RoleUser;


    [Required(ErrorMessage = "Le nom est requis.")]
    [StringLength(30, MinimumLength = 5, ErrorMessage = "Le nom fait au maximum {1} caractères.")]
    public string LastName { get; set; } = string.Empty;


    [Required(ErrorMessage = "Le prenom est requis.")]
    [StringLength(30, ErrorMessage = "Le prénom fait au maximum {1} caractères.")]
    [RegularExpression(@"^[A-Z][A-Za-z\- ]*$", ErrorMessage = "Le prénom doit commencer par une majuscule.")]
    public string FirstName { get; set; } = string.Empty;
}
