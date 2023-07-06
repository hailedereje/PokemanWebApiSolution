using System.Text.Json.Serialization;

namespace PokemanWebApi.Model
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Gym { get; set; } = null!;
        [JsonIgnore]
        public Country Country { get; set; } = null!;
        public ICollection<PokemanOwner> PokemanOwners { get; set; } = null!;
    }
}
