using AdventOfCode2023.Days.Day5.Model;

namespace AdventOfCode2023.Days.Day5.Extensions
{
    public static class SourceDestMapExtensions {

        public static SourceDestMap ReadMapFromLine(string line) {
            var split = line.Split(" ");
            return new SourceDestMap(
                long.Parse(split[1]), long.Parse(split[0]), long.Parse(split[2])
            );
        }

        public static long ComputeDestination(List<SourceDestMap> map, long source) {
            var validMap = map.FirstOrDefault(x => source >= x.Source && source < (x.Source + x.Range));
            if (validMap == null)
                return source;

            return source + validMap.Diff;
        }
    }
}
