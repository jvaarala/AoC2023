namespace AoC2023;

class Day6
{
    private static readonly string[] input = File.ReadAllLines("inputs/day6");

    private static List<int[]> Parse(string[] input)
    {
        List<int[]> data = new();
        foreach (string row in input)
        {
            data.Add(row.Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray().Select(int.Parse).ToArray());
        }

        return data;
    }


    public static void Part1()
    {
        List<int[]> data = Parse(input);
        int[] time = data[0];
        int[] record = data[1];

        List<int> race = new();

        for (int i = 0; i < time.Length; i++)
        {
            int ways = 0;
            for (int j = 0; j < time[i]; j++)
            {
                if ((time[i] - j) * j > record[i])
                {
                    ways++;
                }
            }
            race.Add(ways);

        }

        Console.WriteLine(race.Aggregate((x, y) => x * y));
    }

    public static void Part2()
    {
        List<int[]> data = Parse(input);
        long time = long.Parse(string.Join("", data[0]));
        long record = long.Parse(string.Join("", data[1]));

        long ways = 0;
        for (long j = 0; j < time; j++)
        {
            if ((time - j) * j > record)
            {
                ways++;
            }
        }

        Console.WriteLine(ways);
    }
}
