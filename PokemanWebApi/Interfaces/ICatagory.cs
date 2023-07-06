using PokemanWebApi.Model;

namespace PokemanWebApi.Interfaces
{
    public interface ICatagory
    {
        ICollection<Catagory> GetCatagories();
        Catagory? GetCatagory(int id);
        Catagory? GetCatagory(string name);
        ICollection<Pokeman>? GetPokemansByCatagory(int id);
        bool CatagoryExists(int id);

        bool CreateCatagory(Catagory catagory);
        bool UpdateCatagory(Catagory catagory);
        bool Save();
    }
}
