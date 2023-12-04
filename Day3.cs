using System.Text;

namespace AoC2023;

class Day3
{
    private static readonly string[] input = File.ReadAllLines("inputs/day3");

    private static bool IsInRange(int x, int y)
    {
        return x >= 0 && y >= 0 && x < input[0].Length && y < input.Length;
    }

    private static bool IsSymbol(char c)
    {
        return !(c == '.' || int.TryParse(c.ToString(), out int _));
    }

    private static HashSet<Tuple<int, int>> GetAdjacentCoordinates(int x, int y)
    {
        HashSet<Tuple<int, int>> coordinates = new();
        for (int j = y - 1; j <= y + 1; j++)
        {
            for (int i = x - 1; i <= x + 1; i++)
            {
                if (IsInRange(i, j) && !(i == x && j == y))
                {
                    coordinates.Add(new Tuple<int, int>(i, j));
                }
            }
        }

        return coordinates;
    }

    private static List<int> GetPartNumbers(HashSet<Tuple<int, int>> adjacents)
    {
        List<int> partNumbers = new();
        foreach (Tuple<int, int> coordinate in adjacents)
        {
            int xx = coordinate.Item1;
            int yy = coordinate.Item2;
            StringBuilder stringBuilder = new();

            if (int.TryParse(input[yy][xx].ToString(), out int _))
            {
                // cursor to left
                while (xx >= 0 && int.TryParse(input[yy][xx].ToString(), out int digit))
                {
                    stringBuilder.Insert(0, digit);
                    adjacents.Remove(new Tuple<int, int>(xx, yy));
                    xx--;
                };

                // move cursor 1 step right
                xx = coordinate.Item1 + 1;

                // cursor to right
                while (xx < input[yy].Length && int.TryParse(input[yy][xx].ToString(), out int digit))
                {
                    stringBuilder.Append(digit);
                    adjacents.Remove(new Tuple<int, int>(xx, yy));
                    xx++;
                };

                _ = int.TryParse(stringBuilder.ToString(), out int partNumber);
                partNumbers.Add(partNumber);
            }
        }

        return partNumbers;
    }
    public static void Part1()
    {
        int sum = 0;
        for (int y = 0; y < input.Length; y++)
        {
            for (int x = 0; x < input[y].Length; x++)
            {
                char character = input[y][x];
                if (IsSymbol(character))
                {
                    HashSet<Tuple<int, int>> adjacents = GetAdjacentCoordinates(x, y);
                    sum += GetPartNumbers(adjacents).Sum();
                }
            }
        }
        Console.WriteLine(sum);
    }

    public static void Part2()
    {
        int sum = 0;
        for (int y = 0; y < input.Length; y++)
        {
            for (int x = 0; x < input[y].Length; x++)
            {
                char character = input[y][x];
                if (IsSymbol(character))
                {
                    HashSet<Tuple<int, int>> adjacents = GetAdjacentCoordinates(x, y);
                    List<int> partNumbers =  GetPartNumbers(adjacents);
                    if (partNumbers.Count == 2) {
                        sum += partNumbers.Aggregate((x, y) => x * y);
                    }

                }
            }
        }
        Console.WriteLine(sum);
    }
}
