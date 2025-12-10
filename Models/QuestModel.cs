using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit_RPG.Models
{
    public class QuestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Reward { get; set; }
        public string JobName { get; set; }
        public bool IsAccepted { get; set; }

        public QuestModel(string name, string description, string reward, string jobName)
        {
            Name = name;
            Description = description;
            Reward = reward;
            JobName = jobName;
            IsAccepted = false;
        }
    }
}
