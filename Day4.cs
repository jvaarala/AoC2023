namespace AoC2023;

class Day4
{
    private static readonly string[] input = File.ReadAllLines("inputs/day4");

    public static void Part1()
    {
        double sum = 0;
        foreach (string row in input)
        {
            string[] card = row.Split(": ")[1].Replace("  ", " ").Split(" | ");
            string[] winningNumbers = card[0].Split(" ");
            string[] myNumbers = card[1].Split(" ");

            string[] matches = winningNumbers.Intersect(myNumbers).ToArray();

            if (matches.Length > 0)
            {
                sum += Math.Pow(2, matches.Length - 1);
            }
        }
        Console.WriteLine(sum);
    }

    public static void Part2()
    {
        int[] cardAmount = Enumerable.Repeat(1, input.Length).ToArray();

        for (int i = 0; i < input.Length; i++)
        {
            string[] card = input[i].Split(": ")[1].Replace("  ", " ").Split(" | ");
            string[] winningNumbers = card[0].Split(" ");
            string[] myNumbers = card[1].Split(" ");

            string[] matches = winningNumbers.Intersect(myNumbers).ToArray();

            for (int j = 0; j < matches.Length; j++)
            {
                int index = Math.Min(i + j + 1, input.Length);
                cardAmount[index] += cardAmount[i];
            }
        }

        Console.WriteLine(cardAmount.Sum().ToString());

    }
}
