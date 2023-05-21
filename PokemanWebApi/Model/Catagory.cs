namespace PokemanWebApi.Model
{
    public class Catagory
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<PokemanCatagory> PokemanCatagories { get; set; } = null!;
    }
}
