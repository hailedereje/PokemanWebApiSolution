using PokemanWebApi.DTO.Country;


namespace PokemanWebApi.DTO.Owner
{
    public class CreateOwnerDTO
    {
        public string Name { get; set; } = null!;
        public string Gym { get; set; } = null!;
        public CountryNameDTO Country { get; set; } = null!;
    }
}
