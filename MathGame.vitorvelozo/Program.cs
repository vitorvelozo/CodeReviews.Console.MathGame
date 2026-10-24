using Controllers.Evaluation;
using Controllers.QuestionGeneration;
using Models.MathGame;
using Models.MathQuestion;
using Models.MathSet;
using Views.GameMenu;
using Views.QuestionDisplay;
using Views.StartScreen;

Game RunGame()
{
    GameDifficulty difficulty = MainMenu.GetDifficulty();
    bool randomMode = MainMenu.GetRandomMode();

    Game game = new Game(difficulty, randomMode: randomMode);

    for (int i = 0; i < game.GameLength; i++)
    {
        QuestionGenerator randomGenerator;
        if (!randomMode)
        {
            randomGenerator = new QuestionGenerator(difficulty, QuestionMenu.GetOperation()
            );
        } else
        {
            randomGenerator = new QuestionGenerator(difficulty);
        }
        Question question = randomGenerator.GenerateQuestion();
        game.Questions.Add(question);

        question.StartTime = TimeOnly.FromDateTime(DateTime.Now);
        question.ProvidedAnswer = QuestionMenu.GetQuestionAnswer(question);
        question.FinishTime = TimeOnly.FromDateTime(DateTime.Now);
        game.PlayerScore += QuestionEvaluator.Evaluate(question);
    }
    return game;
}

void Main()
{
    MainMenu.DisplayWelcome();
    MathSet mathSet = new MathSet();

    bool keepPlaying;
    do
    {
        mathSet.AddGame(RunGame());
        keepPlaying = GameMenu.Display(mathSet);
    } while (keepPlaying);

    ResultScreen.Display(mathSet);
}

Main();
