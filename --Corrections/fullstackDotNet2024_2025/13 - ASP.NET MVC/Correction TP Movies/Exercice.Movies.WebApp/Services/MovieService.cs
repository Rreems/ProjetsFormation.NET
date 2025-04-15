using Exercice.Movies.Data.Entities;
using Exercice.Movies.Data.Interfaces;
using Exercice.Movies.WebApp.Models;

namespace Exercice.Movies.WebApp.Services;

public class MovieService : IMovieService
{
    private readonly IRepository<Movie> _repository;
    private readonly IUploadPictureService _uploadPictureService;
    
    public MovieService(IRepository<Movie> repository, IUploadPictureService uploadPictureService)
    {
        _repository = repository;
        _uploadPictureService = uploadPictureService;
    }
    
    public HashSet<MovieViewModel> GetAll()
    {
        return _repository.GetAll().Select(MapToViewModel).ToHashSet();
    }

    public MovieViewModel? GetById(Guid id)
    {
        var movie = _repository.GetById(id);
        if (movie == null) return null;
        return MapToViewModel(movie);
    }

    public MovieCreateViewModel? GetFormViewModelById(Guid id)
    {
        var movie = _repository.GetById(id);
        if (movie == null) return null;
        return MapToFormViewModel(movie);
    }

    public MovieEditDeleteViewModel? GetEditableFormViewModelById(Guid id)
    {
        var movie = _repository.GetById(id);
        if (movie == null) return null;
        return MapToEditableFormViewModel(movie);
    }

    public MovieViewModel Add(MovieCreateViewModel vm)
    {
        var movie = MapToEntity(vm);
        Console.WriteLine(movie.PictureUrl);
        return MapToViewModel(_repository.Add(movie));
    }

    public bool SwitchStatus(Guid id)
    {
        var movie = _repository.GetById(id);
        if (movie == null) return false;
        movie.IsWatched = !movie.IsWatched;
        return _repository.Update(movie) != null;
    }

    public MovieViewModel? Update(MovieEditDeleteViewModel vm)
    {
        var movie = MapToEntity(vm);
        var updatedMovie = _repository.Update(movie);
        if (updatedMovie == null) return null;
        return MapToViewModel(updatedMovie);
    }

    public bool Delete(MovieEditDeleteViewModel vm)
    {
        return _repository.Delete(vm.Id);
    }
    
    private MovieViewModel MapToViewModel(Movie movie)
    {
        return new MovieViewModel()
        {
            Id = movie.Id,
            Title = movie.Title,
            Description = movie.Description,
            Director = movie.Director,
            ReleaseDate = movie.ReleaseDate,
            Genre = movie.Genre,
            IsWatched = movie.IsWatched,
            PictureUrl = movie.PictureUrl
        };
    }
    
    private MovieCreateViewModel MapToFormViewModel(Movie movie)
    {
        return new MovieCreateViewModel()
        {
            Title = movie.Title,
            Description = movie.Description,
            Director = movie.Director,
            ReleaseDate = movie.ReleaseDate,
            Genre = movie.Genre
        };
    }

    private MovieEditDeleteViewModel MapToEditableFormViewModel(Movie movie)
    {
        return new MovieEditDeleteViewModel()
        {
            Id = movie.Id,
            Title = movie.Title,
            Description = movie.Description,
            Director = movie.Director,
            ReleaseDate = movie.ReleaseDate,
            Genre = movie.Genre
        };
    }


    private Movie MapToEntity(MovieCreateViewModel movie)
    {
        return new Movie()
        {
            Id = movie is MovieEditDeleteViewModel ? ((MovieEditDeleteViewModel)movie).Id : Guid.Empty,
            Title = movie.Title,
            Description = movie.Description,
            Director = movie.Director,
            ReleaseDate = movie.ReleaseDate,
            Genre = movie.Genre,
            PictureUrl = _uploadPictureService.Upload(movie.Picture)
        };
    }
}