using AutoMapper;
using PokemanWebApi.DTO;
using PokemanWebApi.Model;

namespace PokemanWebApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Pokeman, PokemanDTO>();
            
        }
    }
}
