using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bit_RPG.World;
using Bit_RPG.Char.NPCs;
using Bit_RPG.Char;
using Bit_RPG.Jobs;

namespace Bit_RPG.Models
{
    class WeeklyEventModel //Weekly Event Model
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
        public WorldNPC InvolvedNPC { get; set; }
        public Player CurrentLocation { get; set; }
    }

    class JobEventModel //Job Event Model
    {
        public int Id { get; set; }
        public string Description { get; set; }
        
        public Job CurrentJob { get; set; }
        public WorldNPC? InvolvedNPC { get; set; }
        public List<WorldNPC> InvolvedNPCs { get; set; } = new List<WorldNPC>();
        public int JobExperience { get; set; }
        
        private Player? _player;
        public Player? Player
        {
            get => _player;
            set
            {
                _player = value;
                if (_player != null && JobExperience > 0)
                {
                    _player.JobExperience += JobExperience;
                }
            }
        }
    }
}
