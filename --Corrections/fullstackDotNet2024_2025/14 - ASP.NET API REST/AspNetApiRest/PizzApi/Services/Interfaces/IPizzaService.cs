using PizzApi.Models;

namespace PizzApi.Services.Interfaces
{
    public interface IPizzaService
    {
        // Pizzas
        Task<IEnumerable<Pizza>> GetAllPizzas();
        Task<Pizza?> GetPizzaById(int pizzaId);
        Task<Pizza> AddPizza(Pizza pizza);
        Task<Pizza> CompleteUpdatePizza(int id, Pizza pizza); // maj avec les ingrédients
        Task DeletePizza(int pizzaId);

        // Toppings
        Task<IEnumerable<Ingredient>> GetPizzaToppings(int pizzaId);
        Task<Ingredient?> GetTopping(int pizzaId, int ingredientId);
        Task<Ingredient> AddTopping(int pizzaId, Ingredient ingredient);
        Task RemoveTopping(int pizzaId, int ingredientId);
    }
}
