namespace Bit_RPG.Models
{
    public enum LocationType
    {
        Country,
        City,
        Town,
        Village,
        Dungeon
    }

    public class Location
    {
        public string Name { get; set; }
        public LocationType Type { get; set; }
        public string Country { get; set; }

        public Location()
        {
        }

        public Location(string name, LocationType type, string country = "")
        {
            Name = name;
            Type = type;
            Country = country;
        }
    }
}
