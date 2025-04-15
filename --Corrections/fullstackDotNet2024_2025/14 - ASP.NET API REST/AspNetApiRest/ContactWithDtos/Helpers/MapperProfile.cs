using AutoMapper;
using ContactWithDtos.DTOs;
using ContactWithDtos.Models;

namespace ContactWithDtos.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // cette ligne permet de dire qu'a l'aide du mapper on pourra passer de l'entité vers le DTO
            // et vice versa grace au .ReverseMap()
            CreateMap<Contact, ContactDTO>().ReverseMap();
            CreateMap<Contact, ContactFullNameDTO>();
        }
    }
}
