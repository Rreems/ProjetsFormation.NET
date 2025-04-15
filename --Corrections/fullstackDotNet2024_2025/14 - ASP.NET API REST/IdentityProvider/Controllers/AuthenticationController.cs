using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text;
using IdentityProvider.Data;
using IdentityProvider.DTOs;
using IdentityProvider.Helpers;
using IdentityProvider.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace IdentityProvider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly AppDbContext _appDbContext;
        private readonly AppSettings _appSettings;
        private readonly Encryptor _encryptor;
        public AuthenticationController(AppDbContext appDbContext, IOptions<AppSettings> appSettings)
        {
            _appDbContext = appDbContext;
            _appSettings = appSettings.Value;
            _encryptor = new Encryptor(/*_appSettings.SecretKey!*/);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerDto)
        {
            if (registerDto.IsAdmin && User.FindFirstValue(ClaimTypes.Role) != Constants.RoleAdmin)
            {
                return Unauthorized(new RegisterResponseDTO { IsSuccessful = false, ErrorMessage = "You can't create an administrator as a user." });
            }

            if (await _appDbContext.Users.AnyAsync(u => u.Email == registerDto.Email))
                return BadRequest(new RegisterResponseDTO { IsSuccessful = false, ErrorMessage = "Email exist" }); // /!\ cela donne une information intéressante


            // Extraire l'ID utilisateur du JWT si l'utilisateur est authentifié
            Guid? createdBy = null;
            var userIdClaim = User.FindFirstValue("UserId");
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

            await _appDbContext.AddAsync(user);

            if (await _appDbContext.SaveChangesAsync() > 0)
                return Ok(new RegisterResponseDTO { IsSuccessful = true, User = user });

            return BadRequest(new RegisterResponseDTO { IsSuccessful = false, ErrorMessage = "Probleme creation User" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginDto)
        {
            var user = await _appDbContext.Users
                .FirstOrDefaultAsync(u => u.Email == loginDto.Email);

            if (user == null)
                return BadRequest(new LoginResponseDTO { IsSuccessful = false, ErrorMessage = "Invalid Authentication !" });

            var (verified, needsUpgrade) = _encryptor.Check(user.Password!, loginDto.Password!);

            if (!verified)
                return BadRequest(new LoginResponseDTO { IsSuccessful = false, ErrorMessage = "Invalid Authentication !" });

            if (needsUpgrade)
            {
                user.Password = _encryptor.EncryptPassword(loginDto.Password!);
                await _appDbContext.SaveChangesAsync();
            }

            var role = user.IsAdmin ? Constants.RoleAdmin : Constants.RoleUser;

            var claims = new List<Claim>
            {
                new (ClaimTypes.Role, role),
                new ("Userid", user.Id!.ToString()!)
            };

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings.SecretKey!)),
                SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddDays((double)_appSettings.TokenExpirationDays!));

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return Ok(new LoginResponseDTO
            {
                IsSuccessful = true,
                Token = token,
                User = user
            });
        }


        [HttpGet("validate")]
        [Authorize]
        public IActionResult ValidateToken()
        {
            // Si cette action est atteinte, le token est valide
            return Ok(new { Message = "Token is valid." });
        }
    }
}

