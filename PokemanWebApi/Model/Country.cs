namespace PokemanWebApi.Model
{
    public class Country
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = null!;
        public ICollection<Owner> Owner { get; set; } = null!;
    }
}
