using AdventOfCode2023.Days.Day6.Model;

namespace AdventOfCode2023.Days.Day6.Extensions
{
    public static class RaceExtension {

        public static int NumberOfWaysYouWin(this Race race) {
            int numberOfWays = 0;
            for (int time = 1; time < race.Time; time++)
            {
                int yourDistance = (race.Time - time) * time;
                if (yourDistance > race.Distance)
                    numberOfWays++;
            }
            return numberOfWays;
        }

        public static List<Race> ReadFromLines(string[] lines) {
            if (lines == null || lines.Length < 2)
                return new List<Race>();
            List<int> times = GetValuesFromLine(lines[0]);
            List<int> distances = GetValuesFromLine(lines[1]);
            return ReadFromValues(times, distances);
        }

        private static List<Race> ReadFromValues(List<int> times, List<int> distances) {
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

        private static List<int> GetValuesFromLine(string line)
            => line.Split(":")[1].Trim().Split(" ")
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => int.Parse(x)).ToList();

        
    }
}
