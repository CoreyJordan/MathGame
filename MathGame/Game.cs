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
        bool exit = false;
        switch (Mode)
        {
            case "1":
                RunAddition();
                break;
            case "2":
                RunSubtraction();
                break;
            case "3":
                RunMultiplication();
                break;
            case "4":
                RunDivision();
                break;
            default:
                exit = true;
                break; ;
        }

        DisplayResults();
        return exit;
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
    }

    private void RunSubtraction()
    {
        Random rand = new();
        for (int i = 0; i < 10; i++)
        {
            int a = rand.Next(0, 101);
            int b = rand.Next(0, 101);
            int ans = Operations.Subtract(a, b);

            Console.Write(a + " - " + b + " = ");

            int guess = GetGuess();
            CheckGuess(ans, guess);
        }
    }

    private void RunMultiplication()
    {
        Random rand = new();
        for (int i = 0; i < 10; i++)
        {
            int a = rand.Next(0, 101);
            int b = rand.Next(0, 101);
            int ans = Operations.Multiply(a, b);

            Console.Write(a + " x " + b + " = ");

            int guess = GetGuess();
            CheckGuess(ans, guess);
        }
    }

    private void RunDivision()
    {
        Random rand = new();
        for (int i = 0; i < 10; i++)
        {
            int a = rand.Next(0, 101);
            int b = 0;
            while (b == 0 || a % b != 0)
            {
                b = rand.Next(0, 101);
            }
            int ans = Operations.Divide(a, b);

            Console.Write(a + " / " + b + " = ");

            int guess = GetGuess();
            CheckGuess(ans, guess);
        }
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
            Console.WriteLine(Correct);
        }
        else
        {
            Console.WriteLine("Sorry. The answer was " + answer);
        }
    }

    internal void DisplayResults()
    {
        Console.WriteLine(Correct + " of 10 correct: " + Percentage + "%\n");
    }
}
