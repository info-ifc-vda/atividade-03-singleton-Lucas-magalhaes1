class Program
{
    static void Main()
    {
        GameSettings settings1 = GameSettings.Instance;
        Console.WriteLine($"Configuração Inicial: Volume={settings1.Volume}, Resolução={settings1.Resolution}, Dificuldade={settings1.Difficulty}");

        settings1.Volume = 75;
        settings1.Resolution = "1280x720";
        settings1.Difficulty = "Fácil";

        GameSettings settings2 = GameSettings.Instance;
        Console.WriteLine($"Configuração Atualizada: Volume={settings2.Volume}, Resolução={settings2.Resolution}, Dificuldade={settings2.Difficulty}");
        
        GameSettings settings3 = GameSettings.Instance;
        settings3.Volume = 30;
        settings3.Resolution = "1024x768";
        settings3.Difficulty = "Difícil";
        Console.WriteLine($"Nova Atualização: Volume={settings3.Volume}, Resolução={settings3.Resolution}, Dificuldade={settings3.Difficulty}");
        
        Console.WriteLine(settings1 == settings2 && settings2 == settings3 ? "Todas as instâncias são a mesma!" : "Instâncias diferentes!");
    }
}