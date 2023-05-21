using PokemanWebApi.Data;
using PokemanWebApi.Interfaces;
using PokemanWebApi.Model;

namespace PokemanWebApi.Repository
{
    public class OwnerRepository : IOwner
    {
        private readonly ApplicationDbContext _context;

        public OwnerRepository(ApplicationDbContext context)
        {
            _context = context; 
        }
        public Owner? GetOwner(int ownerId)
        {
            var owner = _context.Owners.FirstOrDefault(o => o.Id == ownerId);
            return owner;
        }

        public ICollection<Owner> GetOwnersByPokeman(int pokemanId)
        {
            var owners = _context.PokemanOwners.Where(u =>u.PokemanId == pokemanId).Select(o=>o.Owner).ToList();
            return owners;
        }

        public ICollection<Owner> GetOwners()
        {
            return _context.Owners.ToList();
        }

        public ICollection<Pokeman> GetPokemansByOwner(int ownerId)
        {
            var pokemans = _context.PokemanOwners.Where(u => u.OwnerId == ownerId).Select(p => p.Pokeman).ToList();
            return pokemans;
        }

        public bool OnwerExists(int ownerId)
        {
            return _context.Owners.Any(u => u.Id == ownerId);
        }

        public bool CreateOwner(Owner owner)
        {
            _context.Owners.Add(owner);
            return Save();
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0;
        }
        public Owner? GetOwner(string name)
        {
            return _context.Owners.FirstOrDefault(u => u.Name == name);
        }
    }
}
