using ContactWithDtos.Exceptions;
using ContactWithDtos.DTOs;
using ContactWithDtos.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using ContactWithDtos.Helpers;

namespace ContactWithDtos.Controllers
{
    [Route("contacts")]
    [ApiController]
    //[EnableCors("allConnections")]
    [Authorize] // on doit avoir un JWT valide
    //[Authorize(Roles = Constants.RoleAdmin)] // restreint le controller aux administrateurs connectés (JWT dans le header Authorization)
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // GET /contacts
        [HttpGet]
        [SwaggerOperation(Summary = "Obtenir la liste des contacts",
                  Description = "Récupère tous les contacts avec des filtres optionnels sur le prénom, le nom, le numéro de téléphone et l'email.")]
        [ProducesResponseType(typeof(IEnumerable<ContactDTO>), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        // [Authorize(Roles = Constants.RoleAdmin)] // => accessible aux admins
        [AllowAnonymous] // permet de donner l'accès à l'endpoint aux personnes sans JWT => remplace l'annotion [Authorize] du controller
        public async Task<IActionResult> Get(
            [FromQuery] string? firstName,
            [FromQuery] string? lastName,
            [FromQuery] string? phoneNumber,
            [FromQuery] string? email)
        {
            var contacts = await _contactService.GetAll(firstName, lastName, phoneNumber, email);
            return Ok(contacts);
        }

        // GET /contacts/{id}
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtenir un contact par ID",
                  Description = "Récupère un contact en fonction de son identifiant unique.")]
        [ProducesResponseType(typeof(ContactDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _contactService.GetById(id);
            return contact != null ? Ok(contact) : NotFound($"Contact avec l'id {id} non trouvé.");
        }

        // GET /contacts/lastname/{lastname}
        [HttpGet("lastname/{lastName}")]
        [SwaggerOperation(Summary = "Obtenir un contact par nom",
                  Description = "Récupère un contact en fonction de son nom de famille.")]
        [ProducesResponseType(typeof(ContactDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByLastName(string lastName)
        {
            var contact = await _contactService.GetByLastName(lastName);
            return contact != null ? Ok(contact) : NotFound($"Contact avec le nom \"{lastName}\" non trouvé.");
        }

        // POST /contacts
        [HttpPost]
        [SwaggerOperation(Summary = "Créer un nouveau contact",
                  Description = "Ajoute un nouveau contact dans le répertoire.")]
        [ProducesResponseType(typeof(ContactDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] ContactDTO contact)
        {
            try
            {
                var newContact = await _contactService.Create(contact);
                return CreatedAtAction(nameof(GetById), 
                                       new { id = newContact.Id }, 
                                       newContact);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erreur lors de la création du contact : {ex.Message}");
            }
        }

        // PUT /contacts/{id}
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Mettre à jour un contact",
                  Description = "Met à jour les informations d'un contact existant.")]
        [ProducesResponseType(typeof(ContactDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] ContactDTO contact)
        {
            try
            {
                var updatedContact = await _contactService.Update(id, contact);
                return Ok(updatedContact);
            }
            catch (NotFoundException nex)
            {
                return NotFound(nex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erreur lors de la mise à jour du contact : {ex.Message}");
            }
        }

        // DELETE /contacts/{id}
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Supprimer un contact",
                  Description = "Supprime un contact à partir de son identifiant.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _contactService.Delete(id);
                //return Ok($"Contact {id} supprimé.")
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erreur lors de la suppression du contact : {ex.Message}");
            }
        }
    }
}
