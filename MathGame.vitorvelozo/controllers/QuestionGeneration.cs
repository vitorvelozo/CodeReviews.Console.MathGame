using CodeReviews.Console.MathGame.Models;

namespace CodeReviews.Console.MathGame.Controllers;

public class QuestionGenerator
{
    public int FirstNumber { get; init; }
    public int SecondNumber { get; set; }
    public GameDifficulty GameDifficulty {get; set;}
    public MathOperation Operation { get; init; }
    private int GeneratedNumberCeiling
    {
        get
        {
            if (GameDifficulty == GameDifficulty.Easy)
            {
                return 11;
            }
            else if (GameDifficulty == GameDifficulty.Normal)
            {
                return 51;
            }
            return 101;
        }
    }

    private static readonly Array OperationsList = Enum.GetValues(typeof(MathOperation));

    public QuestionGenerator(GameDifficulty difficulty)
    {
        int randomIndex = Random.Shared.Next(OperationsList.Length);
        Operation = (MathOperation)OperationsList.GetValue(randomIndex)!;

        GameDifficulty = difficulty;
        FirstNumber = Random.Shared.Next(1, GeneratedNumberCeiling);
        SecondNumber = GenerateSecondNumber();
    }

    public QuestionGenerator(GameDifficulty difficulty, MathOperation operation)
    {
        Operation = operation;

        GameDifficulty = difficulty;
        FirstNumber = Random.Shared.Next(1, GeneratedNumberCeiling);
        SecondNumber = GenerateSecondNumber();
    }

    private int[] GetIntDivisors()
    {
        int[] divisors = Enumerable.Range(1, FirstNumber)
                                 .Where(d => FirstNumber % d == 0)
                                 .ToArray();
        return divisors;
    }

    private int GenerateSecondNumber()
    {
        switch (Operation)
        {
            case MathOperation.Subtraction:
                SecondNumber = Random.Shared.Next(1, FirstNumber);
                break;
            case MathOperation.Division:
                int[] divisors = GetIntDivisors();
                SecondNumber = divisors[Random.Shared.Next(divisors.Length)];
                break;
            default:
                SecondNumber = Random.Shared.Next(1, GeneratedNumberCeiling);
                break;
        }
        return SecondNumber;
    }

    public Question GenerateQuestion()
    {
        return new Question(FirstNumber, SecondNumber, Operation);
    }
}
