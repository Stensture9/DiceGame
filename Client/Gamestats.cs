using System.Text.Json;

namespace DiceGame.Client;

public class GameStats
{
    public int Wins { get; set; }

    private const string FilePath = "stats.json";

    public static GameStats Load()
    {
        if (!File.Exists(FilePath))
            return new GameStats();

        try
        {
            string json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<GameStats>(json) ?? new GameStats();
        }
        catch (JsonException)
        {
            return new GameStats();
        }
    }


public void Save()
    {
        string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FilePath, json);
    }
}