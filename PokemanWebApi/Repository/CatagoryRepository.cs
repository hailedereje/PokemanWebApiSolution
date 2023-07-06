using PokemanWebApi.Data;
using PokemanWebApi.Interfaces;
using PokemanWebApi.Model;

namespace PokemanWebApi.Repository
{
    public class CatagoryRepository : ICatagory
    {
        private readonly ApplicationDbContext _context;
        public CatagoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool CatagoryExists(int id)
        {
            return _context.Catagories.Any(c => c.Id == id);
        }

       

        public ICollection<Catagory> GetCatagories()
        {
            return _context.Catagories.ToList();
        }

        public Catagory? GetCatagory(int id)
        {
            return _context.Catagories.FirstOrDefault(c => c.Id == id);
        }

        public Catagory? GetCatagory(string name)
        {
            var catagory = _context.Catagories.FirstOrDefault(u => u.Name.Trim().ToUpper() == name.Trim().ToUpper());
            return catagory;
        }

        public ICollection<Pokeman>? GetPokemansByCatagory(int id)
        {
            var pokemans = _context.PokemanCatagories
                .Where(e => e.CatagoryId == id)
                .Select(e => e.Pokeman)
                .ToList();
            return pokemans;
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0;
        }

        public bool CreateCatagory(Catagory catagory)
        {
            _context.Catagories.Add(catagory);
            return Save();

        }

        public bool UpdateCatagory(Catagory catagory)
        {
            
            _context.Update(catagory);
            return Save();
        }
    }
}
