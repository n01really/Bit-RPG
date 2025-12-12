using System.Collections.Generic;
using Bit_RPG.Models;

namespace Bit_RPG.Services
{
    public static class NpcTracker
    {
        public static void AddNpc(List<NpcData> npcList, string name, NpcType type, string race, string location, string title = "")
        {
            if (string.IsNullOrWhiteSpace(name))
                return;

            var existingNpc = npcList.Find(n => n.Name == name && n.Location == location);
            if (existingNpc == null)
            {
                npcList.Add(new NpcData
                {
                    Name = name,
                    Title = title,
                    Type = type,
                    Race = race,
                    Location = location
                });
            }
        }

        public static void AddMultipleNpcs(List<NpcData> npcList, IEnumerable<NpcData> npcs)
        {
            foreach (var npc in npcs)
            {
                AddNpc(npcList, npc.Name, npc.Type, npc.Race, npc.Location, npc.Title);
            }
        }
    }
}
