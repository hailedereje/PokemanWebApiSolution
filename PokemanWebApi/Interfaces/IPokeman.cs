using PokemanWebApi.Model;

namespace PokemanWebApi.Interfaces
{
    public interface IPokeman
    {
        ICollection<Pokeman> GetPokemans();
        Pokeman? GetPokeman(int id);
        Pokeman? GetPokeman(string name);
        bool PokemanExists(int  id);
    }
}
