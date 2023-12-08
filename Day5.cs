namespace AoC2023;

class Data
{
    public long[] Seeds { get; set; }
    public List<List<long[]>> Maps { get; set; }


    public static Data Parse(string[] input)
    {
        Data data = new();
        List<List<long[]>> list = new();
        List<long[]> temp = new();

        input = input.Where(item => !string.IsNullOrEmpty(item)).ToArray();
        foreach (string row in input)
        {

            if (row.StartsWith("seeds:"))
            {
                string[] seedValues = row.Substring(7).Split(' ', StringSplitOptions.RemoveEmptyEntries);
                data.Seeds = seedValues.Select(long.Parse).ToArray();
            }
            else if (row.StartsWith("seed-to-soil map:") || row.StartsWith("soil-to-fertilizer map:") ||
                     row.StartsWith("fertilizer-to-water map:") || row.StartsWith("water-to-light map:") ||
                     row.StartsWith("light-to-temperature map:") || row.StartsWith("temperature-to-humidity map:") ||
                     row.StartsWith("humidity-to-location map:"))
            {
                if (temp.Count > 0) list.Add(temp);
                temp = new List<long[]>();
            }
            else
            {
                string[] values = row.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                long[] intValues = values.Select(long.Parse).ToArray();
                temp.Add(intValues);
            }
        }
        list.Add(temp);

        data.Maps = list;
        return data;
    }
}


class Day5
{
    private static readonly string[] input = File.ReadAllLines("inputs/day5");
    private static readonly Data data = Data.Parse(input);

    public static long GetLocation(long seed)
    {
        long location = seed;
        foreach (List<long[]> map in data.Maps)
        {
            foreach (long[] mapping in map)
            {
                if (location >= mapping[1] && location <= (mapping[1] + mapping[2]))
                {
                    location += mapping[0] - mapping[1];
                    break;
                }
            }
        }

        return location;
    }

    public static void Part1()
    {
        long lowestLocation = long.MaxValue;
        foreach (long seed in data.Seeds)
        {
            long location = GetLocation(seed);
            if (location < lowestLocation) lowestLocation = location;
        }

        Console.WriteLine(lowestLocation);

    }

    public static void Part2()
    {
        // slow and not working
        long lowestLocation = long.MaxValue;
        foreach (long[] pair in data.Seeds.Chunk(2))
        {

            Console.WriteLine($"Seed {pair[0]}, Range {pair[1]}");
            long start = pair[0];
            long end = pair[0] + pair[1];
            long totalIterations = (end - start) / 10; // Calculate 10% increments

            
            for (long i = start; i < end; i++)
            {
                long location = GetLocation(i);
                if (location < lowestLocation) lowestLocation = location;

                // Check if the current iteration represents a 10% increment
                if ((i - start) % totalIterations == 0)
                {
                    double progressPercentage = (double)(i - start) / (end - start) * 100;
                    Console.WriteLine($"{progressPercentage}%");
                }
            }


        }

        Console.WriteLine(lowestLocation);
        
    }
}
