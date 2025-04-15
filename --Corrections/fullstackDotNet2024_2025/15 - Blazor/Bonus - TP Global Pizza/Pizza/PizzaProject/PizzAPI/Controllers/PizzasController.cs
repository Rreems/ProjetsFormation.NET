using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzAPI.Datas;
using PizzAPI.Helpers;
using PizzAPI.Repositories;
using PizzCore.Models;

namespace PizzAPI.Controllers
{
    [Route("api/pizzas")]
    [ApiController]
    //[Authorize(Policy = Constants.PolicyAdmin)]
    public class PizzasController : ControllerBase
    {
        private readonly IRepository<Pizza> _pizzaRepository;
        private readonly IRepository<Ingredient> _ingredientRepository;

        public PizzasController(IRepository<Pizza> pizzaRepository,
                                IRepository<Ingredient> ingredientRepository)
        {
            _pizzaRepository = pizzaRepository;
            _ingredientRepository = ingredientRepository;
        }

        [HttpGet]
        //[Authorize(Roles = Constants.RoleUser+","+Constants.RoleAdmin)]
        public async Task<IActionResult> Menu()
        {
            return Ok(await _pizzaRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _pizzaRepository.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddPizza([FromBody] Pizza pizza)
        {
            var pizzaId = await _pizzaRepository.Add(pizza);

            if (pizzaId > 1)
                return CreatedAtAction(nameof(Menu), "Pizza added");

            return BadRequest("Something went wrong");
        }

        [HttpPost("add-topping/{pizzaId}")]
        public async Task<IActionResult> AddTopping(int pizzaId, [FromBody] Ingredient ingredient)
        {
            if (await _pizzaRepository.GetById(pizzaId) == null)
                return BadRequest("Pizza not found");

            ingredient.PizzaId = pizzaId;
            int ingredientId = await _ingredientRepository.Add(ingredient);

            if (ingredientId > 0)
                return Ok("Topping added");

            return BadRequest("Something went wrong");
        }

        [HttpDelete("remove-topping/{pizzaId}/{toppingId}")]
        public async Task<IActionResult> RemoveTopping(int pizzaId, int toppingId)
        {
            if (await _pizzaRepository.GetById(pizzaId) == null)
                return BadRequest("Pizza not found");

            var ing = await _ingredientRepository.GetById(toppingId);

            if (ing == null)
                return BadRequest("Topping not found");

            if (ing.PizzaId != pizzaId)
                return BadRequest("Topping is on another Pizza");

            if (await _ingredientRepository.Delete(ing.Id))
                return Ok("Topping removed");

            return BadRequest("Something went wrong");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePizza(int id, [FromBody] Pizza pizza)
        {
            var pizz = await _pizzaRepository.GetById(id);
            if (pizz == null)
                return BadRequest("Pizza not found");

            pizza.Id = id;
            if (await _pizzaRepository.Update(pizza)) 
                return Ok("Pizza Updated !");

            return BadRequest("Something went wrong...");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemovePizza(int id)
        {
            var pizz = await _pizzaRepository.GetById(id);
            if (pizz == null)
                return BadRequest("Pizza not found");

            if (await _pizzaRepository.Delete(id))
                return Ok("Pizza Updated !");

            return BadRequest("Something went wrong...");
        }
    }
}
