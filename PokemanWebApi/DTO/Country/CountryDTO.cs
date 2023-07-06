using PokemanWebApi.DTO.Owner;

namespace PokemanWebApi.DTO.Country
{
    public class CountryDTO
    {

        public string Name { get; set; } = null!;
        public IList<OwnerDTO> Owners { get; set; } = null!;
    }
}
