namespace PokemanWebApi.Model
{
    public class Pokeman
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Review> Reviews { get; set; } = null!;
        public ICollection<PokemanCatagory> PokemanCatagories { get; set; } = null!;
        public ICollection<PokemanOwner> PokemanOwners { get; set; } = null!;
       
    }
}
