using CodeReviews.Console.MathGame.Models;
using Spectre.Console;

namespace CodeReviews.Console.MathGame.Views;

public static class GameMenu
{
    private static MenuChoices GetOperation()
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<MenuChoices>()
            .Title("Select an operation")
            .AddChoices(Enum.GetValues<MenuChoices>())
        );
    }

    public static bool Display(MathSet mathSet)
    {
        bool keepPlaying = false;
        MenuChoices operation;
        do
        {    
            operation = GetOperation();
            switch (operation)
            {
                case MenuChoices.NewGame:
                    keepPlaying = true;
                    break;
                case MenuChoices.ShowHistory:
                    ResultScreen.Display(mathSet);
                    break;
            }
        } while (operation == MenuChoices.ShowHistory);
        return keepPlaying;
    }

    private enum MenuChoices
    {
        NewGame,
        ShowHistory,
        ExitProgram,
    }
}