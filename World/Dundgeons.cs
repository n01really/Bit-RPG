using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bit_RPG.Models;

namespace Bit_RPG.World
{
    internal class Dungeons
    {
        public static void lowerLevelDungeons()
        {
            DungeonModel dungeon1 = new DungeonModel
            {
                Name = "Caverns of Chaos",
                Description = "A dark and twisting network of caves filled with goblins and bats.",
                Level = 10,
                FloorCount = 15
            };

            DungeonModel dungeon2 = new DungeonModel
            {
                Name = "Forest of Shadows",
                Description = "An eerie forest where shadows come to life and ambush unwary travelers.",
                Level = 2,
                FloorCount = 1
            };
            DungeonModel dungeon3 = new DungeonModel
            {
                Name = "Ruins of the Ancients",
                Description = "Ancient ruins inhabited by undead warriors and spectral guardians.",
                Level = 3,
                FloorCount = 5
            };
            DungeonModel dungeon4 = new DungeonModel
            {
                Name = "Crystal Caves",
                Description = "Glittering caves filled with crystal formations and dangerous cave dwellers.",
                Level = 4,
                FloorCount = 10
            };

            DungeonModel dungeon5 = new DungeonModel
            {
                Name = "Abandoned Mine",
                Description = "A long-forgotten mine overrun by hostile creatures and treacherous traps.",
                Level = 1,
                FloorCount = 6
            };
        }
    }
}