namespace PokemanWebApi.Model
{
    public class PokemanCatagory
    {
        public int PokemanId {  get; set; }
        public int CatagoryId { get; set; }
        public Pokeman Pokeman { get; set; }
        public Catagory Catagory { get; set;}
    }
}
