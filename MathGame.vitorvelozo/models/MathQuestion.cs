namespace Models.MathQuestion;

public enum MathOperation : ushort
{
    Multiplication = '*',
    Division = '/',
    Addition = '+',
    Subtraction = '-',
}

public class Question
{
    public int FirstNumber { get; }
    public int SecondNumber { get; }
    public MathOperation Operation { get; }
    public int Result { get; set; }
    public string? ProvidedAnswer { get; set; }
    public bool IsAnswerCorrect { get; set; } = false;
    public TimeOnly StartTime {get; set; }
    public TimeOnly FinishTime {get; set; }
    public TimeSpan Duration
    {
        get
        {
            return FinishTime - StartTime;
        }
    }


    public Question(int firstNumber, int secondNumber, MathOperation operation)
    {
        FirstNumber = firstNumber;
        SecondNumber = secondNumber;
        Operation = operation;
    }
}
