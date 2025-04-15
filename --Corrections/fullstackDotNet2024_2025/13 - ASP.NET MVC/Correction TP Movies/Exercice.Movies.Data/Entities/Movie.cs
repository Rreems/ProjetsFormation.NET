using System.ComponentModel.DataAnnotations;

namespace Exercice.Movies.Data.Entities;

public class Movie
{
    [Key]
    public Guid Id { get; set; }
    
    [StringLength(200)]
    public required string Title { get; set; }
    
    [StringLength(1000)]
    public required string Description { get; set; }
    
    [StringLength(200)]
    public required string Director { get; set; }
    
    public DateOnly? ReleaseDate { get; set; }
    public bool IsWatched { get; set; }
    
    public MovieGenre Genre { get; set; }
    
    [StringLength(200)]
    public string? PictureUrl { get; set; }
}