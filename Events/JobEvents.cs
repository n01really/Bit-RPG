using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bit_RPG.Char;
using Bit_RPG.Char.NPCs;
using Bit_RPG.Jobs;
using Bit_RPG.Models;

namespace Bit_RPG.Events
{
    internal class JobEvents
    {
        private static readonly Random _random = new Random();

        public static bool CanTriggerAdventureGuildEvent(Player player)
        {
            return player.Jobb != null && player.Jobb.Name == "Adventurers Guild";
        }
        public static bool CanTriggerBlacksmithGuildEvent(Player player)
        {
            return player.Jobb != null && player.Jobb.Name == "Blacksmiths Guild";
        }
        public static bool CanTriggerMagesGuildEvent(Player player)
        {
            return player.Jobb != null && player.Jobb.Name == "Mages Guild";
        }
        public static bool CanTriggerThievesGuildEvent(Player player)
        {
            return player.Jobb != null && player.Jobb.Name == "Thieves Guild";
        }

        private static WorldNPC GetRandomGuildMember(Player player)
        {
            return player.Jobb?.GuildMembers != null && player.Jobb.GuildMembers.Count > 0
                ? player.Jobb.GuildMembers[_random.Next(player.Jobb.GuildMembers.Count)]
                : null;
        }

        public static JobEventModel AdventureGuildEvent(Player player)
        {
            int eventId = _random.Next(1, 5);
            
            return eventId switch
            {
                1 => new JobEventModel
                {
                    Id = 1,
                    Description = $"You and your fellow adventurers {string.Join(", ", new[] { GetRandomGuildMember(player), GetRandomGuildMember(player), GetRandomGuildMember(player) }.Where(npc => npc != null).Select(npc => npc.Name))} are drinking to your hearts' content at the local guild hall",
                    InvolvedNPCs = new List<WorldNPC>
                    {
                        GetRandomGuildMember(player),
                        GetRandomGuildMember(player),
                        GetRandomGuildMember(player)
                    }.Where(npc => npc != null).ToList(),
                    CurrentJob = player.Jobb,
                    JobExperience = 5,
                    Player = player
                },
                2 => new JobEventModel
                {
                    Id = 2,
                    Description = $"The guild master {player.Jobb.GuildMaster?.Name ?? "Unknown"} gives you praise for your work ethic",
                    CurrentJob = player.Jobb,
                    InvolvedNPC = player.Jobb.GuildMaster,
                    JobExperience = 10,
                    Player = player
                },
                3 => new JobEventModel
                {
                    Id = 3,
                    Description = $"You met your guild mate {GetRandomGuildMember(player)?.Name ?? "Unknown"} at the training grounds",
                    CurrentJob = player.Jobb,
                    InvolvedNPC = GetRandomGuildMember(player),
                    JobExperience = 8,
                    Player = player
                },
                4 => new JobEventModel
                {
                    Id = 4,
                    Description = $"You and your guild mate {GetRandomGuildMember(player)?.Name ?? "Unknown"} went on a quest together and returned victorious",
                    CurrentJob = player.Jobb,
                    InvolvedNPC = GetRandomGuildMember(player),
                    JobExperience = 15,
                    Player = player
                },
                _ => new JobEventModel
                {
                    Id = 1,
                    Description = $"You and your fellow adventurers {string.Join(", ", new[] { GetRandomGuildMember(player), GetRandomGuildMember(player), GetRandomGuildMember(player) }.Where(npc => npc != null).Select(npc => npc.Name))} are drinking to your hearts' content at the local guild hall",
                    InvolvedNPCs = new List<WorldNPC>
                    {
                        GetRandomGuildMember(player),
                        GetRandomGuildMember(player),
                        GetRandomGuildMember(player)
                    }.Where(npc => npc != null).ToList(),
                    CurrentJob = player.Jobb,
                    JobExperience = 5,
                    Player = player
                }
            };
        }

