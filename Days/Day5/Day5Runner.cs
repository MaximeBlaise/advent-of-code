using AdventOfCode2023.Days.Day5.Extensions;
using AdventOfCode2023.Days.Day5.Model;
using AdventOfCode2023.Helpers;

namespace AdventOfCode2023.Days.Day5
{
    public static class Day5Runner
    {
        private static List<long> seedsToCompute = new();
        private static List<Seed> seedsToComputePart2 = new();
        private static Dictionary<string, List<SourceDestMap>> globalMap = new();

        public static void Run(bool isSample)
        {
            string[] lines = FileHelper.GetLines(5, isSample);
            Read(lines);

            // part 1
            long lowestLocation = int.MaxValue;
            seedsToCompute.ForEach(seed => {
                long location = ComputeLocation(seed);
                if (location < lowestLocation) {
                    lowestLocation = location;
                }
            });
            Console.WriteLine($"Lowest location part 1 : {lowestLocation}");

            // part 2
            long lowestLocationPart2 = seedsToComputePart2.AsParallel()
                .Select(seed => ComputeLowestLocation(seed))
                .Min();
            Console.WriteLine($"Lowest location part 2 : {lowestLocationPart2}");
        }

        private static long ComputeLowestLocation(Seed seed) {
            long finalValue = seed.InitialValue + seed.Range;
            Console.WriteLine($"Compute from {seed.InitialValue} to {finalValue - 1}");

            long lowestLocation = long.MaxValue;

            int count = 0;
            for(long i = seed.InitialValue; i < finalValue; i++) {
                long location = ComputeLocation(i);
                if (location < lowestLocation) {
                    lowestLocation = location;
                }

                count++;
                if (count % 10000000 == 0) {
                    double percent = (double)(i - seed.InitialValue) * 100 / seed.Range;
                    Console.WriteLine($"Seed {seed.InitialValue}: {(int)percent}%");
                    count = 0;
                }
            }

            Console.WriteLine($"Value for seed {seed.InitialValue} = {lowestLocation}");
            return lowestLocation;
        }

        private static long ComputeLocation(long seed) {
            long currentDestination = seed;
            foreach (var item in globalMap)
            {
                currentDestination = SourceDestMapExtensions.ComputeDestination(item.Value, currentDestination);
            }
            return currentDestination;
        }

        private static void Read(string[] lines) {
            List<SourceDestMap> currentMap = new();
            string currentKey = "";

            foreach(string line in lines) {
                if (line.StartsWith("seeds")) {
                    var split = line.Split(":")[1].Trim().Split(" ");
                    // part 1
                    seedsToCompute = split.Select(x => long.Parse(x)).ToList();

                    // part 2
                    long currentSeed = 0;
                    for(int i = 0; i < split.Length; i++) {
                        if (i % 2 == 0) {
                            currentSeed = long.Parse(split[i]);
                        } else {
                            long range = long.Parse(split[i]);
                            Seed seed = new() {
                                InitialValue = currentSeed,
                                Range = range
                            };
                            seedsToComputePart2.Add(seed);
                        }
                        
                    }
                    continue;
                }

                if (string.IsNullOrWhiteSpace(line)) {
                    if (!string.IsNullOrWhiteSpace(currentKey) && currentMap.Any()) {
                        globalMap.Add(currentKey, currentMap);
                        currentMap = new();
                        currentKey = "";
                    }
                    continue;
                }
                           
                if (char.IsDigit(line[0])) {
                    currentMap.Add(SourceDestMapExtensions.ReadMapFromLine(line));
                } else {
                    currentKey = line.Split(" ")[0];
                }
            }

            if (!string.IsNullOrWhiteSpace(currentKey) && currentMap.Any()) {
                globalMap.Add(currentKey, currentMap);
            }
        }
    }
}
