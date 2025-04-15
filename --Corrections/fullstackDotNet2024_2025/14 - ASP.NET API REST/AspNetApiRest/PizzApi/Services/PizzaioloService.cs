using PizzApi.Helpers;
using PizzApi.Models.Users;
using PizzApi.Reposiroties;
using PizzApi.Services.Interfaces;

namespace PizzApi.Services
{
    public class PizzaioloService : IPizzaioloService
    {
        private readonly IRepository<Pizzaiolo, int> _pizzaioloRepository;
        private readonly Encryptor _encryptor;

        public PizzaioloService(IRepository<Pizzaiolo, int> pizzaioloRepository)
        {
            _pizzaioloRepository = pizzaioloRepository;
            _encryptor = new Encryptor();
        }

        public async Task<IEnumerable<Pizzaiolo>> GetAll() => await _pizzaioloRepository.GetAll();

        public async Task<Pizzaiolo?> GetById(int id) => await _pizzaioloRepository.GetById(id);

        public async Task<Pizzaiolo?> GetByEmail(string email) => await _pizzaioloRepository.Get(p => p.Email == email);

        public async Task<Pizzaiolo> Create(Pizzaiolo pizzaiolo)
        {
            try
            {
                pizzaiolo.Password = _encryptor.EncryptPassword(pizzaiolo.Password!);
                return await _pizzaioloRepository.Add(pizzaiolo);
            }
            catch (Exception e)
            {
                // Ajout du Logging de l'erreur rencontrée
                Console.WriteLine($"Erreur d'ajout pour le pizzaiolo {pizzaiolo.Email}: {e.Message}");
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public async Task<Pizzaiolo> Update(int id, Pizzaiolo pizzaiolo)
        {
            try
            {
                pizzaiolo.Id = id;
                pizzaiolo.Password = _encryptor.EncryptPassword(pizzaiolo.Password!);
                return await _pizzaioloRepository.Update(pizzaiolo) 
                       ?? throw new KeyNotFoundException($"Pizzaiolo avec l'id {id} non trouvé.");
            }
            catch (Exception e)
            {
                // Ajout du Logging de l'erreur rencontrée
                Console.WriteLine($"Erreur de modification pour le pizzaiolo avec l'id {id}: {e.Message}");
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                if (!await _pizzaioloRepository.Delete(id))
                    throw new KeyNotFoundException($"Pizzaiolo avec l'id {id} non trouvé.");
            }
            catch (Exception e)
            {
                // Ajout du Logging de l'erreur rencontrée
                Console.WriteLine($"Erreur de modification pour le pizzaiolo avec l'id {id}: {e.Message}");
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }
    }
}
