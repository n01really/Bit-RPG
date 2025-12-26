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
            var humanNpc = new HumanNpc();
            
            return new List<QuestModel>
            {
                // Adventurers Guild Quests
                new QuestModel(
                    "Gather Materials",
                    "Collect various materials for crafting and trade. for: " + humanNpc.GetRandomName(),
                    "100 Gold, 5 XP",
                    "Adventurers Guild",
                    JobRank.E
                ),
                new QuestModel(
                    "Slay Goblins",
                    "Clear out a goblin camp threatening nearby villages. Requested by: " + humanNpc.GetRandomName(),
                    "200 Gold, 10 XP",
                    "Adventurers Guild",
                    JobRank.D
                ),
                new QuestModel(
                    "Explore Ancient Ruins",
                    "Investigate ancient ruins and report findings. Commissioned by: " + humanNpc.GetRandomName(),
                    "400 Gold, 20 XP",
                    "Adventurers Guild",
                    JobRank.C
                ),
                new QuestModel(
                    "Hunt Dragon",
                    "Track and slay a dragon terrorizing the countryside. Urgent request from: " + humanNpc.GetRandomName(),
                    "1000 Gold, 50 XP",
                    "Adventurers Guild",
                    JobRank.B
                ),
                new QuestModel(
                    "Defeat Demon Lord",
                    "Vanquish the demon lord threatening the kingdom. Royal decree from: " + humanNpc.GetRandomNobleRulerName(),
                    "5000 Gold, 200 XP",
                    "Adventurers Guild",
                    JobRank.A
                ),
                
                // Blacksmiths Guild Quests
                new QuestModel(
                    "Commision: Forge Dagger",
                    "Craft a dagger using gathered materials. Client: " + humanNpc.GetRandomName(),
                    "150 Gold, 5 XP",
                    "Blacksmiths Guild",
                    JobRank.E
                ),
                new QuestModel(
                    "Commision: Forge Sword",
                    "Craft a quality sword for a local warrior. Client: " + humanNpc.GetRandomName(),
                    "300 Gold, 10 XP",
                    "Blacksmiths Guild",
                    JobRank.D
                ),
                new QuestModel(
                    "Commision: Craft Armor Set",
                    "Create a full set of armor for a knight. Commissioned by: " + humanNpc.GetRandomNobleName(),
                    "600 Gold, 20 XP",
                    "Blacksmiths Guild",
                    JobRank.C
                ),
                new QuestModel(
                    "Commision: Master Weapon",
                    "Forge a masterwork weapon of legendary quality. Commission from: " + humanNpc.GetRandomNobleRulerName(),
                    "1500 Gold, 50 XP",
                    "Blacksmiths Guild",
                    JobRank.B
                ),
                new QuestModel(
                    "Commision: Legendary Armor",
                    "Create armor imbued with magical properties. Royal commission from: " + humanNpc.GetRandomNobleRulerName(),
                    "7000 Gold, 200 XP",
                    "Blacksmiths Guild",
                    JobRank.A
                ),
                
                // Mages Guild Quests
                new QuestModel(
                    "Commision: Enchant Necklace",
                    "Use magical energies to enchant a necklace. Client: " + humanNpc.GetRandomName(),
                    "200 Gold, 5 XP",
                    "Mages Guild",
                    JobRank.E
                ),
                new QuestModel(
                    "Commision: Brew Potions",
                    "Brew a set of magical potions for the town apothecary. Client: " + humanNpc.GetRandomName(),
                    "350 Gold, 10 XP",
                    "Mages Guild",
                    JobRank.D
                ),
                new QuestModel(
                    "Commision: Dispel Curse",
                    "Remove a curse from a nobleman's estate. Commissioned by: " + humanNpc.GetRandomNobleName(),
                    "700 Gold, 20 XP",
                    "Mages Guild",
                    JobRank.C
                ),
                new QuestModel(
                    "Commision: Seal Portal",
                    "Seal a dimensional portal before creatures escape. Urgent request from: " + humanNpc.GetRandomName(),
                    "1800 Gold, 50 XP",
                    "Mages Guild",
                    JobRank.B
                ),
                new QuestModel(
                    "Commision: Stop Ritual",
                    "Prevent an evil ritual that threatens the kingdom. Royal decree from: " + humanNpc.GetRandomNobleRulerName(),
                    "8000 Gold, 200 XP",
                    "Mages Guild",
                    JobRank.A
                ),
                
                // Thieves Guild Quests
                new QuestModel(
                    "Commision: Pickpocket",
                    "Steal a valuable item from a wealthy target. Client: " + humanNpc.GetRandomName(),
                    "50 Gold, 5 XP",
                    "Thieves Guild",
                    JobRank.E
                ),
                new QuestModel(
                    "Commision: Burglary",
                    "Break into a merchant's house and steal valuables. Client: " + humanNpc.GetRandomName(),
                    "250 Gold, 10 XP",
                    "Thieves Guild",
                    JobRank.D
                ),
                new QuestModel(
                    "Commision: Heist",
                    "Execute a daring heist on a noble's manor. Commissioned by: " + humanNpc.GetRandomName(),
                    "800 Gold, 20 XP",
                    "Thieves Guild",
                    JobRank.C
                ),
                new QuestModel(
                    "Commision: Steal Artifact",
                    "Infiltrate a heavily guarded vault to steal an ancient artifact. High-stakes job from: " + humanNpc.GetRandomName(),
                    "2000 Gold, 50 XP",
                    "Thieves Guild",
                    JobRank.B
                ),
                new QuestModel(
                    "Commision: Crown Jewels",
                    "Pull off the impossible: steal the crown jewels. Legendary contract from: " + humanNpc.GetRandomName(),
                    "10000 Gold, 200 XP",
                    "Thieves Guild",
                    JobRank.A
                )
            };
        }

        public static string CompleteQuest(QuestModel quest, Player player)
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
                // Add default handling for new quests
                default:
                    ApplyQuestRewards(quest, player);
                    break;
            }

            quest.IsCompleted = true;

            if (player.Jobb != null)
            {
                player.Jobb.QuestsCompleted++;
                
                if (player.Jobb.CanRankUp(player.Skills))
                {
                    var oldRank = player.Jobb.Rank;
                    player.Jobb.TryRankUp(player.Skills);
                    return $"\nQuest Completed: {quest.Name}!\nRewards: {quest.Reward}\n*** RANK UP! {oldRank} -> {player.Jobb.Rank} ***";
                }
            }

            return $"\nQuest Completed: {quest.Name}!\nRewards: {quest.Reward}";
        }

        private static void ApplyQuestRewards(QuestModel quest, Player player)
        {
            // Parse rewards from the quest reward string
            var rewardParts = quest.Reward.Split(',');
            foreach (var part in rewardParts)
            {
                var trimmed = part.Trim();
                if (trimmed.Contains("Gold"))
                {
                    var goldAmount = int.Parse(trimmed.Split(' ')[0]);
                    player.Money += goldAmount;
                }
                else if (trimmed.Contains("XP"))
                {
                    var xpAmount = int.Parse(trimmed.Split(' ')[0]);
                    player.Experience += xpAmount;
                }
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
