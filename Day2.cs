namespace AoC2023;

class Day2
{
    public static void Part1()
    {
        string[] input = File.ReadAllLines("inputs/day2");
        int sum = 0;

        List<KeyValuePair<int, string>> asks = new()
        {
            new KeyValuePair<int, string> (12, "red"),
            new KeyValuePair<int, string> (13, "green"),
            new KeyValuePair<int, string> (14, "blue"),
        };

        foreach (var row in input)
        {
            string[] split = row.Split(": ");
            _ = int.TryParse(split[0].Split(" ")[1], out int index);
            string[] sets = split[1].Split("; ");
            bool allAmountsAllSmaller = true;

            foreach (string hand in sets)
            {
                foreach (string a in hand.Split(", "))
                {
                    string[] kv = a.Split(" ");
                    _ = int.TryParse(kv[0], out int amount);
                    int limit = asks.Find(x => x.Value.Equals(kv[1])).Key;
                    if (amount > limit)
                    {
                        allAmountsAllSmaller = false;
                        break;
                    }
                }
                if (!allAmountsAllSmaller)
                {
                    break;
                }
            }

            if (allAmountsAllSmaller)
            {
                sum += index;
            }
        }
        Console.WriteLine(sum);
    }

    public static void Part2()
    {
        string[] input = File.ReadAllLines("inputs/day2");
        int sum = 0;

        foreach (var row in input)
        {
            string[] split = row.Split(": ");
            _ = int.TryParse(split[0].Split(" ")[1], out int index);
            string[] sets = split[1].Split("; ");

            int maxRed = 0;
            int maxGreen = 0;
            int maxBlue = 0;

            foreach (string hand in sets)
            {
                foreach (string a in hand.Split(", "))
                {
                    string[] kv = a.Split(" ");
                    _ = int.TryParse(kv[0], out int amount);
                    switch (kv[1])
                    {
                        case "red":
                            _ = int.TryParse(kv[0], out int red);
                            if (red > maxRed)
                            {
                                maxRed = red;
                            }
                            break;

                        case "green":
                            _ = int.TryParse(kv[0], out int green);
                            if (green > maxGreen)
                            {
                                maxGreen = green;
                            }
                            break;

                        case "blue":
                            _ = int.TryParse(kv[0], out int blue);
                            if (blue > maxBlue)
                            {
                                maxBlue = blue;
                            }
                            break;

                        default:
                            break;
                    }
                }
            }

            sum += maxRed * maxGreen * maxBlue;
        }
        Console.WriteLine(sum);
    }
}

