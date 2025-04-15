using Exercice.Movies.WebApp.Models;

namespace Exercice.Movies.WebApp.Services;

public interface IMovieService
{
    public HashSet<MovieViewModel> GetAll();
    public MovieViewModel? GetById(Guid id);
    public bool SwitchStatus(Guid id);
    public MovieCreateViewModel? GetFormViewModelById(Guid id);
    public MovieEditDeleteViewModel? GetEditableFormViewModelById(Guid id);
    public MovieViewModel Add(MovieCreateViewModel vm);
    public MovieViewModel? Update(MovieEditDeleteViewModel vm);
    public bool Delete(MovieEditDeleteViewModel vm);
}