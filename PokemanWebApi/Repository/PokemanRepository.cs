using Microsoft.AspNetCore.Mvc;
using PokemanWebApi.Data;
using PokemanWebApi.Interfaces;
using PokemanWebApi.Model;

namespace PokemanWebApi.Repository
{
    public class PokemanRepository : IPokeman
    {
        private readonly ApplicationDbContext _context;
        public PokemanRepository(ApplicationDbContext context) 
        { 
            _context = context;
        }

        public Pokeman? GetPokeman(int id)
        {
            var pokeman = _context.Pokemans.FirstOrDefault(p => p.Id == id);
            return pokeman;
        }

        public Pokeman? GetPokeman(string name)
        {
            var pokeman = _context.Pokemans.FirstOrDefault(p => p.Name == name);
            return pokeman;
        }

        public ICollection<Pokeman> GetPokemans()
        {
            return _context.Pokemans.ToList();
        }

        public bool PokemanExists(int id)
        {
            var exists = _context.Pokemans.Any(p => p.Id == id);
            return exists;
        }
    }
}
