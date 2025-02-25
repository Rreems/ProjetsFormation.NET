using System.ComponentModel.DataAnnotations;
using Exo02_R_API_Tatouille.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Exo02_R_API_Tatouille.DTOs;

public class RatatouilleDTO
{
    // le Data Transfert Object sert à transférer de la donnée
    // il peut être une version modifiée d'un model ou une nouvelle classe 
    // il est dédié à l'interraction avec l'API
    // on y retrouve des data annotations liée à la validation par exemple
    [JsonIgnore]
    public string Id { get; set; }

    [Column("name")]
    [Required(ErrorMessage = "Le nom est requis.")]
    [StringLength(100, ErrorMessage = "Le nom fait au maximum {1} caractères.")]
    public string Name { get; set; } = string.Empty;

    [Column("description")]
    [Required(ErrorMessage = "La description de la ratatouille est requise.")]
    [StringLength(800, ErrorMessage = "Le prénom fait au maximum {1} caractères.")]
    public string Description { get; set; } = string.Empty;

    [Column("prix")]
    [Precision(14, 2)]
    [Required(ErrorMessage = "Le prix est requis.")]
    public decimal Price { get; set; }

    [Column("est_vegetarienne")]
    public bool IsVeggie { get; set; } = false;

    [Column("est_piquante")]
    public bool IsSpicy { get; set; } = false;


    [JsonIgnore]
    public List<Ingredient> Ingredients;

}
