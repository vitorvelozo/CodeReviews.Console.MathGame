using Models.MathGame;
using Models.MathQuestion;
using Models.MathSet;

namespace Views.StartScreen;

public class ResultScreen
{
    public static void Display(MathSet mathSet)
    {
        Console.WriteLine("Results...");
        for (int i = 0; i < mathSet.Games.Count; i++)
        {
            Game game = mathSet.Games[i];
            Console.WriteLine($"==== Game {i+1} ({game.Difficulty}) | Score: ({game.PlayerScore}/{game.GameLength})====");
            foreach (Question question in mathSet.Games[i].Questions)
            {
                string questionText = $"{question.Result} {question.ProvidedAnswer}";
                string symbol = question.IsAnswerCorrect ? "✔" : "✘";
                Console.WriteLine($"{questionText,-10} {symbol}");
            }
            Console.WriteLine();
        }
        string durationFormatted = mathSet.Duration.ToString(@"mm'm 'ss's'");
        Console.WriteLine($"==== RESULT: {mathSet.totalPoints}/{mathSet.totalQuestions} in {durationFormatted} ====");
    }
}
