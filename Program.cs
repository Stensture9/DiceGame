namespace DiceGame;
using DiceGame.Client;

class Program
{
    static void Main()
    {
        Dice dice = new();
        GameStats stats = GameStats.Load();

        while (true)
        {
            Console.WriteLine("================================");
            Console.WriteLine("DICEGAME");
            Console.WriteLine("press (ENTER) to play");
            Console.WriteLine("press (X) to exit");
            Console.WriteLine($"you have {stats.Wins} wins");
            Console.WriteLine("================================");

            string? key = Console.ReadLine()?.ToLower();

            if (key == "x")
            {
                Console.WriteLine("booting off...");
                return;
            }
            if (key != "")
            {
                Console.WriteLine("try again");
                continue;
            }

            int left = 0, right = 0, casts = 0;
            bool playing = true;

            Console.WriteLine("================================");
            Console.WriteLine("press (G) to throw the left die");
            Console.WriteLine("press (H) to throw the right die");
            Console.WriteLine("press (ENTER) to go back to menu");
            Console.WriteLine("================================");

            while (playing)
            {
                string? cast = Console.ReadLine()?.ToLower();

                switch (cast)
                {
                    case "g":
                        if (left != 0)
                        {
                            Console.WriteLine("left already thrown");
                            break;
                        }
                        left = dice.Roll();
                        casts++;
                        Console.WriteLine($"left: {left}");
                        break;

                    case "h":
                        if (right != 0)
                        {
                            Console.WriteLine("right already thrown");
                            break;
                        }
                        right = dice.Roll();
                        casts++;
                        Console.WriteLine($"right: {right}");
                        break;

                    case "":
                        playing = false;
                        break;

                    default:
                        Console.WriteLine("try again");
                        break;
                }

                if (left != 0 && right != 0)
                {
                    if (left + right == 12)
                    {
                        stats.Wins++;
                        stats.Save();
                        Console.WriteLine("================================");
                        Console.WriteLine("Congrats!!! you won!");
                        Console.WriteLine($"it took you {casts} casts");
                        playing = false;
                    }
                    else
                    {
                        Console.WriteLine($"total {left + right}, try again");
                        left = 0;
                        right = 0;
                    }
                }
            }
        }
    }
}