using Models.MathGame;
using Models.MathQuestion;
using Models.MathSet;
using Spectre.Console;

namespace Views.StartScreen;

public class ResultScreen
{
    public static void Display(MathSet mathSet)
    {
       Console.Clear();
        for (int i = 0; i < mathSet.Games.Count; i++)
        {
            Game game = mathSet.Games[i];
            Table table = new Table()
                .Border(TableBorder.Rounded)
                .Title($"Game {i + 1} ({Markup.Escape(game.Difficulty.ToString())}) | Score: {game.PlayerScore}/{game.GameLength}")
                .AddColumn("Question")
                .AddColumn("Answer")
                .AddColumn("Result");

            foreach (Question question in game.Questions)
            {
                string result = question.IsAnswerCorrect ? "[green]✔ Correct[/]" : "[red]✘ Incorrect[/]";
                table.AddRow(
                    Markup.Escape(question.Result.ToString()),
                    Markup.Escape(question.ProvidedAnswer.ToString()),
                    result);
            }

            AnsiConsole.Write(table);
        }

        string durationFormatted = mathSet.Duration.ToString(@"mm'm 'ss's'");
        AnsiConsole.Write(new Panel($"[bold]{mathSet.totalPoints}/{mathSet.totalQuestions}[/] in {durationFormatted}")
            .Header("SET RESULT", Justify.Center)
            .Border(BoxBorder.Double));
    }
}
