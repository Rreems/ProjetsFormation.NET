using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;
using Exo02_R_API_Tatouille.Helpers;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Exo02_R_API_Tatouille.DTOs;

public class UserDTO
{
    // le Data Transfert Object sert à transférer de la donnée
    // il peut être une version modifiée d'un model ou une nouvelle classe 
    // il est dédié à l'interraction avec l'API
    // on y retrouve des data annotations liée à la validation par exemple
    [JsonIgnore]
    public string Id { get; set; }


    [Required(ErrorMessage = "Le rôle est requis.")]
    public string Role { get; set; } = Constants.RoleUser;


    [Required(ErrorMessage = "Le nom est requis.")]
    [StringLength(30, MinimumLength = 5, ErrorMessage = "Le nom fait au maximum {1} caractères.")]
    [RegularExpression(@"^[A-Z]+$", ErrorMessage = "Le nom doit être en majuscules.")]
    public string LastName { get; set; } = string.Empty;


    [Required(ErrorMessage = "Le prenom est requis.")]
    [StringLength(30, ErrorMessage = "Le prénom fait au maximum {1} caractères.")]
    [RegularExpression(@"^[A-Z][A-Za-z\- ]*$", ErrorMessage = "Le prénom doit commencer par une majuscule.")]
    public string FirstName { get; set; } = string.Empty;


    [EmailAddress(ErrorMessage = "Le format de l'email est invalide.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "La date de création est requise.")]
    [Range(typeof(DateOnly), "1911-01-01", "9999-12-31", ErrorMessage = "Date de création incorrecte.")]
    //[JsonIgnore] 
    public DateTime CreatedAt{ get; set; }

    public string CreatedBy { get; set; }

}
