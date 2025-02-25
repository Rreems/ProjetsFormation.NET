using AutoMapper;
using Exo02_R_API_Tatouille.DTOs;
using Exo02_R_API_Tatouille.DTOs.Authentification;
using Exo02_R_API_Tatouille.Models;

namespace Exo02_R_API_Tatouille.Helpers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        // cette ligne permet de dire qu'a l'aide du mapper on pourra passer de l'entité vers le DTO
        // et vice versa grace au .ReverseMap()
        CreateMap<User, UserDTO>().ReverseMap();

        CreateMap<Ratatouille, RatatouilleDTO>().ReverseMap();
    }
}



