using CodeReviews.Console.MathGame.Models;
using Spectre.Console;

namespace CodeReviews.Console.MathGame.Views;

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
        System.Console.Clear();
        return !randomMode;
    }
}
