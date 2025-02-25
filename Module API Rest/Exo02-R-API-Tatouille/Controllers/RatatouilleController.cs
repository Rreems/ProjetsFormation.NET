using Exo02_R_API_Tatouille.DTOs.Authentification;
using Exo02_R_API_Tatouille.Exceptions;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Exo02_R_API_Tatouille.Services;
using Exo02_R_API_Tatouille.DTOs;
using Exo02_R_API_Tatouille.Models;

namespace Exo02_R_API_Tatouille.Controllers;


[Route("R-API-Tatouille")]
[ApiController]
public class RatatouilleController : ControllerBase
{
    private readonly IRatatouilleService _ratatouilleService;

    public RatatouilleController(IRatatouilleService ratatouilleService)
    {
        _ratatouilleService = ratatouilleService;
    }

    [HttpGet("menu")]
    [SwaggerOperation(Summary = "Afficher la liste des Ratatouilles.")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Ratatouille>> Menu()
    {
        try
        {
            IEnumerable<Ratatouille> Menu = await _ratatouilleService.GetAll();

            return Ok(Menu);
        }
        catch (Exception ex)
        {
            return BadRequest(new LoginResponseDTO { IsSuccessful = false, ErrorMessage = "Invalid Ratatouille ! Erreur interne." + ex.Message });
        }
    }

    [HttpPost("ratatouille")]
    [SwaggerOperation(Summary = "Ajouter une nouvelle Ratatouille.")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] RatatouilleDTO ratatouilleDTO)
    {
        try
        {
            var newRatatouille = await _ratatouilleService.Create(ratatouilleDTO);
            return CreatedAtAction(nameof(GetById),
                                   new { id = newRatatouille.Id },
                                   newRatatouille);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erreur lors de la création du Ratatouille : {ex.Message}");
        }
    }



    // GET /ratatouille/{id}
    [HttpGet("ratatouille/{id}")]
    [SwaggerOperation(Summary = "Obtenir une Ratatouille par ID",
              Description = "Récupère un Ratatouille en fonction de son identifiant unique.")]
    [ProducesResponseType(typeof(RatatouilleDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Ratatouille>> GetById(string id)
    {
        var Ratatouille = await _ratatouilleService.GetById(id);
        return Ratatouille != null ? Ok(Ratatouille) : NotFound($"Ratatouille avec l'id {id} non trouvé.");
    }


}