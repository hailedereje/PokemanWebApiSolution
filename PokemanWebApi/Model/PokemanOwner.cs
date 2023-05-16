namespace PokemanWebApi.Model
{
    public class PokemanOwner
    {
        public int PokemanId { get; set; }
        public int OwnerId { get; set; }
        public Pokeman Pokeman { get; set; }
        public Owner Owner { get; set; }
    }
}