        public static JobEventModel BlacksmithGuildEvent(Player player)
        {
            int eventId = _random.Next(5, 9);

            return eventId switch
            {
                5 => new JobEventModel
                {
                    Id = 5,
                    Description = $"You are working in the forge when a fellow blacksmith {GetRandomGuildMember(player)?.Name ?? "Unknown"} approaches you for advice",
                    InvolvedNPC = GetRandomGuildMember(player),
                    CurrentJob = player.Jobb,
                    JobExperience = 7,
                    Player = player
                },
                6 => new JobEventModel
                {
                    Id = 6,
                    Description = $"The guild master {player.Jobb.GuildMaster?.Name ?? "Unknown"} inspects your latest work and nods approvingly",
                    InvolvedNPC = player.Jobb.GuildMaster,
                    CurrentJob = player.Jobb,
                    JobExperience = 12,
                    Player = player
                },
                7 => new JobEventModel
                {
                    Id = 7,
                    Description = $"You collaborate with other guild members {string.Join(", ", new[] { GetRandomGuildMember(player), GetRandomGuildMember(player) }.Where(npc => npc != null).Select(npc => npc.Name))} to forge a masterpiece weapon",
                    InvolvedNPCs = new List<WorldNPC>
                    {
                        GetRandomGuildMember(player),
                        GetRandomGuildMember(player)
                    }.Where(npc => npc != null).ToList(),
                    CurrentJob = player.Jobb,
                    JobExperience = 18,
                    Player = player
                },
                8 => new JobEventModel
                {
                    Id = 8,
                    Description = $"A guild mate {GetRandomGuildMember(player)?.Name ?? "Unknown"} shares a secret tempering technique with you",
                    InvolvedNPC = GetRandomGuildMember(player),
                    CurrentJob = player.Jobb,
                    JobExperience = 10,
                    Player = player
                },
                _ => new JobEventModel
                {
                    Id = 5,
                    Description = $"You are working in the forge when a fellow blacksmith {GetRandomGuildMember(player)?.Name ?? "Unknown"} approaches you for advice",
                    InvolvedNPC = GetRandomGuildMember(player),
                    CurrentJob = player.Jobb,
                    JobExperience = 7,
                    Player = player
                }
            };
        }

        public static JobEventModel MagesGuildEvent(Player player)
        {
            int eventId = _random.Next(9, 13);

            return eventId switch
            {
                9 => new JobEventModel
                {
                    Id = 9,
                    Description = $"You attend an arcane lecture hosted by the guild master {player.Jobb.GuildMaster?.Name ?? "Unknown"}",
                    InvolvedNPC = player.Jobb.GuildMaster,
                    CurrentJob = player.Jobb,
                    JobExperience = 12,
                    Player = player
                },
                10 => new JobEventModel
                {
                    Id = 10,
                    Description = $"A fellow mage {GetRandomGuildMember(player)?.Name ?? "Unknown"} asks for your assistance with a complex spell",
                    InvolvedNPC = GetRandomGuildMember(player),
                    CurrentJob = player.Jobb,
                    JobExperience = 8,
                    Player = player
                },
                11 => new JobEventModel
                {
                    Id = 11,
                    Description = $"You participate in a group ritual with other guild members {string.Join(", ", new[] { GetRandomGuildMember(player), GetRandomGuildMember(player), GetRandomGuildMember(player) }.Where(npc => npc != null).Select(npc => npc.Name))}",
                    InvolvedNPCs = new List<WorldNPC>
                    {
                        GetRandomGuildMember(player),
                        GetRandomGuildMember(player),
                        GetRandomGuildMember(player)
                    }.Where(npc => npc != null).ToList(),
                    CurrentJob = player.Jobb,
                    JobExperience = 15,
                    Player = player
                },
                12 => new JobEventModel
                {
                    Id = 12,
                    Description = $"You discover a rare tome in the guild library with help from a guild mate {GetRandomGuildMember(player)?.Name ?? "Unknown"}",
                    InvolvedNPC = GetRandomGuildMember(player),
                    CurrentJob = player.Jobb,
                    JobExperience = 20,
                    Player = player
                },
                _ => new JobEventModel
                {
                    Id = 9,
                    Description = $"You attend an arcane lecture hosted by the guild master {player.Jobb.GuildMaster?.Name ?? "Unknown"}",
                    InvolvedNPC = player.Jobb.GuildMaster,
                    CurrentJob = player.Jobb,
                    JobExperience = 12,
                    Player = player
                }
            };
        }

