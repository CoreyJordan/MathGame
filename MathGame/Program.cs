using MathGame;

Menu menu = new Menu();
List<Game> games = new List<Game>();

menu.DisplayIntro();

bool exit = false;
while (!exit)
{
    String mode = menu.RunMenu();
    if (mode == "5")
    {
        for (int i = 0; i < games.Count; i++) {
            Console.Write("Game " + (i + 1) + ": ");
            games[i].DisplayResults();
        }
    }
    else
    {

        Game newGame = new Game(mode);
        games.Add(newGame);
        exit = newGame.RunGame();
    }
}

menu.DisplayOutro();
Console.ReadLine();