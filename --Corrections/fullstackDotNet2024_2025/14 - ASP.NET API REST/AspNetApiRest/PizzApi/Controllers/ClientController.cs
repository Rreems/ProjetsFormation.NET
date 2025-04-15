using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzApi.Helpers;
using PizzApi.Models.Users;
using PizzApi.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace PizzApi.Controllers
{
    [Route("api/client")]
    [ApiController]
    //[Authorize] // /!\ attention ici n'importe quel client peut supprimer un autre client => mettre en place une logique adaptée
    [Authorize(Roles = Constants.RolePizzaiolo)]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // GET /clients
        [HttpGet]
        [SwaggerOperation(Summary = "Obtenir la liste des clients")]
        [ProducesResponseType(typeof(IEnumerable<Client>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var clients = await _clientService.GetAll();
            return Ok(clients);
        }

        // GET /clients/{id}
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtenir un client par ID")]
        [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var client = await _clientService.GetById(id);
            return client != null ? Ok(client) : NotFound($"Client avec l'id {id} non trouvé.");
        }

        // POST /clients
        [HttpPost]
        [SwaggerOperation(Summary = "Créer un nouveau client")]
        [ProducesResponseType(typeof(Client), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] Client client)
        {
            try
            {
                var newClient = await _clientService.Create(client);
                return CreatedAtAction(nameof(GetById),
                                       new { id = newClient.Id },
                                       newClient);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erreur lors de la création du client : {ex.Message}");
            }
        }

        // PUT /clients/{id}
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Mettre à jour un client")]
        [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] Client client)
        {
            try
            {
                var updatedClient = await _clientService.Update(id, client);
                return Ok(updatedClient);
            }
            catch (KeyNotFoundException nex)
            {
                return NotFound(nex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erreur lors de la mise à jour du client : {ex.Message}");
            }
        }

        // DELETE /clients/{id}
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Supprimer un client")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _clientService.Delete(id);
                //return Ok($"Client {id} supprimé.")
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erreur lors de la suppression du client : {ex.Message}");
            }
        }
    }
}
