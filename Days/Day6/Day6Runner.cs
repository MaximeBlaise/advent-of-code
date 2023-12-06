using AdventOfCode2023.Days.Day6.Extensions;
using AdventOfCode2023.Days.Day6.Model;
using AdventOfCode2023.Helpers;

namespace AdventOfCode2023.Days.Day6
{
    public static class Day6Runner
    {
       

        public static void Run(bool isSample)
        {
            string[] lines = FileHelper.GetLines(6, isSample);
            List<Race> races = RaceExtension.ReadFromLines(lines);

            // part 1
            int numberOfWaysPart1 = races.Select(race => race.NumberOfWaysYouWin()).Aggregate((x,y) => x * y);
            Console.WriteLine($"Number of ways part 1 : {numberOfWaysPart1}");
        }
    }
}
