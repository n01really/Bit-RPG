using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Bit_RPG.Models;

namespace Bit_RPG.Services
{
    public class SaveService
    {
        private static readonly string SaveDirectory = Path.Combine(FileSystem.AppDataDirectory, "Save");
        private static readonly string SaveFilePath = Path.Combine(SaveDirectory, "gamesave.json");

        private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters = { new JsonStringEnumConverter() }
        };

        public static async Task<bool> SaveGameAsync(GameSaveModel gameSave)
        {
            try
            {
                if (!Directory.Exists(SaveDirectory))
                {
                    Directory.CreateDirectory(SaveDirectory);
                }

                string jsonString = JsonSerializer.Serialize(gameSave, JsonOptions);
                await File.WriteAllTextAsync(SaveFilePath, jsonString);
                
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error saving game: {ex.Message}");
                return false;
            }
        }

        public static async Task<GameSaveModel> LoadGameAsync()
        {
            try
            {
                if (!File.Exists(SaveFilePath))
                {
                    return null;
                }

                string jsonString = await File.ReadAllTextAsync(SaveFilePath);
                GameSaveModel gameSave = JsonSerializer.Deserialize<GameSaveModel>(jsonString, JsonOptions);
                
                return gameSave;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading game: {ex.Message}");
                return null;
            }
        }

        public static bool SaveFileExists()
        {
            return File.Exists(SaveFilePath);
        }

        public static void DeleteSave()
        {
            try
            {
                if (File.Exists(SaveFilePath))
                {
                    File.Delete(SaveFilePath);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error deleting save: {ex.Message}");
            }
        }
    }
}
