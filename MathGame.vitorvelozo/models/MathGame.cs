namespace CodeReviews.Console.MathGame.Models;

public enum GameDifficulty : int
{
    Easy = 0,
    Normal = 1,
    Hard = 2,
}
public class Game(GameDifficulty difficulty = GameDifficulty.Normal, int length = 5, bool randomMode = true)
{
    public List<Question> Questions { get; set; } = [];
    public int PlayerScore { get; set; } = 0;
    public int GameLength { get; } = length;
    public GameDifficulty Difficulty { get; } = difficulty;
    public bool IsRandomMode { get; } = randomMode;
    public TimeSpan Duration
    {
        get
        {
            long totalTicks = Questions.Sum(question => question.Duration.Ticks);
            return TimeSpan.FromTicks(totalTicks);
        }
    }
}
