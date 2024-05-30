using MathGame;

Menu menu = new Menu();

menu.DisplayIntro();

bool exit = false;
while (!exit)
{
    String mode = menu.RunMenu();
    Game newGame = new Game(mode);
    exit = newGame.RunGame();
}

menu.DisplayOutro();
Console.ReadLine();