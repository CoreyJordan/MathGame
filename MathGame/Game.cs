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
    public String Operation { get; set; }
    public int Correct { get; set; } = 0;
    public int NumberOfQuestions { get; set; } = 0;
    public double Percentage
    {
        get
        {
            return Correct / (double)NumberOfQuestions * 100;
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
                GetNumberOfQuestions();
                RunAddition(NumberOfQuestions);
                Operation = "Addition";
                DisplayResults();
                return false;
            case "2":
                GetNumberOfQuestions();
                RunSubtraction(NumberOfQuestions);
                Operation = "Subtraction";
                DisplayResults();
                return false;
            case "3":
                GetNumberOfQuestions();
                RunMultiplication(NumberOfQuestions);
                Operation = "Multiplication";
                DisplayResults();
                return false;
            case "4":
                GetNumberOfQuestions();
                RunDivision(NumberOfQuestions);
                Operation = "Division";
                DisplayResults();
                return false;
            case "5":
                GetNumberOfQuestions();
                RunRandom(NumberOfQuestions);
                Operation = "All";
                DisplayResults();
                return false;
            default:
                return true;
        }

    }

    private void GetNumberOfQuestions()
    {
        string numberOfQuestions = "";
        while (numberOfQuestions.Equals("") || !int.TryParse(numberOfQuestions, out int result))
        {
            Console.WriteLine("How many questions? ");
            numberOfQuestions = Console.ReadLine()!;
        }
        NumberOfQuestions = int.Parse(numberOfQuestions);
    }

    private void RunAddition(int reps)
    {
        Random rand = new();
        for (int i = 0; i < reps; i++)
        {
            int a = rand.Next(0, 101);
            int b = rand.Next(0, 101);
            int ans = Operations.Add(a, b);

            Console.Write(a + " + " + b + " = ");

            int guess = GetGuess();
            CheckGuess(ans, guess);

        }
    }

    private void RunSubtraction(int reps)
    {
        Random rand = new();
        for (int i = 0; i < reps; i++)
        {
            int a = rand.Next(0, 101);
            int b = rand.Next(0, 101);
            int ans = Operations.Subtract(a, b);

            Console.Write(a + " - " + b + " = ");

            int guess = GetGuess();
            CheckGuess(ans, guess);
        }
    }

    private void RunMultiplication(int reps)
    {
        Random rand = new();
        for (int i = 0; i < reps; i++)
        {
            int a = rand.Next(0, 101);
            int b = rand.Next(0, 101);
            int ans = Operations.Multiply(a, b);

            Console.Write(a + " x " + b + " = ");

            int guess = GetGuess();
            CheckGuess(ans, guess);
        }
    }

    private void RunDivision(int reps)
    {
        Random rand = new();
        for (int i = 0; i < reps; i++)
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

    private void RunRandom(int reps)
    {
        Random rand = new();
        for (int i = 0; i < reps; i++)
        {
            int op = rand.Next(0, 4);
            switch (op)
            {
                case 0:
                    RunAddition(1);
                    break;
                case 1:
                    RunSubtraction(1);
                    break;
                case 2:
                    RunMultiplication(1);
                    break;
                default:
                    RunDivision(1);
                    break;
            }
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
        }
        else
        {
            Console.WriteLine("Sorry. The answer was " + answer);
        }
    }

    internal void DisplayResults()
    {
        Console.Write(Operation + " ");
        Console.Write(Correct + " of " + NumberOfQuestions);
        Console.WriteLine($" correct: {Percentage:0.#}%");
    }
}
