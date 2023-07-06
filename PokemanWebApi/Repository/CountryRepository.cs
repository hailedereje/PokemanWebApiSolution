using PokemanWebApi.Data;
using PokemanWebApi.Interfaces;
using PokemanWebApi.Model;

namespace PokemanWebApi.Repository
{
   
    public class CountryRepository : ICountry
    {
        private readonly ApplicationDbContext _context;

        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool CountryExists(int id)
        {
            return _context.Countries.Any(c => c.Id == id);
        }


        public ICollection<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }

        public Country? GetCountry(int id)
        {
            var country = _context.Countries.FirstOrDefault(c => c.Id == id);
            return country;
        }

        public Country? GetCountry(string countryName)
        {
            var country = _context.Countries.FirstOrDefault(u => u.Name == countryName);
            return country;
        }

        public Country? GetCountryByOwner(int ownerId)
        {
            var countries = _context.Owners.Where(u => u.Id == ownerId)
                                           .Select(u => u.Country)
                                           .FirstOrDefault();
            return countries;
        }

        public ICollection<Owner> GetOwnersFromACountry(int countryId)
        {
            var owners = _context.Owners.Where(c => c.Country.Id == countryId).ToList();
            return owners;
        }

        public bool Save()
        {
           var save =  _context.SaveChanges();
            return save > 0;
        }

        public bool CreateCountry(Country country)
        {
            _context.Countries.Add(country);
            return Save();
        }
    }
}
