using AdventOfCode2023.Days.Day2.Model;
using AdventOfCode2023.Helpers;

namespace AdventOfCode2023.Days.Day2
{
    public static class Day2Runner
    {
        static Dictionary<string, int> givenCubes = new()
        {
            { "red", 12 }, { "green", 13 }, { "blue", 14 }
        };

        public static void Run(bool isSample)
        {
            // Part 1
            int sumOfIds = FileHelper.GetLines(2, isSample)
                .Select(line => ReadGame(line))
                .Where(game => IsGamePossible(game))
                .Sum(game => game.Id);

            Console.WriteLine($"Sum : {sumOfIds}");

            // Part 2
            int sumOfPower = FileHelper.GetLines(2, isSample)
                .Select(line => ReadGame(line))
                .Sum(game => PowerOfGame(game));
            Console.WriteLine($"Sum of game power: {sumOfPower}");
        }

        public static int PowerOfGame(Game game)
        {
            Console.Write($"Power of Game {game} -> ");
            Dictionary<string, int> minimumCubes = new()
            {
                { "red", 0 }, { "green", 0 }, { "blue", 0 }
            };
            foreach (Set set in game.Sets)
            {
                foreach(var cube in minimumCubes)
                {
                    int currentValue = set.Cubes.GetValueOrDefault(cube.Key);
                    if (currentValue >= cube.Value)
                    {
                        minimumCubes[cube.Key] = currentValue;
                    }
                }
            }
            int power = minimumCubes.Values.Aggregate((a, x) => a * x);
            Console.WriteLine(power);
            return power;
        }

        // only 12 red cubes, 13 green cubes, and 14 blue cubes
        public static bool IsGamePossible(Game game)
        {
            Console.Write($"Game {game}");
            foreach (var set in game.Sets)
            {
                if (!IsSetPossible(set))
                {
                    Console.WriteLine($"\n\t -> Impossible because of {set}");
                    return false;
                }
                    
            }
            Console.WriteLine(" -> Possible");
            return true;
        }

        public static bool IsSetPossible(Set set)
        {
            foreach (var givenColor in givenCubes)
            {
                int setColor = set.Cubes.GetValueOrDefault(givenColor.Key);
                if (setColor > givenColor.Value)
                    return false;
            }
            return true;
        }

        #region Read parts

        public static Game ReadGame(string line)
        {
            var tmpSplit = line.Split(':');
            int gameId = int.Parse(tmpSplit[0].Split(' ')[1]);
            List<Set> sets = ReadSets(tmpSplit[1]);
            return new Game
            {
                Id = gameId,
                Sets = sets
            };
        }

        //  3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
        public static List<Set> ReadSets(string line)
        {
            List<Set> sets = new();
            line.Trim().Split(';').ToList().ForEach(setLine =>
            {
                sets.Add(ReadSet(setLine));
            });
            return sets;
        }

        // 8 green, 6 blue, 20 red
        public static Set ReadSet(string line)
        {
            Set set = new();

            var cubes = line.Split(",");
            foreach (var cube in cubes)
            {
                var tmpSplit = cube.Trim().Split(" ");
                int numberOfCubes = int.Parse(tmpSplit[0]);
                string color = tmpSplit[1];
                set.Cubes.Add(color, numberOfCubes);
            }

            return set;
        }

        #endregion
    }
}
