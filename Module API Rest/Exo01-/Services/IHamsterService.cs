using Exo01_.Entities;

namespace Exo01_.Services;

public interface IHamsterService
{


    public IEnumerable<Hamster> GetAll();
    public IEnumerable<Hamster> GetAll(string? Nom=null, string? prenom=null, string?numero=null, string? email=null);
    public Hamster? GetById(int id);
    public Hamster? GetByLastName(string lastName);

    public Hamster Add(Hamster hamster);
    public Hamster? Update(int id, Hamster hamster);
    public bool Delete(Hamster hamster);


}
