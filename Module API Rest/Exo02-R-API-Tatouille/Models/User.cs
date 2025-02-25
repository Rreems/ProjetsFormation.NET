using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Exo02_R_API_Tatouille.Helpers;

namespace Exo02_R_API_Tatouille.Models;

[Table("users")]
public class User
{
    [Column("id")]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Column("email")]
    [Required(ErrorMessage = "L'email est requis.")]
    [StringLength(100, ErrorMessage = "L'email fait au maximum {1} caractères.")]
    public string? Email { get; set; }

    [Column("password")]
    [JsonIgnore]
    public string? Password { get; set; } //ici un hash du password


    [Column("first_name")]
    [StringLength(30, ErrorMessage = "Le prénom fait au maximum {1} caractères.")]
    public string? FirstName { get; set; }

    [Column("last_name")]
    [StringLength(30, ErrorMessage = "Le nom fait au maximum {1} caractères.")]
    public string? LastName { get; set; }


    [Column("role")]
    public string Role { get; set; } = Constants.RoleUser; 

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    [Column("created_by")]
    public string? CreatedBy { get; set; }
}