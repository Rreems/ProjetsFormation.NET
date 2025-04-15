using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzApi.Helpers;
using PizzApi.Models.Users;
using PizzApi.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace PizzApi.Controllers
{
    [Route("api/pizzaiolo")]
    [ApiController]
    [Authorize(Roles =Constants.RolePizzaiolo)]
    public class PizzaioloController : ControllerBase
    {
        private readonly IPizzaioloService _pizzaioloService;

        public PizzaioloController(IPizzaioloService pizzaioloService)
        {
            _pizzaioloService = pizzaioloService;
        }

        // GET /pizzaiolos
        [HttpGet]
        [SwaggerOperation(Summary = "Obtenir la liste des pizzaiolos")]
        [ProducesResponseType(typeof(IEnumerable<Pizzaiolo>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var pizzaiolos = await _pizzaioloService.GetAll();
            return Ok(pizzaiolos);
        }

        // GET /pizzaiolos/{id}
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtenir un pizzaiolo par ID")]
        [ProducesResponseType(typeof(Pizzaiolo), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var pizzaiolo = await _pizzaioloService.GetById(id);
            return pizzaiolo != null ? Ok(pizzaiolo) : NotFound($"Pizzaiolo avec l'id {id} non trouvé.");
        }

        // POST /pizzaiolos
        [HttpPost]
        [SwaggerOperation(Summary = "Créer un nouveau pizzaiolo")]
        [ProducesResponseType(typeof(Pizzaiolo), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] Pizzaiolo pizzaiolo)
        {
            try
            {
                var newPizzaiolo = await _pizzaioloService.Create(pizzaiolo);
                return CreatedAtAction(nameof(GetById),
                                       new { id = newPizzaiolo.Id },
                                       newPizzaiolo);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erreur lors de la création du pizzaiolo : {ex.Message}");
            }
        }

        // PUT /pizzaiolos/{id}
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Mettre à jour un pizzaiolo")]
        [ProducesResponseType(typeof(Pizzaiolo), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] Pizzaiolo pizzaiolo)
        {
            try
            {
                var updatedPizzaiolo = await _pizzaioloService.Update(id, pizzaiolo);
                return Ok(updatedPizzaiolo);
            }
            catch (KeyNotFoundException nex)
            {
                return NotFound(nex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erreur lors de la mise à jour du pizzaiolo : {ex.Message}");
            }
        }

        // DELETE /pizzaiolos/{id}
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Supprimer un pizzaiolo")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _pizzaioloService.Delete(id);
                //return Ok($"Pizzaiolo {id} supprimé.")
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erreur lors de la suppression du pizzaiolo : {ex.Message}");
            }
        }
    }
}
