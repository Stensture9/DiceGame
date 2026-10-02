namespace DiceGame.Client;

public class Dice
{
    private readonly Random rnd = new();

    public int Roll() => rnd.Next(1, 7);
}