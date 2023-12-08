namespace AoC2023;


class Day7
{
    private static List<string[]> Parse(string[] input)
    {
        List<string[]> hands = new();
        foreach (string row in input)
        {
            string[] split = row.Split(" ");
            hands.Add(new[] { split[0], split[1] });

        }

        return hands;
    }

    private static readonly string[] input = File.ReadAllLines("inputs/day7");
    private static readonly List<string[]> data = Parse(input);

    private static int GetType(string hand)
    {
        char[] cards = hand.ToCharArray();
        HashSet<char> set = cards.ToHashSet();
        int maxCount = cards.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count()).Values.Max(); ;

        if (set.Count == 5)
        {
            // High card
            return 0;
        }
        else if (set.Count == 4)
        {
            // One pair
            return 1;
        }
        else if (set.Count == 3)
        {
            if (maxCount == 2)
            {
                // Two pair
                return 2;
            }
            else
            {
                // Three of a kind
                return 3;
            }
        }
        else if (set.Count == 2)
        {
            if (maxCount == 3)
            {
                // Full house
                return 4;
            }
            else
            {
                // Four of a kind
                return 5;
            }
        }
        else
        {
            // Five of a kind
            return 6;
        }
    }

    private static readonly string strengths = "AKQJT98765432";



    public static void Part1()
    {
        Dictionary<int, List<string[]>> typesOfHands = new();
        foreach (string[] hand in data)
        {
            Console.WriteLine($"{hand[0]} {GetType(hand[0])}");
            int type = GetType(hand[0]);

            if (!typesOfHands.ContainsKey(type)) typesOfHands[type] = new List<string[]>();

            typesOfHands[type].Add(hand);
        }

        List<string[]> ranked = new();
        foreach (KeyValuePair<int, List<string[]>> e in typesOfHands.OrderBy(pair => pair.Key))
        {

            List<string[]> hands = e.Value;
            hands.Sort((a, b) =>
            {
                string aHand = a[0];
                string bHand = b[0];
                int aStr = 0;
                int bStr = 0;
                do
                {
                    char aFirst = aHand.First();
                    char bFirst = bHand.First();
                    aHand = aHand[1..];
                    bHand = bHand[1..];
                    aStr = strengths.IndexOf(aFirst);
                    bStr = strengths.IndexOf(bFirst);

                } while (aStr == bStr);


                return bStr - aStr;
            });

            ranked = ranked.Concat(hands).ToList();
        }

        int sum = 0;
        for (int i = 0; i < ranked.Count; i++)
        {
            sum += int.Parse(ranked[i][1]) * (i + 1);
        }

        Console.WriteLine(sum);

    }

    public static void Part2()
    {

    }
}
