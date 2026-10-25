using Models.MathGame;
using Spectre.Console;

namespace Views.StartScreen;

public static class MainMenu
{
    public static void DisplayWelcome()
    {
        AnsiConsole.MarkupLine("Hello! Welcome to the [cyan]math game[/]!");
    }

    public static GameDifficulty GetDifficulty()
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<GameDifficulty>()
            .Title("Select a [red]difficulty[/]")
            .AddChoices(Enum.GetValues<GameDifficulty>())
        );
    }

    public static bool GetRandomMode()
    {
        bool randomMode = AnsiConsole.Confirm("Do you prefer to [red]manually select[/] operations?");
        Console.Clear();
        return !randomMode;
    }
}