        public static JobEventModel ThievesGuildEvent(Player player)
        {
            int eventId = _random.Next(13, 17);

            return eventId switch
            {
                13 => new JobEventModel
                {
                    Id = 13,
                    Description = $"The guild master {player.Jobb.GuildMaster?.Name ?? "Unknown"} assigns you a high-stakes heist",
                    InvolvedNPC = player.Jobb.GuildMaster,
                    CurrentJob = player.Jobb,
                    JobExperience = 14,
                    Player = player
                },
                14 => new JobEventModel
                {
                    Id = 14,
                    Description = $"You practice lockpicking with a fellow thief {GetRandomGuildMember(player)?.Name ?? "Unknown"} in the guild's training room",
                    InvolvedNPC = GetRandomGuildMember(player),
                    CurrentJob = player.Jobb,
                    JobExperience = 9,
                    Player = player
                },
                15 => new JobEventModel
                {
                    Id = 15,
                    Description = $"You and your crew {string.Join(", ", new[] { GetRandomGuildMember(player), GetRandomGuildMember(player) }.Where(npc => npc != null).Select(npc => npc.Name))} successfully pull off a daring robbery",
                    InvolvedNPCs = new List<WorldNPC>
                    {
                        GetRandomGuildMember(player),
                        GetRandomGuildMember(player)
                    }.Where(npc => npc != null).ToList(),
                    CurrentJob = player.Jobb,
                    JobExperience = 22,
                    Player = player
                },
                16 => new JobEventModel
                {
                    Id = 16,
                    Description = $"A guild mate {GetRandomGuildMember(player)?.Name ?? "Unknown"} teaches you a new stealth technique in the shadows",
                    InvolvedNPC = GetRandomGuildMember(player),
                    CurrentJob = player.Jobb,
                    JobExperience = 11,
                    Player = player
                },
                _ => new JobEventModel
                {
                    Id = 13,
                    Description = $"The guild master {player.Jobb.GuildMaster?.Name ?? "Unknown"} assigns you a high-stakes heist",
                    InvolvedNPC = player.Jobb.GuildMaster,
                    CurrentJob = player.Jobb,
                    JobExperience = 14,
                    Player = player
                }
            };
        }

