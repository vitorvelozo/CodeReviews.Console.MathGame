using Models.MathGame;

namespace Models.MathSet;

public class MathSet
{
    public List<Game> Games { get; set; } = [];

    public int totalPoints
    {
        get
        {
            return Games.Sum(game => game.PlayerScore);
        }
    }

    public int totalQuestions
    {
        get
        {
            return Games.Sum(game => game.GameLength);
        }
    }

    public TimeSpan Duration
    {
        get
        {
            long totalTicks = Games.Sum(game => game.Duration.Ticks);
            return TimeSpan.FromTicks(totalTicks);
        }
    }

    public void AddGame(Game game)
    {
        Games.Add(game);
    }
}
