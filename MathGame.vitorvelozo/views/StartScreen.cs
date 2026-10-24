using Models.MathGame;

namespace Views.StartScreen;

public class MainMenu
{
    public static void DisplayWelcome()
    {
        Console.WriteLine("Hello!");
    }

    public static GameDifficulty GetDifficulty()
    {
        GameDifficulty validSelection = default;
        bool validInput = false;
        do
        {
            Console.WriteLine("\nSelect a difficulty:");
            Console.WriteLine("Easy   = 0");
            Console.WriteLine("Normal = 1");
            Console.WriteLine("Hard   = 2");
            Console.Write("=> ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int selection) && Enum.IsDefined(typeof(GameDifficulty), selection))
            {
                validInput = true;
                validSelection = (GameDifficulty)selection;
            }
            else
            {
                Console.WriteLine("Invalid selection. Please enter 0, 1, or 2.");
            }
        } while (!validInput);
        return validSelection;
    }

    public static bool GetRandomMode()
    {
        Console.WriteLine("Do you prefer to manually select operations?");
        Console.Write("(y/any) => ");
        string? input = Console.ReadLine();
        if (input == null)
        {
            return true;
        }
        if (input.Equals("Y") || input.Equals("y"))
        {
            return false;
        }
        return true;
    }
}
