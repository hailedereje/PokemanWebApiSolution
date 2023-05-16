namespace PokemanWebApi.Model
{
    public class Pokeman
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<PokemanCatagory> PokemanCatagories { get; set; }
        public ICollection<PokemanOwner> PokemanOwners { get; set; }
       
    }
}
