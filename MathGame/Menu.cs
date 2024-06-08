using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame;
internal class Menu
{
    private String Greeting { get; set; } = "Welcome to Math Game!";
    private String Outro { get; set; } = "Thanks for playing! Goodbye!";
    private String BadChoice { get; set; } = "That is not a valid selection.\n";
    private String Options { get; set; } = "\n" +
        "SELECT a game mode: \n" +
        "1) Addition\n" +
        "2) Subtraction\n" +
        "3) Multiplication\n" +
        "4) Division\n" +
        "5) Random\n" +
        "D) Previous Results\n" +
        "X) Exit\n";
    private List<String> Choices { get; set; } = new List<string> {"1", "2", "3", "4", "5", "D", "X"};

    internal void DisplayIntro()
    {
        Console.WriteLine(Greeting);
    }

    internal String RunMenu()
    {
        Console.WriteLine(Options);
        String choice = Console.ReadLine()!.ToUpper();
        while (!Choices.Contains(choice))
        {
            Console.WriteLine(BadChoice);
            Console.WriteLine(Options);
            choice = Console.ReadLine()!.ToUpper();
        }

        return choice;
    }

    internal void DisplayOutro()
    {
        Console.WriteLine(Outro);
    }
}
