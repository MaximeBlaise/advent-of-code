using AdventOfCode2023.Days.Day6.Model;

namespace AdventOfCode2023.Days.Day6.Extensions
{
    public static class RaceExtension {

        public static int NumberOfWaysYouWin(this Race race) {
            int numberOfWays = 0;
            for (int time = 1; time < race.Time; time++)
            {
                long yourDistance = (race.Time - time) * time;
                if (yourDistance > race.Distance)
                    numberOfWays++;
            }
            return numberOfWays;
        }

        public static List<Race> ReadFromLines(string[] lines) {
            if (lines == null || lines.Length < 2)
                return new List<Race>();
            List<long> times = GetValuesFromLine(lines[0]);
            List<long> distances = GetValuesFromLine(lines[1]);
            return ReadFromValues(times, distances);
        }

        public static List<Race> ReadFromLinesPart2(string[] lines) {
            if (lines == null || lines.Length < 2)
                return new List<Race>();
            List<long> times = GetValuesFromLine(lines[0].Replace(" ", ""));
            List<long> distances = GetValuesFromLine(lines[1].Replace(" ", ""));
            return ReadFromValues(times, distances);
        }

        private static List<Race> ReadFromValues(List<long> times, List<long> distances) {
            if (!times.Any() || !distances.Any() || times.Count != distances.Count)
                return new List<Race>();

            List<Race> races = new();
            for (int i = 0; i < times.Count; i++)
            {
                Race race = new() {
                    Distance = distances[i],
                    Time = times[i]
                };
                races.Add(race);
            }
            return races;
        }

        private static List<long> GetValuesFromLine(string line)
            => line.Split(":")[1].Trim().Split(" ")
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => long.Parse(x)).ToList();

        
    }
}
