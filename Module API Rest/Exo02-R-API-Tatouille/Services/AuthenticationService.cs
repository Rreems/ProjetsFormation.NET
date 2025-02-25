using AutoMapper;
using Exo02_R_API_Tatouille.DTOs.Authentification;
using Exo02_R_API_Tatouille.Exceptions;
using Exo02_R_API_Tatouille.Helpers;
using Exo02_R_API_Tatouille.Models;
using Exo02_R_API_Tatouille.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Exo02_R_API_Tatouille.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IRepository<User, string> _userRepository;
    private readonly IMapper _mapper;

    private readonly Encryptor _encryptor;
    private readonly AppSettings _appSettings;

    public AuthenticationService(IRepository<User, string> userRepository,
                          IMapper mapper,
                          IOptions<AppSettings> optionsAppSettings)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _appSettings = optionsAppSettings.Value;
        _encryptor = new Encryptor(_appSettings.SecretKey!);
    }

    public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
    {

        var user = await _userRepository.Get(u => u.Email == loginRequestDTO.Email);

        if (user == null)
            return new LoginResponseDTO { IsSuccessful = false, ErrorMessage = "Invalid Authentication !" };

        var (verified, needsUpgrade) = _encryptor.Check(user.Password!, loginRequestDTO.Password!);

        if (!verified)
            return new LoginResponseDTO { IsSuccessful = false, ErrorMessage = "Invalid Authentication !" };

        if (needsUpgrade)
        {
            user.Password = _encryptor.EncryptPassword(loginRequestDTO.Password!);

            await _userRepository.Update(user);
        }

        #region JWT

        string role = user.Role == Constants.RoleAdmin ? Constants.RoleAdmin : Constants.RoleUser;

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

        return new LoginResponseDTO
        {
            IsSuccessful = true,
            Token = token,
            User = user
        };

    }



    public async Task<RegisterResponseDTO> Register(RegisterRequestDTO registerRequestDTO, string? userClaimRole, string? userClaimId)
    {

        if (registerRequestDTO.Role == Constants.RoleAdmin
            && userClaimRole != Constants.RoleAdmin)
        {
            throw new UnauthorizedAccessException($"You can't create an administrator as a user.");
            //return new RegisterResponseDTO
            //{ IsSuccessful = false, ErrorMessage = "You can't create an administrator as a user." };
        }

        //try
        //{
        if (await _userRepository.Get(u => u.Email == registerRequestDTO.Email) != null)
        {
            throw new UserAlreadyExistException($"Email already exist !");  // /!\ cela donne une information intéressante
        }
    //}
        //catch (Exception e)
        //{
        //        throw new UserAlreadyExistException($"Email already exist !");  // /!\ cela donne une information intéressante
        //    //return new RegisterResponseDTO
        //    //{ IsSuccessful = false, ErrorMessage = "Email already exist !" }; // /!\ cela donne une information intéressante
        //}


        // Gestion du champ CreatedBy
        string? createdBy = userClaimId;


    // Créer un nouvel utilisateur
    var user = new User
    {
        Email = registerRequestDTO.Email,
        Password = _encryptor.EncryptPassword(registerRequestDTO.Password!),
        Role = registerRequestDTO.Role,
        CreatedAt = DateTime.UtcNow,
        CreatedBy = createdBy,
        FirstName = registerRequestDTO.FirstName,
        LastName = registerRequestDTO.LastName
    };

        try
        {
            await _userRepository.Add(user);
}
        catch (Exception)
        {
    return new RegisterResponseDTO { IsSuccessful = false, ErrorMessage = "Probleme creation User" };
}

return new RegisterResponseDTO { IsSuccessful = true, User = user };


    }
}