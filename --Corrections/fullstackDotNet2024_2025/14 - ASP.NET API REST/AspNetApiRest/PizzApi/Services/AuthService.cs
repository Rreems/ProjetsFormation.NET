using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using PizzApi.DTOs;
using PizzApi.Services.Interfaces;
using PizzApi.Helpers;
using PizzApi.DTOs.Auth;
using PizzApi.DTOs.Auth.Clients;
using PizzApi.DTOs.Auth.Pizzaiolos;
using PizzApi.Models.Users;
using PizzApi.Reposiroties;
using Microsoft.Extensions.Options;

namespace PizzApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly IClientService _clientService;
        private readonly IPizzaioloService _pizzaioloService;
        private readonly ILogger<AuthService> _logger;
        private readonly AppSettings _appSettings;
        private readonly Encryptor _encryptor;
        //private readonly IHttpContextAccessor _httpContextAccessor

        public AuthService(IClientService clientService,
                           IPizzaioloService pizzaioloService,
                           //IHttpContextAccessor httpContextAccessor,
                           ILogger<AuthService> logger,
                           IOptions<AppSettings> appSettings)
        {
            _clientService = clientService;
            _pizzaioloService = pizzaioloService;
            _logger = logger;
            _appSettings = appSettings.Value;
            _encryptor = new Encryptor();
            //_httpContextAccessor = httpContextAccessor; //_httpContextAccessor.HttpContext...
            logger.LogInformation("Auth service created");
        }

        public async Task<ClientRegisterResponseDTO> ClientRegister(ClientRegisterRequestDTO registerDto)
        {
            _logger.LogInformation("ClientRegister called");
            try
            {
                if (await _clientService.GetByEmail(registerDto.Email!) is not null)
                    throw new InvalidOperationException("Email already exist !");

                var client = new Client
                {
                    Email = registerDto.Email,
                    Password = registerDto.Password,
                    FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName,
                    PhoneNumber = registerDto.PhoneNumber,
                    Address = registerDto.Address
                };

                client = await _clientService.Create(client);

                return new ClientRegisterResponseDTO { IsSuccessful = true, Client = client };
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Erreur d'enregistrement pour le client {registerDto.Email}: {e.Message}");

                throw;
            }
        }

        public async Task<PizzaioloRegisterResponseDTO> PizzaioloRegister(PizzaioloRegisterRequestDTO registerDto)
        {
            try
            {
                if (await _pizzaioloService.GetByEmail(registerDto.Email!) is not null)
                    throw new InvalidOperationException("Email already exist !");

                var pizzaiolo = new Pizzaiolo
                {
                    Email = registerDto.Email,
                    Password = registerDto.Password,
                };

                pizzaiolo = await _pizzaioloService.Create(pizzaiolo);

                return new PizzaioloRegisterResponseDTO { IsSuccessful = true, Pizzaiolo = pizzaiolo };
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Erreur d'enregistrement pour le client {registerDto.Email}: {e.Message}");
                throw;
            }
        }

        public async Task<ClientLoginResponseDTO> ClientLogin(LoginRequestDTO loginDto)
        {
            try
            {
                var client = await _clientService.GetByEmail(loginDto.Email!);

                if (client == null)
                    throw new KeyNotFoundException("Invalid Authentication !");

                var (verified, needsUpgrade) = _encryptor.Check(client.Password!, loginDto.Password!);

                if (!verified)
                    throw new UnauthorizedAccessException("Invalid Authentication !");

                if (needsUpgrade)
                {
                    client.Password = loginDto.Password;
                    await _clientService.Update(client.Id, client);
                }

                string token = CreateJwt(Constants.RoleClient, client.Id.ToString());

                return new ClientLoginResponseDTO
                {
                    IsSuccessful = true,
                    Token = token,
                    Client = client
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Erreur de connexion pour le client {loginDto.Email}: {e.Message}");
                throw;
            }
        }

        public async Task<PizzaioloLoginResponseDTO> PizzaioloLogin(LoginRequestDTO loginDto)
        {
            try
            {
                var pizzaiolo = await _pizzaioloService.GetByEmail(loginDto.Email!);

                if (pizzaiolo == null)
                    throw new KeyNotFoundException("Invalid Authentication !");

                var (verified, needsUpgrade) = _encryptor.Check(pizzaiolo.Password!, loginDto.Password!);

                if (!verified)
                    throw new UnauthorizedAccessException("Invalid Authentication !");

                if (needsUpgrade)
                {
                    pizzaiolo.Password = loginDto.Password;
                    await _pizzaioloService.Update(pizzaiolo.Id, pizzaiolo);
                }

                string token = CreateJwt(Constants.RolePizzaiolo, pizzaiolo.Id.ToString());

                return new PizzaioloLoginResponseDTO
                {
                    IsSuccessful = true,
                    Token = token,
                    Pizzaiolo = pizzaiolo
                };
            }
            catch (Exception e)
            {
                // Ajout du Logging de l'erreur rencontrée
                _logger.LogError(e, $"Erreur de connexion pour le client {loginDto.Email}: {e.Message}");
                throw;
            }
        }

        private string CreateJwt(string role, string subjectId)
        {
            var claims = new List<Claim> // detinée à aller dans la partie Payload du JWT
            {
                new (ClaimTypes.Role, role),
                //new ("user_id", user.Id!.ToString()!),                  // personnalisé
                //new (ClaimTypes.NameIdentifier, user.Id!.ToString()!),  // recommandation Microsoft
                new (JwtRegisteredClaimNames.Sub, subjectId),  // recommandation JWT
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

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
