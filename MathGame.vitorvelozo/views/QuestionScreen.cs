
using Models.MathQuestion;

namespace Views.QuestionDisplay;

public class QuestionMenu
{
    public static MathOperation GetOperation()
    {
        while (true)
        {
            DisplayOperationMenu();

            string? input = Console.ReadLine()?.Trim();

            if (TryParseOperation(input, out MathOperation operation))
                return operation;

            Console.WriteLine("Invalid selection. Please enter +, -, *, or /.");
        }
    }

    public static string? GetQuestionAnswer(Question question)
    {
        Console.Write($"{question.FirstNumber} {GetOperationSymbol(question.Operation)} {question.SecondNumber} = ");
        return Console.ReadLine();
    }

    private static void DisplayOperationMenu()
    {
        Console.WriteLine("\nSelect an operation:");
        Console.WriteLine("Addition       = +");
        Console.WriteLine("Subtraction    = -");
        Console.WriteLine("Multiplication = *");
        Console.WriteLine("Division       = /");
        Console.Write("=> ");
    }

    private static bool TryParseOperation(
        string? input,
        out MathOperation operation)
    {
        operation = input switch
        {
            "+" => MathOperation.Addition,
            "-" => MathOperation.Subtraction,
            "*" => MathOperation.Multiplication,
            "/" => MathOperation.Division,
            _ => default
        };

        return input is "+" or "-" or "*" or "/";
    }

    private static char GetOperationSymbol(MathOperation operation) =>
        operation switch
        {
            MathOperation.Addition       => '+',
            MathOperation.Subtraction    => '-',
            MathOperation.Multiplication => '*',
            MathOperation.Division       => '/',
            _                            => '?'
        };
}
