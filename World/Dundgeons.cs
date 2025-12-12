using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit_RPG.World
{
    internal class Dundgeons
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public int FloorCount { get; set; }
    }
    internal class Dungeons
    {
        public static void lowerLevelDungeons()
        {
            Dundgeons dungeon1 = new Dundgeons
            {
                Name = "Caverns of Chaos",
                Description = "A dark and twisting network of caves filled with goblins and bats.",
                Level = 10,
                FloorCount = 15
            };

            Dundgeons dungeon2 = new Dundgeons
            {
                Name = "Forest of Shadows",
                Description = "An eerie forest where shadows come to life and ambush unwary travelers.",
                Level = 2,
                FloorCount = 1
            };
            Dundgeons dungeon3 = new Dundgeons
            {
                Name = "Ruins of the Ancients",
                Description = "Ancient ruins inhabited by undead warriors and spectral guardians.",
                Level = 3,
                FloorCount = 5
            };
            Dundgeons dungeon4 = new Dundgeons
            {
                Name = "Crystal Caves",
                Description = "Glittering caves filled with crystal formations and dangerous cave dwellers.",
                Level = 4,
                FloorCount = 10
            };

            Dundgeons dungeon5 = new Dundgeons
            {
                Name = "Abandoned Mine",
                Description = "A long-forgotten mine overrun by hostile creatures and treacherous traps.",
                Level = 1,
                FloorCount = 6
            };
        }
    }
}