using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzApi.DTOs.Auth;
using PizzApi.DTOs.Auth.Clients;
using PizzApi.DTOs.Auth.Pizzaiolos;
using PizzApi.Helpers;
using PizzApi.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace PizzApi.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("pizzaiolo/register")]
        [SwaggerOperation(Summary = "Enregistrer un nouveau Pizzaiolo.")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<PizzaioloRegisterResponseDTO>> PizzaioloRegister([FromBody] PizzaioloRegisterRequestDTO registerDto)
        {
            try
            {
                return await _authService.PizzaioloRegister(registerDto);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(new PizzaioloRegisterResponseDTO
                { IsSuccessful = false, ErrorMessage = e.Message });
            }
        }

        [HttpPost("client/register")]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Enregistrer un nouvel Utilisateur.")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<ClientRegisterResponseDTO>> ClientRegister([FromBody] ClientRegisterRequestDTO registerDto)
        {
            try
            {
                return await _authService.ClientRegister(registerDto);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(new PizzaioloRegisterResponseDTO
                { IsSuccessful = false, ErrorMessage = e.Message });
            }
        }

        [HttpPost("pizzaiolo/login")]
        [SwaggerOperation(Summary = "Se connecter en tant que Pizzaiolo et récupérer son JWT.")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<PizzaioloLoginResponseDTO>> PizzaioloLogin([FromBody] LoginRequestDTO loginDto)
        {
            try
            {
                return await _authService.PizzaioloLogin(loginDto);
            }
            catch (Exception e )
            {
                return BadRequest(new PizzaioloRegisterResponseDTO
                { IsSuccessful = false, ErrorMessage = e.Message });
            }
        }

        [HttpPost("client/login")]
        [SwaggerOperation(Summary = "Se connecter en tant que Client et récupérer son JWT.")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<ClientLoginResponseDTO>> ClientLogin([FromBody] LoginRequestDTO loginDto)
        {
            try
            {
                return await _authService.ClientLogin(loginDto);
            }
            catch (Exception e)
            {
                return BadRequest(new PizzaioloRegisterResponseDTO
                { IsSuccessful = false, ErrorMessage = e.Message });
            }
        }
    }
}
