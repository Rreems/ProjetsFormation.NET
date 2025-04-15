using Exercice.Movies.Data.Entities;

namespace Exercice.Movies.WebApp.Models;

public class MovieViewModel
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string Director { get; set; }
    public DateOnly? ReleaseDate { get; set; }
    public MovieGenre Genre { get; set; }
    public bool IsWatched { get; set; }
    public bool IsFavorite { get; set; }
    public string? PictureUrl { get; set; }
}