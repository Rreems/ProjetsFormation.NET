using Exercice.Movies.Data.Data;
using Exercice.Movies.Data.Entities;
using Exercice.Movies.Data.Interfaces;

namespace Exercice.Movies.Data.Repositories;

public class MovieRepository : BaseRepository, IRepository<Movie>
{
    public MovieRepository(ApplicationDbContext context) : base(context)
    {
    }

    public IEnumerable<Movie> GetAll()
    {
        return _context.Movies.ToHashSet();
    }

    public Movie? GetById(Guid id)
    {
        return _context.Movies.FirstOrDefault(x => x.Id == id);
    }

    public Movie Add(Movie entity)
    {
        _context.Movies.Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public Movie? Update(Movie entity)
    {
        var found = _context.Movies.FirstOrDefault(x => x.Id == entity.Id);
        if (found == null) return null;
        found.Title = entity.Title;
        found.Description = entity.Description;
        found.Director = entity.Director;
        found.ReleaseDate = entity.ReleaseDate;
        found.Genre = entity.Genre;
        found.IsWatched = entity.IsWatched;
        found.PictureUrl = entity.PictureUrl ?? found.PictureUrl;
        _context.SaveChanges();
        return found;
    }

    public bool Delete(Guid id)
    {
        var found = _context.Movies.FirstOrDefault(x => x.Id == id);
        if (found == null) return false;
        _context.Movies.Remove(found);
        _context.SaveChanges();
        return true;
    }
}