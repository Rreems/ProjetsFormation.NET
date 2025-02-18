using System;
using Exo01_.Entities;
using Exo01_.Repository;

namespace Exo01_.Services
{
    public class HamsterService : IHamsterService
    {
        private readonly IRepository<Hamster, int> _repository;


        public HamsterService(IRepository<Hamster, int> repository)
        {
            _repository = repository;
        }


        Hamster IHamsterService.Add(Hamster hamster)
        {
            return _repository.Add(hamster);
        }

        bool IHamsterService.Delete(Hamster hamster)
        {
            return _repository.Delete(hamster);
        }

        IEnumerable<Hamster> IHamsterService.GetAll()
        {
            return _repository.GetAll();
        }

        IEnumerable<Hamster> IHamsterService.GetAll(string? Nom, string? prenom, string? numero, string? email)
        {
            return _repository.GetAll( /* Un délégué TODO */ );
        }

        Hamster? IHamsterService.GetById(int id)
        {
            return _repository.GetById(id); 
        }
        Hamster? GetByLastName(string lastName)
        {
            return _repository.GetAll().FirstOrDefault(h => h.LastName == lastName);
        }

        Hamster? IHamsterService.Update(int id, Hamster hamster)
        {
            Hamster hamsterFound = _repository.GetById(id);

            if (hamsterFound == null)
            {
                return null;
            }
            hamster.Id = hamsterFound.Id;

            return _repository.Update(hamster);
            
        }
    }
}
