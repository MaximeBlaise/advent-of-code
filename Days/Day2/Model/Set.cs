namespace AdventOfCode2023.Days.Day2.Model
{
    /// <summary>
    /// Define a set of a game.
    /// Example : 1 green, 3 red, 6 blue
    /// </summary>
    public class Set
    {
        /// <summary>
        /// string = color, int = number of cube(s) of that color
        /// </summary>
        public Dictionary<string, int> Cubes = new();

        public override string ToString()
        {
            return string.Join(", ", Cubes);
        }
    }
}
