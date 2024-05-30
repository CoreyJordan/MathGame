using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MathGame;
internal class Game
{
    public String Mode { get; set; }
    public int Correct { get; set; } = 0;
    public double Percentage
    {
        get
        {
            return Correct / 10.0 * 100;
        }
    }

    public Game(String mode)
    {
        Mode = mode;
    }

    internal bool RunGame()
    {

        switch (Mode)
        {
            case "1":
                RunAddition();
                return false;
            case "2":
                return false;
            case "3":
                return false;
            case "4":
                return false;
            case "5":
                return false;
            default:
                return true;
        }
    }

    private void RunAddition()
    {
        Random rand = new();
        for (int i = 0; i < 10; i++)
        {
            int a = rand.Next(0, 101);
            int b = rand.Next(0, 101);
            int ans = Operations.Add(a, b);

            Console.Write(a + " + " + b + " = ");

            int guess = GetGuess();
            CheckGuess(ans, guess);

        }
        DisplayResults();


    }

    private int GetGuess()
    {
        int numGuess;

        String guess = Console.ReadLine()!;

        while (!int.TryParse(guess, out numGuess))
        {
            Console.WriteLine("Not a valid number");
            guess = Console.ReadLine()!;
        }

        return numGuess;
    }

    private void CheckGuess(int answer, int guess)
    {
        Console.WriteLine();
        if (answer == guess)
        {
            Console.WriteLine("Correct!");
            Correct++;
        }
        else
        {
            Console.WriteLine("Sorry. The answer was " + answer);
        }
    }

    private void DisplayResults()
    {
        Console.WriteLine();
        Console.WriteLine(Correct + " of 10 correct: " + Percentage + "%\n");
    }
}
