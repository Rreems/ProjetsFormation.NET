using Microsoft.AspNetCore.Mvc;
using PizzApi.DTOs;
using PizzApi.DTOs.Auth;
using PizzApi.DTOs.Auth.Clients;
using PizzApi.DTOs.Auth.Pizzaiolos;

namespace PizzApi.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ClientRegisterResponseDTO> ClientRegister(ClientRegisterRequestDTO registerDto);
        Task<ClientLoginResponseDTO> ClientLogin(LoginRequestDTO loginDto);
        Task<PizzaioloRegisterResponseDTO> PizzaioloRegister(PizzaioloRegisterRequestDTO registerDto);
        Task<PizzaioloLoginResponseDTO> PizzaioloLogin(LoginRequestDTO loginDto);
    }
}
