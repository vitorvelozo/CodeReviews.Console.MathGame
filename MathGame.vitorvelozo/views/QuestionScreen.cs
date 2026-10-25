
using Models.MathQuestion;
using Spectre.Console;

namespace Views.QuestionDisplay;

public class QuestionMenu
{
    public static MathOperation GetOperation()
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<MathOperation>()
            .Title("Select an operation")
            .AddChoices(Enum.GetValues<MathOperation>())
        );
    }

    public static string? GetQuestionAnswer(Question question)
    {
        AnsiConsole.Markup($"{question.FirstNumber} {GetOperationSymbol(question.Operation)} {question.SecondNumber} = ");
        return Console.ReadLine();
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
