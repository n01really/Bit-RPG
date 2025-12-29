using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bit_RPG.Jobs;

namespace Bit_RPG.Models
{
    public class QuestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Reward { get; set; }
        public string JobName { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsCompleted { get; set; }
        public JobRank RequiredRank { get; set; }

        // Time limit in weeks after acceptance. 0 means no time limit.
        public int WeeksRemaining { get; private set; } = 0;

        public QuestModel(string name, string description, string reward, string jobName, JobRank requiredRank = JobRank.E)
        {
            Name = name;
            Description = description;
            Reward = reward;
            JobName = jobName;
            IsAccepted = false;
            IsCompleted = false;
            RequiredRank = requiredRank;
            WeeksRemaining = 0;
        }

        public string GetRankDisplayText()
        {
            return $"[Rank {RequiredRank}]";
        }

        public void StartQuestTimer(int weeks = 2)
        {
            if (weeks <= 0)
                WeeksRemaining = 0;
            else
                WeeksRemaining = weeks;
        }

        public void TickWeek()
        {
            if (WeeksRemaining > 0)
                WeeksRemaining--;
        }

        public bool IsExpired => WeeksRemaining == 0 && IsAccepted && !IsCompleted;
    }
}
