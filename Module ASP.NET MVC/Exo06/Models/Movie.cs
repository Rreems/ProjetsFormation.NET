using System.ComponentModel.DataAnnotations;

namespace Exo06.Models;

public class Movie
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Display(Name = "Nom")]
    [StringLength(200)]
    public string Nom { get; set; } = "NomDeFilmLambda";



    [Required]
    [Display(Name = "Genre de film")]
    [StringLength(200)]
    public string Genre { get; set; } = null!;

    [Required]
    [Display(Name = "Durée")]
    [Range(0, 600)]
    public int Duree { get; set; } = 0;

    [Required]
    [Display(Name = "Réalisateur")]
    [StringLength(200)]
    public string Realisateur { get; set; } = null!;

    [Required]
    [Display(Name = "Statut")]
    public string Statut { get; set; } = "A voir";

}
//Nom
//Genre
//Duree
//Realisateur
//Statut