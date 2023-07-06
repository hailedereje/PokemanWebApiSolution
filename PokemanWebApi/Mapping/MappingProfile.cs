using AutoMapper;
using PokemanWebApi.DTO;
using PokemanWebApi.DTO.Country;
using PokemanWebApi.DTO.Owner;
using PokemanWebApi.Model;

namespace PokemanWebApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Pokeman, PokemanDTO>().ReverseMap();
            CreateMap<Catagory, CatagoryDTO>().ReverseMap();
            CreateMap<Catagory, UpdateCatagory>().ReverseMap();
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Country,CountryNameDTO>().ReverseMap();
            CreateMap<Owner, CreateOwnerDTO>().ReverseMap();
            CreateMap<Owner,OwnerDTO>().ReverseMap();
            CreateMap<Review, ReviewDTO>().ReverseMap();
            CreateMap<Reviewer, ReviewerDTO>().ReverseMap();
        }
    }
}
