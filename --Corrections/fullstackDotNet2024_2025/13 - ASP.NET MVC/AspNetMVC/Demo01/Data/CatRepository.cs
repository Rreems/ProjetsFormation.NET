using Demo01.Models;

namespace Demo01.Data
{
    public class CatRepository : BaseRepository, IRepository<Cat>
    {
        public CatRepository(ApplicationDbContext context) : base(context)
        {
        }

        // On réceptionne une entité sans Id
        public Cat Create(Cat entity)
        {
            _context.Cats.Add(entity); // On ajoute l'entité au DbSet
            _context.SaveChanges(); // On sauvegarde les changement, ce qui ajoute l'Id à notre entité
            return entity; // On retourne l'entité telle qu'elle est désormais en BdD
        }

        // On réceptionne une entité, avec id
        public bool Delete(Cat entity)
        {
            var catFound = _context.Cats.FirstOrDefault(c => c.Id == entity.Id); // On cherche un chat avec le même ID
            if (catFound == null) return false; // Si l'on en trouve pas, on se stoppe immédiatement
            _context.Cats.Remove(catFound); // Sinon, on supprime le chat
            _context.SaveChanges(); // On sauvegarde la modification
            return true; // On informe l'appellant que tout est bon
        }

        public IEnumerable<Cat> GetAll()
        {
            var cats = _context.Cats.ToHashSet(); // On récupère une version HashSet<Cat> de nos chats
            return cats; // On le retourne à l'appellant
        }

        public Cat? GetById(int id)
        {
            var catFound = _context.Cats.FirstOrDefault(c => c.Id == id); // On cherche un chat avec le même ID
            var catFoundSingle = _context.Cats.SingleOrDefault(c => c.Id == id); // On cherche un chat avec le même ID, on s'assure qu'il n'y en a qu'un
            return catFound;
        }

        public Cat? Update(Cat entity)
        {
            var catFound = _context.Cats.FirstOrDefault(c => c.Id == entity.Id); // On cherche un chat avec le même ID
            if (catFound == null) return null; // Si pas de chat, on retourne une valeur nulle pour informer que l'on a pas fait de modification

            // On modifie chacun des champs de notre chat, sauf son Id
            catFound.Name = entity.Name;
            catFound.Breed= entity.Breed;
            catFound.Age= entity.Age;
            catFound.Color = entity.Color;

            // Ici, on ne vérifie pas les champs, ce qui fait que l'on va potentiellement 'null' des valeurs qu'il conviendrait de vérifier au niveau de 'entity'

            _context.SaveChanges(); // On sauvegarde les modifications
            return catFound; // On retourne le chat modifié
        }
    }
}
