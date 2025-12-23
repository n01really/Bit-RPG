using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bit_RPG.Char;
using Bit_RPG.Char.NPCs;
using Bit_RPG.Models;

namespace Bit_RPG.Jobs
{
    internal class Quests
    {
        public static List<QuestModel> GetAvailableQuests()
        {
            return new List<QuestModel>
            {
                new QuestModel(
                    "Gather Materials",
                    "Collect various materials for crafting and trade. for: " + new HumanNpc().GetRandomName(),
                    "100 Gold, 5 XP",
                    "Adventurers Guild"
                ),
                new QuestModel(
                    "Commision: Forge Dagger",
                    "Craft a dagger using gathered materials.",
                    "150 Gold, 5 XP",
                    "Blacksmiths Guild"
                ),
                new QuestModel(
                    "Commision: Enchant Necklace",
                    "Use magical energies to enchant a necklace.",
                    "200 Gold, 5 XP",
                    "Mages Guild"
                ),
                new QuestModel(
                    "Commision: Pickpocket",
                    "Steal a valuable item from a wealthy target.",
                    "50 Gold, 5 XP",
                    "Thieves Guild"
                )
            };
        }
        public static List<QuestModel> GetAcceptedQuests(Player player)
        {
            return player.ActiveQuests;
        }

        public static void CompleteQuest(QuestModel quest, Player player)
        {
            switch (quest.Name)
            {
                case "Gather Materials":
                    GatherMaterialsQuest(player, player.Skills);
                    break;
                case "Commision: Forge Dagger":
                    ForgeDaggerQuest(player, player.Skills);
                    break;
                case "Commision: Enchant Necklace":
                    EnchantNecklaceQuest(player, player.Skills);
                    break;
                case "Commision: Pickpocket":
                    PickpocketQuest(player, player.Skills);
                    break;
            }
        }

        public static void GatherMaterialsQuest(Player player, Skills skills)
        {
            player.Money += 100;
            player.Experience += 5;
            skills.Alchemy += 1;
        }

        public static void ForgeDaggerQuest(Player player, Skills skills)
        {
            player.Money += 150;
            player.Experience += 5;
            skills.Smithing += 1;
        }

        public static void EnchantNecklaceQuest(Player player, Skills skills)
        {
            player.Money += 200;
            player.Experience += 5;
            skills.Enchanting += 1;
        }

        public static void PickpocketQuest(Player player, Skills skills)
        {
            player.Money += 50;
            player.Experience += 5;
            skills.SlightofHand += 1;
        }
    }

}
