using CodeReviews.Console.MathGame.Models;

namespace CodeReviews.Console.MathGame.Controllers;

public static class QuestionEvaluator
{
    private static int CalculateResult(int firstNumber, int secondNumber, MathOperation operation)
    {
        int result;
        switch (operation)
        {
            case MathOperation.Addition:
                result = firstNumber + secondNumber;
                break;
            case MathOperation.Subtraction:
                result = firstNumber - secondNumber;
                break;
            case MathOperation.Multiplication:
                result = firstNumber * secondNumber;
                break;
            case MathOperation.Division:
                result = firstNumber / secondNumber;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(operation), operation, null);
        }
        return result;
    }

    public static int Evaluate(Question question)
    {
        question.Result = CalculateResult(question.FirstNumber, question.SecondNumber, question.Operation);
        int answer;
        if (int.TryParse(question.ProvidedAnswer, out answer))
        {
            question.IsAnswerCorrect = answer == question.Result;
            return 1;
        }
        return 0;
    }
}
