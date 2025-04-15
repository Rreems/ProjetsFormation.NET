using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ContactWithDtos.Data;
using ContactWithDtos.DTOs;
using ContactWithDtos.DTOs.Authentification;
using ContactWithDtos.Helpers;
using ContactWithDtos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;

namespace ContactWithDtos.Controllers
{
    [Route("authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AppDbContext _dbContext; // plutôt utiliser l'architecture CSR/N-Tier (Service + Repository)
        private readonly AppSettings _appSettings;
        private readonly Encryptor _encryptor;

        public AuthenticationController(AppDbContext dbContext,
                                        IOptions<AppSettings> optionsAppSettings)
        {
            _dbContext = dbContext;
            _appSettings = optionsAppSettings.Value;
            _encryptor = new Encryptor(/*_appSettings.SecretKey!*/);
        }

        [HttpPost("register")]
        [SwaggerOperation(Summary = "Enregistrer un nouvel Utilisateur.")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<RegisterResponseDTO>> Register([FromBody] RegisterRequestDTO registerDto)
        {
            if (registerDto.IsAdmin && User.FindFirstValue(ClaimTypes.Role) != Constants.RoleAdmin )
                return Unauthorized(new RegisterResponseDTO  
                    { IsSuccessful = false, ErrorMessage = "You can't create an administrator as a user." });

            if (await _dbContext.Users.AnyAsync(u => u.Email == registerDto.Email))
                return BadRequest(new RegisterResponseDTO 
                    { IsSuccessful = false, ErrorMessage = "Email already exist !" }); // /!\ cela donne une information intéressante


            // base.User.FindFirstValue(...) => trouver un claim dans le payload du JWT


            // Gestion du champ CreatedBy, si on a un JWT => utilisateur connecté
            Guid? createdBy = null;
            string? userIdClaim = User.FindFirstValue(Constants.ClaimUserId); // ou ClaimTypes.NameIdentifier
            if (!string.IsNullOrEmpty(userIdClaim) && Guid.TryParse(userIdClaim, out Guid userId))
            {
                createdBy = userId;
            }

            // Créer un nouvel utilisateur
            var user = new User
            {
                Email = registerDto.Email,
                Password = _encryptor.EncryptPassword(registerDto.Password!),
                IsAdmin = registerDto.IsAdmin,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = createdBy
            };

            await _dbContext.AddAsync(user); // penser au try catch

            if (await _dbContext.SaveChangesAsync() == 0)
                return BadRequest(new RegisterResponseDTO { IsSuccessful = false, ErrorMessage = "Probleme creation User" });
                
            return Ok(new RegisterResponseDTO { IsSuccessful = true, User = user });
        }

        [HttpPost("login")]
        [SwaggerOperation(Summary = "Se connecter en tant qu'utilisateur et récupérer son JWT.")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<LoginResponseDTO>> Login([FromBody] LoginRequestDTO loginDto)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);

            if (user == null)
                return BadRequest(new LoginResponseDTO { IsSuccessful = false, ErrorMessage = "Invalid Authentication !" });

            var (verified, needsUpgrade) = _encryptor.Check(user.Password!, loginDto.Password!);

            if (!verified)
                return BadRequest(new LoginResponseDTO { IsSuccessful = false, ErrorMessage = "Invalid Authentication !" });

            if (needsUpgrade)
            {
                user.Password = _encryptor.EncryptPassword(loginDto.Password!);
                await _dbContext.SaveChangesAsync(); // ajouter try catch
            }

            #region JWT

            string role = user.IsAdmin ? Constants.RoleAdmin : Constants.RoleUser;

            var claims = new List<Claim> // detinée à aller dans la partie Payload du JWT
            {
                new (ClaimTypes.Role, role),
                new (Constants.ClaimUserId, user.Id!.ToString()!),
                //new ("Profession", "Formateur d'exception"),
            };

            var securityKey = _appSettings.SecretKey;

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(securityKey)),
                SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(_appSettings.TokenExpirationDays),
                signingCredentials: signingCredentials
                );

            string token = new JwtSecurityTokenHandler().WriteToken(jwt);

            #endregion

            return Ok(new LoginResponseDTO
            {
                IsSuccessful = true,
                Token = token,
                User = user
            });
        }
    }
}
