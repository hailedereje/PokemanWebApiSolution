namespace PokemanWebApi.Model
{
    public class PokemanCatagory
    {
        public int PokemanId {  get; set; }
        public int CatagoryId { get; set; }
        public Pokeman Pokeman { get; set; } = null!;
        public Catagory Catagory { get; set;} = null!;
    }
}
