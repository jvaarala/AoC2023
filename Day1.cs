using System.Text;

namespace AoC2023;

class Day1
{
    public static void Part1()
    {
        string[] input = File.ReadAllLines("inputs/day1");

        List<Tuple<char?, char?>> digits = new();
        foreach (var row in input)
        {
            char? firstDigit = null;
            char? lastDigit = null;
            foreach (char character in row)
            {
                if (firstDigit == null && char.IsNumber(character))
                {
                    firstDigit = character;
                }

                if (char.IsNumber(character))
                {
                    lastDigit = character;
                }
            }
            if (firstDigit != null && lastDigit != null)
            {
                digits.Add(new Tuple<char?, char?>((char)firstDigit, (char)lastDigit));
            }
        }

        int sumTotal = 0;
        foreach (var pair in digits)
        {
            StringBuilder stringBuilder = new();
            stringBuilder.Append(pair.Item1);
            stringBuilder.Append(pair.Item2);

            _ = int.TryParse(stringBuilder.ToString(), out int parsed);
            sumTotal += parsed;
        }
        Console.WriteLine(sumTotal);
    }

    public static void Part2()
    {
        string[] input = File.ReadAllLines("inputs/day1-1");

        string[] numbers = {
            "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"
        };

        int sumTotal = 0;
        foreach (string row in input)
        {
            List<Tuple<int, string>> positions = new();
            string substring = row;

            for (int i = 0; i < numbers.Length; i++)
            {
                int index = row.IndexOf(numbers[i]);
                while (index != -1)
                {
                    positions.Add(new Tuple<int, string>(index, (i + 1).ToString()));
                    index = row.IndexOf(numbers[i], index + 1);
                };
            }


            for (int i = 0; i < row.Length; i++)
            {
                if (char.IsNumber(row[i]))
                {
                    positions.Add(new Tuple<int, string>(i, row[i].ToString()));
                }
            }

            var sorted = positions.OrderBy(tuple => tuple.Item1).ToList();

            string firstDigit = sorted[0].Item2;
            string lastDigit = sorted[^1].Item2;

            StringBuilder stringBuilder = new();
            stringBuilder.Append(firstDigit);
            stringBuilder.Append(lastDigit);

            _ = int.TryParse(stringBuilder.ToString(), out int parsed);
            sumTotal += parsed;
        }
        Console.WriteLine(sumTotal);

    }
}

