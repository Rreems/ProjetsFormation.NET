using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exo02_R_API_Tatouille.Models;

[Table("ingredient")]
public class Ingredient
{
    [Column("id")]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Column("name")]
    [Required(ErrorMessage = "Le nom est requis.")]
    [StringLength(100, ErrorMessage = "Le nom fait au maximum {1} caractères.")]
    public string Name { get; set; } = string.Empty;

    [Column("description")]
    [Required(ErrorMessage = "La description de la ratatouille est requise.")]
    [StringLength(800, ErrorMessage = "Le prénom fait au maximum {1} caractères.")]
    public string FirstName { get; set; } = string.Empty;


    [ForeignKey(nameof(Ratatouille))]
    public string RatatouilleId { get; set; }
}
