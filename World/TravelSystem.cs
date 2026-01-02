using System;
using System.Collections.Generic;
using System.Linq;
using Bit_RPG.Char;
using Bit_RPG.Models;
using PlayerLocation = Bit_RPG.Models.Location;

namespace Bit_RPG.World
{
    public class TravelSystem
    {
        private static readonly Random _random = new Random();

        public static List<TravelDestination> GetAvailableDestinations(Player player)
        {
            if (player.CurrentLocation == null)
            {
                return new List<TravelDestination>();
            }

            var destinations = new List<TravelDestination>();

            switch (player.CurrentLocation.Type)
            {
                case LocationType.Village:
                    destinations.AddRange(GetDestinationsFromVillage(player.CurrentLocation.Name));
                    break;
                case LocationType.Town:
                    destinations.AddRange(GetDestinationsFromTown(player.CurrentLocation.Name));
                    break;
                case LocationType.City:
                    destinations.AddRange(GetDestinationsFromCity(player.CurrentLocation.Name));
                    break;
                case LocationType.Country:
                    destinations.AddRange(GetDestinationsFromCountry(player.CurrentLocation.Name));
                    break;
                case LocationType.Dungeon:
                    destinations.AddRange(GetDestinationsFromDungeon(player.CurrentLocation.Name));
                    break;
            }

            return destinations;
        }

        private static List<TravelDestination> GetDestinationsFromVillage(string villageName)
        {
            var destinations = new List<TravelDestination>();
            var village = WorldData.GetVillage(villageName);

            if (village == null) return destinations;

            // Villages can travel to nearby towns (1 AP)
            foreach (var town in village.NearbyTowns ?? new List<string>())
            {
                destinations.Add(new TravelDestination
                {
                    Name = town,
                    Description = $"Travel to the town of {town}",
                    Type = LocationType.Town,
                    APCost = 1,
                    Country = village.Country
                });
            }

            // Villages can travel to nearby cities (2 AP)
            foreach (var city in village.NearbyCities ?? new List<string>())
            {
                destinations.Add(new TravelDestination
                {
                    Name = city,
                    Description = $"Travel to the city of {city}",
                    Type = LocationType.City,
                    APCost = 2,
                    Country = village.Country
                });
            }

            // Villages can travel to nearby dungeons (1 AP)
            foreach (var dungeon in village.NearbyDungeons ?? new List<string>())
            {
                destinations.Add(new TravelDestination
                {
                    Name = dungeon,
                    Description = $"Venture into {dungeon}",
                    Type = LocationType.Dungeon,
                    APCost = 1,
                    Country = village.Country
                });
            }

            return destinations;
        }

        private static List<TravelDestination> GetDestinationsFromTown(string townName)
        {
            var destinations = new List<TravelDestination>();
            var town = WorldData.GetTown(townName);

            if (town == null) return destinations;

            // Towns can travel to nearby villages (1 AP)
            foreach (var village in town.NearbyVillages ?? new List<string>())
            {
                destinations.Add(new TravelDestination
                {
                    Name = village,
                    Description = $"Travel to the village of {village}",
                    Type = LocationType.Village,
                    APCost = 1,
                    Country = town.Country
                });
            }

            // Towns can travel to nearby cities (1 AP)
            foreach (var city in town.NearbyCities ?? new List<string>())
            {
                destinations.Add(new TravelDestination
                {
                    Name = city,
                    Description = $"Travel to the city of {city}",
                    Type = LocationType.City,
                    APCost = 1,
                    Country = town.Country
                });
            }

            // Towns can travel to nearby dungeons (1 AP)
            foreach (var dungeon in town.NearbyDungeons ?? new List<string>())
            {
                destinations.Add(new TravelDestination
                {
                    Name = dungeon,
                    Description = $"Venture into {dungeon}",
                    Type = LocationType.Dungeon,
                    APCost = 1,
                    Country = town.Country
                });
            }

            return destinations;
        }

        private static List<TravelDestination> GetDestinationsFromCity(string cityName)
        {
            var destinations = new List<TravelDestination>();
            var city = WorldData.GetCity(cityName);

            if (city == null) return destinations;

            // Cities can travel to the capital if not already there (2 AP)
            if (!city.IsCapital)
            {
                var capital = WorldData.GetCapitalOfCountry(city.Country);
                if (!string.IsNullOrEmpty(capital) && capital != cityName)
                {
                    destinations.Add(new TravelDestination
                    {
                        Name = capital,
                        Description = $"Travel to {capital}, the capital of {city.Country}",
                        Type = LocationType.City,
                        APCost = 2,
                        Country = city.Country
                    });
                }
            }

            // Cities can travel to nearby towns (1 AP)
            foreach (var town in city.NearbyTowns ?? new List<string>())
            {
                destinations.Add(new TravelDestination
                {
                    Name = town,
                    Description = $"Travel to the town of {town}",
                    Type = LocationType.Town,
                    APCost = 1,
                    Country = city.Country
                });
            }

            // Cities can travel to nearby villages (1 AP)
            foreach (var village in city.NearbyVillages ?? new List<string>())
            {
                destinations.Add(new TravelDestination
                {
                    Name = village,
                    Description = $"Travel to the village of {village}",
                    Type = LocationType.Village,
                    APCost = 1,
                    Country = city.Country
                });
            }

            // Cities can travel to nearby dungeons (2 AP)
            foreach (var dungeon in city.NearbyDungeons ?? new List<string>())
            {
                destinations.Add(new TravelDestination
                {
                    Name = dungeon,
                    Description = $"Venture into {dungeon}",
                    Type = LocationType.Dungeon,
                    APCost = 2,
                    Country = city.Country
                });
            }

            return destinations;
        }

        private static List<TravelDestination> GetDestinationsFromCountry(string countryName)
        {
            var destinations = new List<TravelDestination>();
            
            // From country level, you can travel to the capital
            var capital = WorldData.GetCapitalOfCountry(countryName);
            if (!string.IsNullOrEmpty(capital))
            {
                destinations.Add(new TravelDestination
                {
                    Name = capital,
                    Description = $"Travel to {capital}, the capital of {countryName}",
                    Type = LocationType.City,
                    APCost = 2,
                    Country = countryName
                });
            }

            return destinations;
        }

        private static List<TravelDestination> GetDestinationsFromDungeon(string dungeonName)
        {
            var destinations = new List<TravelDestination>();
            
            // From a dungeon, you can return to nearby villages
            var nearbyVillages = WorldData.GetVillagesWithDungeon(dungeonName);
            foreach (var village in nearbyVillages)
            {
                destinations.Add(new TravelDestination
                {
                    Name = village.Name,
                    Description = $"Return to the village of {village.Name}",
                    Type = LocationType.Village,
                    APCost = 1,
                    Country = village.Country
                });
            }

            return destinations;
        }

        public static bool TravelTo(Player player, TravelDestination destination)
        {
            if (!player.TrySpendActionPoints(destination.APCost))
            {
                return false;
            }

            player.CurrentLocation = new PlayerLocation(destination.Name, destination.Type, destination.Country);
            return true;
        }

        public static PlayerLocation GetStartingLocation()
        {
            return new PlayerLocation("Arn", LocationType.Town, "Eldoria");
        }
    }
}
