using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzApi.Helpers;
using PizzApi.Models;
using PizzApi.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace PizzApi.Controllers
{
    [ApiController]
    [Route("api/pizza")]
    [Authorize]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [HttpGet]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Obtenir la liste des pizzas")]
        [ProducesResponseType(typeof(IEnumerable<Pizza>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPizzas()
        {
            var pizzas = await _pizzaService.GetAllPizzas();
            return Ok(pizzas);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Obtenir une pizza par ID")]
        [ProducesResponseType(typeof(Pizza), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPizzaById(int id)
        {
            var pizza = await _pizzaService.GetPizzaById(id);
            return pizza != null ? Ok(pizza) : NotFound($"Pizza avec l'id {id} non trouvé.");
        }

        [HttpPost]
        [Authorize(Roles = Constants.RolePizzaiolo)]
        [SwaggerOperation(Summary = "Créer une nouveau pizza")]
        [ProducesResponseType(typeof(Pizza), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddPizza([FromBody] Pizza pizza)
        {
            try
            {
                var newPizza = await _pizzaService.AddPizza(pizza);
                return CreatedAtAction(nameof(GetPizzaById),
                                       new { id = newPizza.Id },
                                       newPizza);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erreur lors de la création de la pizza : {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = Constants.RolePizzaiolo)]
        [SwaggerOperation(Summary = "Mettre à jour une pizza")]
        [ProducesResponseType(typeof(Pizza), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] Pizza pizza)
        {
            try
            {
                var updatedPizza = await _pizzaService.CompleteUpdatePizza(id, pizza);
                return Ok(updatedPizza);
            }
            catch (KeyNotFoundException nex)
            {
                return NotFound(nex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erreur lors de la mise à jour de la pizza : {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Constants.RolePizzaiolo)]
        [SwaggerOperation(Summary = "Supprimer une pizza")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletePizza(int id)
        {
            try
            {
                await _pizzaService.DeletePizza(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erreur lors de la suppression de la pizza : {ex.Message}");
            }
        }

        [HttpGet("{pizzaId}/toppings")]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Obtenir la liste des toppings d'une pizzas")]
        [ProducesResponseType(typeof(IEnumerable<Ingredient>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPizzaToppings(int pizzaId)
        {
            var ingredients = await _pizzaService.GetPizzaToppings(pizzaId);
            return Ok(ingredients);
        }

        [HttpGet("{pizzaId}/toppings/{ingredientId}")]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Obtenir une pizza par ID")]
        [ProducesResponseType(typeof(Pizza), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTopping(int pizzaId, int ingredientId)
        {
            try
            {
                return Ok(await _pizzaService.GetTopping(pizzaId, ingredientId));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erreur lors de la suppression de la pizza : {ex.Message}");
            }
        }

        [HttpPost("{pizzaId}/toppings")]
        [Authorize(Roles = Constants.RolePizzaiolo)]
        [SwaggerOperation(Summary = "Créer un nouveau topping sur une pizza")]
        [ProducesResponseType(typeof(Ingredient), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddTopping(int pizzaId, [FromBody] Ingredient ingredient)
        {
            try
            {
                var newPizza = await _pizzaService.AddTopping(pizzaId, ingredient);
                return CreatedAtAction(nameof(GetTopping),
                                       new { pizzaId = newPizza.Id },
                                       newPizza);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erreur lors de la création de la pizza : {ex.Message}");
            }
        }

        [HttpDelete("{pizzaId}/toppings/{ingredientId}")]
        [Authorize(Roles = Constants.RolePizzaiolo)]
        [SwaggerOperation(Summary = "Supprimer un topping d'une pizza")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoveTopping(int pizzaId, int ingredientId)
        {
            try
            {
                await _pizzaService.RemoveTopping(pizzaId, ingredientId);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erreur lors de la suppression de la pizza : {ex.Message}");
            }
        }
    }
}
