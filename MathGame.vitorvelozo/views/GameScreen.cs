using Models.MathSet;
using Views.StartScreen;

namespace Views.GameMenu;

public class GameMenu
{
    private static void DisplayOptions()
    {
        Console.WriteLine("\nSelect an operation:");
        Console.WriteLine("New game        = 0");
        Console.WriteLine("Show history    = 1");
        Console.WriteLine("End the program = 2");
        Console.Write("=> ");
    }

    public static bool Display(MathSet mathSet)
    {
        bool leaveMenu = false;
        bool keepPlaying = false;
        string? operation;
        string[] validOperations = {"0", "1", "2"};
        do {
            DisplayOptions();
            operation = Console.ReadLine();
            switch (operation)
            {
                case "0":
                    leaveMenu = true;
                    keepPlaying = true;
                    break;
                case "1":
                    ResultScreen.Display(mathSet);
                    break;
                case "2":
                    leaveMenu = true;
                    break;
                default:
                    Console.WriteLine($"Invalid input: {operation}. Valid options are {string.Join(", ", validOperations)}");
                    break;
            }
        } while (!leaveMenu);
        return keepPlaying;
    }
}