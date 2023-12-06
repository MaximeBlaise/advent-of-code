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

            // part 1
            List<Race> races = RaceExtension.ReadFromLines(lines);
            int numberOfWaysPart1 = races.Select(race => race.NumberOfWaysYouWin()).Aggregate((x,y) => x * y);
            Console.WriteLine($"Number of ways part 1 : {numberOfWaysPart1}");

            // part 2
            Race racePart2 = RaceExtension.ReadFromLinesPart2(lines)[0];
            int numberOfWaysPart2 = racePart2.NumberOfWaysYouWin();
            Console.WriteLine($"Number of ways part 2 : {numberOfWaysPart2}");
        }
    }
}
