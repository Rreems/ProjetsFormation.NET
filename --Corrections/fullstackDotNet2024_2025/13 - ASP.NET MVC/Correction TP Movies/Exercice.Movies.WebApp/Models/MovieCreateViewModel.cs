using Exercice.Movies.Data.Entities;

namespace Exercice.Movies.WebApp.Models;

public class MovieCreateViewModel
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string Director { get; set; }
    public DateOnly? ReleaseDate { get; set; }
    public MovieGenre Genre { get; set; }
    public IFormFile? Picture { get; set; }
}