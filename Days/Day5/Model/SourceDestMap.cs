namespace AdventOfCode2023.Days.Day5.Model
{
    public class SourceDestMap
    {
        public long Source { get; set; }
        public long Destination { get; set; }
        public long Range { get; set; }

        public long Diff { get; set; }

        public SourceDestMap() {

        }

        public SourceDestMap(long src, long dest, long range) {
            Source = src;
            Destination = dest;
            Range = range;
            Diff = Destination - Source;
        }
    }
}
