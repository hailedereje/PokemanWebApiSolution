using PokemanWebApi.Model;

namespace PokemanWebApi.Interfaces
{
    public interface ICountry
    {
        ICollection<Country> GetCountries();
        Country? GetCountry(int id);
        Country? GetCountry(string countryName);
        Country? GetCountryByOwner(int ownerId);
        ICollection<Owner> GetOwnersFromACountry(int countryId);
        bool CountryExists(int id);

        bool CreateCountry(Country country);
        bool Save();
    }
}
