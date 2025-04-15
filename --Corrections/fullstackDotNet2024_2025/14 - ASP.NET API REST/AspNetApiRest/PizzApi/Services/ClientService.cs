using PizzApi.Helpers;
using PizzApi.Models.Users;
using PizzApi.Reposiroties;
using PizzApi.Services.Interfaces;

namespace PizzApi.Services
{
    public class ClientService : IClientService
    {
        private readonly IRepository<Client, int> _clientRepository;
        private readonly Encryptor _encryptor;

        public ClientService(IRepository<Client, int> clientRepository)
        {
            _clientRepository = clientRepository;
            _encryptor = new Encryptor();
        }

        public async Task<IEnumerable<Client>> GetAll() => await _clientRepository.GetAll();

        public async Task<Client?> GetById(int id) => await _clientRepository.GetById(id);

        public async Task<Client?> GetByEmail(string email) => await _clientRepository.Get(c => c.Email == email);

        public async Task<Client> Create(Client client)
        {
            try
            {
                client.Password = _encryptor.EncryptPassword(client.Password!);
                return await _clientRepository.Add(client);
            }
            catch (Exception e)
            {
                // Ajout du Logging de l'erreur rencontrée
                Console.WriteLine($"Erreur d'ajout pour le client {client.Email}: {e.Message}");
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public async Task<Client> Update(int id, Client client)
        {
            try
            {
                client.Id = id;
                client.Password = _encryptor.EncryptPassword(client.Password!);
                return await _clientRepository.Update(client)
                       ?? throw new KeyNotFoundException($"Client avec l'id {id} non trouvé.");
            }
            catch (Exception e)
            {
                // Ajout du Logging de l'erreur rencontrée
                Console.WriteLine($"Erreur de modification pour le client avec l'id {id}: {e.Message}");
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                if (!await _clientRepository.Delete(id))
                    throw new KeyNotFoundException($"Client avec l'id {id} non trouvé.");
            }
            catch (Exception e)
            {
                // Ajout du Logging de l'erreur rencontrée
                Console.WriteLine($"Erreur de modification pour le client avec l'id {id}: {e.Message}");
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }
    }
}
