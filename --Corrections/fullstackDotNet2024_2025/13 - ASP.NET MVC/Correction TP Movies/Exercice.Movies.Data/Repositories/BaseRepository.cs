using Exercice.Movies.Data.Data;

namespace Exercice.Movies.Data.Repositories;

public abstract class BaseRepository
{
    protected readonly ApplicationDbContext _context;

    public BaseRepository(ApplicationDbContext context)
    {
        _context = context;
    }
}