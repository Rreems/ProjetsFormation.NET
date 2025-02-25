using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Exo02_R_API_Tatouille.Models;

[Table("ratatouille")]
public class Ratatouille
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
    public string Description { get; set; } = string.Empty;

    [Column("prix")]
    [Precision (14,2)]
    [Required(ErrorMessage = "Le prix est requis.")]
    public decimal Price { get; set; } 

    [Column("est_vegetarienne")]
    public bool IsVeggie { get; set; } = false;

    [Column("est_piquante")]
    public bool IsSpicy { get; set; } = false;


    public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

}