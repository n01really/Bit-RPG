using System;
using System.Collections.Generic;
using Bit_RPG.Char;
using Bit_RPG.Char.NPCs;

namespace Bit_RPG.Models
{
    public class GameSaveModel
    {
        public DateTime SaveDate { get; set; }
        public int CurrentWeek { get; set; }
        public string EventLog { get; set; }
        public Player Player { get; set; }
        public List<NpcData> GeneratedNpcs { get; set; } = new List<NpcData>();
        public TownsModels CurrentTown { get; set; }
        public GameEventsData CurrentEvents { get; set; }

        public GameSaveModel()
        {
            SaveDate = DateTime.Now;
        }
    }

    public class NpcData
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public NpcType Type { get; set; }
        public string Race { get; set; }
        public string Location { get; set; }
    }

    public enum NpcType
    {
        Townsperson,
        Mayor,
        Noble,
        Ruler,
        Merchant,
        Headman
    }

    public class GameEventsData
    {
        public bool IsWarActive { get; set; }
        public bool IsBorderClosed { get; set; }
        public bool IsPlagueActive { get; set; }
        public bool IsBanditRaidActive { get; set; }
        public bool IsFamineActive { get; set; }
        public bool IsFireActive { get; set; }
        public bool IsEarthquakeActive { get; set; }
        public bool IsFloodActive { get; set; }
        public bool IsDroughtActive { get; set; }
        public bool IsStormActive { get; set; }
    }
}
