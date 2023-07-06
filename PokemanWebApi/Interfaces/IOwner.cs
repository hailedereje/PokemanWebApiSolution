using PokemanWebApi.Model;

namespace PokemanWebApi.Interfaces
{
    public interface IOwner
    {
        ICollection<Owner> GetOwners();
        Owner? GetOwner(int ownerId);
        Owner? GetOwner(string ownerName);
        ICollection<Owner> GetOwnersByPokeman(int pokemanId);
        ICollection<Pokeman> GetPokemansByOwner(int ownerId);
        bool OnwerExists(int ownerId);

        bool CreateOwner (Owner owner);
        bool Save();
    }
}
