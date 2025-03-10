using System;
using System.IO;
using Newtonsoft.Json;

public sealed class GameSettings
{
    private static readonly Lazy<GameSettings> instance = new(() => new GameSettings());
    private readonly string configFilePath = "config.json";
    private GameConfig config = new GameConfig();


    private GameSettings()
    {
        LoadSettings();
    }

    public static GameSettings Instance => instance.Value;

    public int Volume
    {
        get => config.Volume;
        set { config.Volume = value; SaveSettings(); }
    }

    public string Resolution
    {
        get => config.Resolution;
        set { config.Resolution = value; SaveSettings(); }
    }

    public string Difficulty
    {
        get => config.Difficulty;
        set { config.Difficulty = value; SaveSettings(); }
    }

    private void LoadSettings()
    {
        if (File.Exists(configFilePath))
        {
            string json = File.ReadAllText(configFilePath);
            config = JsonConvert.DeserializeObject<GameConfig>(json) ?? new GameConfig();
        }
        else
        {
            config = new GameConfig();
            SaveSettings();
        }
    }

    private void SaveSettings()
    {
        string json = JsonConvert.SerializeObject(config, Formatting.Indented);
        File.WriteAllText(configFilePath, json);
    }
}