        public static JobEventModel GetJobEventById(int id, Player player)
        {
            return id switch
            {
                1 => new JobEventModel
                {
                    Id = 1,
                    Description = $"You and your fellow adventurers {string.Join(", ", new[] { GetRandomGuildMember(player), GetRandomGuildMember(player), GetRandomGuildMember(player) }.Where(npc => npc != null).Select(npc => npc.Name))} are drinking to your hearts' content at the local guild hall",
                    InvolvedNPCs = new List<WorldNPC>
                    {
                        GetRandomGuildMember(player),
                        GetRandomGuildMember(player),
                        GetRandomGuildMember(player)
                    }.Where(npc => npc != null).ToList(),
                    CurrentJob = player.Jobb,
                    JobExperience = 5,
                    Player = player
                },
                2 => new JobEventModel
                {
                    Id = 2,
                    Description = $"The guild master {player.Jobb?.GuildMaster?.Name ?? "Unknown"} gives you praise for your work ethic",
                    CurrentJob = player.Jobb,
                    InvolvedNPC = player.Jobb?.GuildMaster,
                    JobExperience = 10,
                    Player = player
                },
                3 => new JobEventModel
                {
                    Id = 3,
                    Description = $"You met your guild mate {GetRandomGuildMember(player)?.Name ?? "Unknown"} at the training grounds",
                    CurrentJob = player.Jobb,
                    InvolvedNPC = GetRandomGuildMember(player),
                    JobExperience = 8,
                    Player = player
                },
                4 => new JobEventModel
                {
                    Id = 4,
                    Description = $"You and your guild mate {GetRandomGuildMember(player)?.Name ?? "Unknown"} went on a quest together and returned victorious",
                    CurrentJob = player.Jobb,
                    InvolvedNPC = GetRandomGuildMember(player),
                    JobExperience = 15,
                    Player = player
                },
                5 => new JobEventModel
                {
                    Id = 5,
                    Description = $"You are working in the forge when a fellow blacksmith {GetRandomGuildMember(player)?.Name ?? "Unknown"} approaches you for advice",
                    InvolvedNPC = GetRandomGuildMember(player),
                    CurrentJob = player.Jobb,
                    JobExperience = 7,
                    Player = player
                },
                6 => new JobEventModel
                {
                    Id = 6,
                    Description = $"The guild master {player.Jobb?.GuildMaster?.Name ?? "Unknown"} inspects your latest work and nods approvingly",
                    InvolvedNPC = player.Jobb?.GuildMaster,
                    CurrentJob = player.Jobb,
                    JobExperience = 12,
                    Player = player
                },
                7 => new JobEventModel
                {
                    Id = 7,
                    Description = $"You collaborate with other guild members {string.Join(", ", new[] { GetRandomGuildMember(player), GetRandomGuildMember(player) }.Where(npc => npc != null).Select(npc => npc.Name))} to forge a masterpiece weapon",
                    InvolvedNPCs = new List<WorldNPC>
                    {
                        GetRandomGuildMember(player),
                        GetRandomGuildMember(player)
                    }.Where(npc => npc != null).ToList(),
                    CurrentJob = player.Jobb,
                    JobExperience = 18,
                    Player = player
                },
                8 => new JobEventModel
                {
                    Id = 8,
                    Description = $"A guild mate {GetRandomGuildMember(player)?.Name ?? "Unknown"} shares a secret tempering technique with you",
                    InvolvedNPC = GetRandomGuildMember(player),
                    CurrentJob = player.Jobb,
                    JobExperience = 10,
                    Player = player
                },
                9 => new JobEventModel
                {
                    Id = 9,
                    Description = $"You attend an arcane lecture hosted by the guild master {player.Jobb?.GuildMaster?.Name ?? "Unknown"}",
                    InvolvedNPC = player.Jobb?.GuildMaster,
                    CurrentJob = player.Jobb,
                    JobExperience = 12,
                    Player = player
                },
                10 => new JobEventModel
                {
                    Id = 10,
                    Description = $"A fellow mage {GetRandomGuildMember(player)?.Name ?? "Unknown"} asks for your assistance with a complex spell",
                    InvolvedNPC = GetRandomGuildMember(player),
                    CurrentJob = player.Jobb,
                    JobExperience = 8,
                    Player = player
                },
                11 => new JobEventModel
                {
                    Id = 11,
                    Description = $"You participate in a group ritual with other guild members {string.Join(", ", new[] { GetRandomGuildMember(player), GetRandomGuildMember(player), GetRandomGuildMember(player) }.Where(npc => npc != null).Select(npc => npc.Name))}",
                    InvolvedNPCs = new List<WorldNPC>
                    {
                        GetRandomGuildMember(player),
                        GetRandomGuildMember(player),
                        GetRandomGuildMember(player)
                    }.Where(npc => npc != null).ToList(),
                    CurrentJob = player.Jobb,
                    JobExperience = 15,
                    Player = player
                },
                12 => new JobEventModel
                {
                    Id = 12,
                    Description = $"You discover a rare tome in the guild library with help from a guild mate {GetRandomGuildMember(player)?.Name ?? "Unknown"}",
                    InvolvedNPC = GetRandomGuildMember(player),
                    CurrentJob = player.Jobb,
                    JobExperience = 20,
                    Player = player
                },
                13 => new JobEventModel
                {
                    Id = 13,
                    Description = $"The guild master {player.Jobb?.GuildMaster?.Name ?? "Unknown"} assigns you a high-stakes heist",
                    InvolvedNPC = player.Jobb?.GuildMaster,
                    CurrentJob = player.Jobb,
                    JobExperience = 14,
                    Player = player
                },
                14 => new JobEventModel
                {
                    Id = 14,
                    Description = $"You practice lockpicking with a fellow thief {GetRandomGuildMember(player)?.Name ?? "Unknown"} in the guild's training room",
                    InvolvedNPC = GetRandomGuildMember(player),
                    CurrentJob = player.Jobb,
                    JobExperience = 9,
                    Player = player
                },
                15 => new JobEventModel
                {
                    Id = 15,
                    Description = $"You and your crew {string.Join(", ", new[] { GetRandomGuildMember(player), GetRandomGuildMember(player) }.Where(npc => npc != null).Select(npc => npc.Name))} successfully pull off a daring robbery",
                    InvolvedNPCs = new List<WorldNPC>
                    {
                        GetRandomGuildMember(player),
                        GetRandomGuildMember(player)
                    }.Where(npc => npc != null).ToList(),
                    CurrentJob = player.Jobb,
                    JobExperience = 22,
                    Player = player
                },
                16 => new JobEventModel
                {
                    Id = 16,
                    Description = $"A guild mate {GetRandomGuildMember(player)?.Name ?? "Unknown"} teaches you a new stealth technique in the shadows",
                    InvolvedNPC = GetRandomGuildMember(player),
                    CurrentJob = player.Jobb,
                    JobExperience = 11,
                    Player = player
                },
                _ => null
            };
        }
    }
}
