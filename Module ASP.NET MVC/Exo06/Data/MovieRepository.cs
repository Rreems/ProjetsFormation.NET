using Exo06.Models;

namespace Exo06.Data;

public class MovieRepository : BaseRepository, IRepository<Movie>
{
    public MovieRepository(AppDbContext context) : base(context)
    {
    }

    // On réceptionne une entité sans Id
    public Movie Create(Movie entity)
    {
        _context.Movies.Add(entity); // On ajoute l'entité au DbSet
        _context.SaveChanges(); // On sauvegarde les changement, ce qui ajoute l'Id à notre entité
        return entity; // On retourne l'entité telle qu'elle est désormais en BdD
    }

    // On réceptionne une entité, avec id
    public bool Delete(Movie entity)
    {
        var movieFound = _context.Movies.FirstOrDefault(c => c.Id == entity.Id); // On cherche un film avec le même ID
        if (movieFound == null) return false; // Si l'on en trouve pas, on se stoppe immédiatement
        _context.Movies.Remove(movieFound); // Sinon, on supprime le film
        _context.SaveChanges(); // On sauvegarde la modifimovieion
        return true; // On informe l'appellant que tout est bon
    }

    public IEnumerable<Movie> GetAll()
    {
        var movies = _context.Movies.ToHashSet(); // On récupère une version HashSet<Movie> de nos films
        return movies; // On le retourne à l'appellant
    }

    public Movie? GetById(int id)
    {
        var movieFound = _context.Movies.FirstOrDefault(c => c.Id == id); // On cherche un film avec le même ID
        //var movieFoundSingle = _context.Movies.SingleOrDefault(c => c.Id == id); // On cherche un film avec le même ID, on s'assure qu'il n'y en a qu'un
        return movieFound;
    }

    public Movie? Update(Movie entity)
    {
        var movieFound = _context.Movies.FirstOrDefault(c => c.Id == entity.Id); // On cherche un film avec le même ID
        if (movieFound == null) return null; // Si pas de film, on retourne une valeur nulle pour informer que l'on a pas fait de modifimovieion

        // On modifie chacun des champs de notre film, sauf son Id
        movieFound.Nom = entity.Nom;
        movieFound.Genre= entity.Genre;
        movieFound.Duree= entity.Duree;
        movieFound.Realisateur= entity.Realisateur;
        movieFound.Statut= entity.Statut;

        // Ici, on ne vérifie pas les champs, ce qui fait que l'on va potentiellement 'null' des valeurs qu'il conviendrait de vérifier au niveau de 'entity'

        _context.SaveChanges(); // On sauvegarde les modifimovieions
        return movieFound; // On retourne le film modifié
    }
}
