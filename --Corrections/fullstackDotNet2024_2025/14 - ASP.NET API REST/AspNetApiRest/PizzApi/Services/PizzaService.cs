using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PizzApi.Models;
using PizzApi.Models.Users;
using PizzApi.Reposiroties;
using PizzApi.Services.Interfaces;

namespace PizzApi.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IRepository<Pizza, int> _pizzaRepository;
        private readonly IRepository<Ingredient, int> _ingredientRepository;

        public PizzaService(IRepository<Pizza, int> pizzaRepository,
                            IRepository<Ingredient, int> ingredientRepository)
        {
            _pizzaRepository = pizzaRepository;
            _ingredientRepository = ingredientRepository;
        }
        // Pizzas
        public async Task<IEnumerable<Pizza>> GetAllPizzas() => await _pizzaRepository.GetAll();
        public async Task<Pizza?> GetPizzaById(int pizzaId) => await _pizzaRepository.GetById(pizzaId);
        public async Task<Pizza> AddPizza(Pizza pizza)
        {
            try
            {
                return await _pizzaRepository.Add(pizza);
            }
            catch (Exception e)
            {
                // Ajout du Logging de l'erreur rencontrée
                Console.WriteLine($"Erreur d'ajout pour le pizza {pizza.Name}: {e.Message}");
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }
        public async Task<Pizza> CompleteUpdatePizza(int id, Pizza pizza)
        {
            try
            {
                pizza.Id = id;
                return await CompleteUpdatePizza(pizza)
                       ?? throw new KeyNotFoundException($"Pizza avec l'id {id} non trouvé.");
            }
            catch (Exception e)
            {
                // Ajout du Logging de l'erreur rencontrée
                Console.WriteLine($"Erreur de modification pour le pizza avec l'id {id}: {e.Message}");
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        // méthode pour mettre à jour une pizza et ses ingrédients en 1 fois (One to Many)
        private async Task<Pizza?> CompleteUpdatePizza(Pizza pizza)
        {
            var pizzaFromDb = await GetPizzaById(pizza.Id);

            if (pizzaFromDb == null)
                return null;

            if (pizzaFromDb.Name != pizza.Name)
                pizzaFromDb.Name = pizza.Name;
            if (pizzaFromDb.Price != pizza.Price)
                pizzaFromDb.Price = pizza.Price;
            if (pizzaFromDb.ImageLink != pizza.ImageLink)
                pizzaFromDb.ImageLink = pizza.ImageLink;

            // mettre à jour les ingrédients :
            if (!pizza.Ingredients.IsNullOrEmpty())
            {
                // gestion des ingrédients déjà existants en BDD
                foreach (var ingredientFromDb in pizzaFromDb.Ingredients!)
                {
                    var ingredientDejaExistant = pizza.Ingredients!.FirstOrDefault(i => i.Id == ingredientFromDb.Id);
                    // l'ingrédient existe déjà donc pas de modification => on le retire des ingrédients à traiter
                    if (ingredientDejaExistant != null)
                    {
                        pizza.Ingredients!.Remove(ingredientDejaExistant);
                        continue;
                    }
                    // l'ingrédient a été retiré de la pizza donc on le retire de la BDD
                    await _ingredientRepository.Delete(ingredientFromDb.Id);
                }
                // ajout des nouveaux ingrédients (ceux qui restent dans la pizza à traiter)
                foreach (var nouvelIngredient in pizza.Ingredients!)
                {
                    await _ingredientRepository.Add(nouvelIngredient);
                }
            }
            else
            {
                // la nouvelle pizza n'a pas d'ingrédients => on supprime les ingrédients existants
                foreach (var ingredientFromDb in pizzaFromDb.Ingredients!)
                {
                    await _ingredientRepository.Delete(ingredientFromDb.Id);
                }
            }

            return pizzaFromDb;
        }

        public async Task DeletePizza(int pizzaId)
        {
            try
            {
                if (!await _pizzaRepository.Delete(pizzaId))
                    throw new KeyNotFoundException($"Pizza avec l'id {pizzaId} non trouvé.");
            }
            catch (Exception e)
            {
                // Ajout du Logging de l'erreur rencontrée
                Console.WriteLine($"Erreur de modification pour le pizza avec l'id {pizzaId}: {e.Message}");
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        // Toppings
        public async Task<IEnumerable<Ingredient>> GetPizzaToppings(int pizzaId) => await _ingredientRepository.GetAll(i => i.PizzaId == pizzaId);
        public async Task<Ingredient?> GetTopping(int pizzaId, int ingredientId)
        {
            if (await _pizzaRepository.GetById(pizzaId) == null)
                throw new KeyNotFoundException($"Pizza avec l'id {pizzaId} non trouvé.");

            var ing = await _ingredientRepository.GetById(ingredientId);

            if (ing == null)
                throw new KeyNotFoundException($"Topping avec l'id {pizzaId} non trouvé.");

            if (ing.PizzaId != pizzaId)
                throw new InvalidOperationException("Topping is on another Pizza");

            return ing;
        }

        public async Task<Ingredient> AddTopping(int pizzaId, Ingredient ingredient)
        {
            try
            {
                if (await _pizzaRepository.GetById(pizzaId) == null)
                    throw new KeyNotFoundException($"Pizza avec l'id {pizzaId} non trouvé.");

                ingredient.PizzaId = pizzaId;

                return await _ingredientRepository.Add(ingredient);
            }
            catch (Exception e)
            {
                // Ajout du Logging de l'erreur rencontrée
                Console.WriteLine($"Erreur d'ajout pour le topping {ingredient.Name} sur la pizza {pizzaId}: {e.Message}");
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public async Task RemoveTopping(int pizzaId, int ingredientId)
        {
            try
            {
                if (await _pizzaRepository.GetById(pizzaId) == null)
                    throw new KeyNotFoundException($"Pizza avec l'id {pizzaId} non trouvé.");

                var ing = await _ingredientRepository.GetById(ingredientId);

                if (ing == null)
                    throw new KeyNotFoundException($"Topping avec l'id {pizzaId} non trouvé.");

                if (ing.PizzaId != pizzaId)
                    throw new InvalidOperationException("Topping is on another Pizza");

                await _ingredientRepository.Delete(ing.Id);
            }
            catch (Exception e)
            {
                // Ajout du Logging de l'erreur rencontrée
                Console.WriteLine($"Erreur de modification pour le pizza avec l'id {pizzaId}: {e.Message}");
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }
    }
}
