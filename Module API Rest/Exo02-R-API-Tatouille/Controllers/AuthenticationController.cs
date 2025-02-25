using Exo02_R_API_Tatouille.DTOs.Authentification;
using Exo02_R_API_Tatouille.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;
using Exo02_R_API_Tatouille.Helpers;
using Exo02_R_API_Tatouille.Exceptions;


namespace Exo02_R_API_Tatouille.Controllers;


[Route("authentication")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _userService;

    public AuthenticationController(IAuthenticationService userService)
    {
        _userService = userService;
    }

    [HttpPost("login")]
    [SwaggerOperation(Summary = "Se connecter en tant qu'utilisateur et récupérer son JWT.")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<LoginResponseDTO>> Login([FromBody] LoginRequestDTO loginDto)
    {
        try
        {
            LoginResponseDTO loginResponseDTO = await _userService.Login(loginDto);

            return Ok(loginResponseDTO);
        }
        catch (Exception ex)
        {
            return BadRequest(new LoginResponseDTO { IsSuccessful = false, ErrorMessage = "Invalid Authentication !" });
        }
    }

    [HttpPost("register")]
    [SwaggerOperation(Summary = "Enregistrer un nouvel Utilisateur.")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<RegisterResponseDTO>> Register([FromBody] RegisterRequestDTO registerDto)
    {
        try
        {
            string userRole = User.FindFirstValue(ClaimTypes.Role);
            string userId = User.FindFirstValue(Constants.ClaimUserId);
            RegisterResponseDTO registerResponseDto = await _userService.Register(registerDto, userRole, userId);

            return Ok(registerResponseDto);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Forbid(ex.Message);
        }
        catch (UserAlreadyExistException ex)
        {
            return BadRequest(new RegisterResponseDTO { IsSuccessful = false, ErrorMessage = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new RegisterResponseDTO { IsSuccessful = false, ErrorMessage = "Probleme creation User" });
        }
    }



}
