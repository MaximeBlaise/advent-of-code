namespace AdventOfCode2023.Days.Day2.Model
{
    /// <summary>
    /// Define a game.
    /// Example : Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
    /// </summary>
    public class Game
    {
        public int Id { get; set; }
        public List<Set> Sets { get; set; } = new();

        public override string ToString()
        {
            string sets = string.Join("; ", Sets);
            return $"{Id}: {sets}";
        }
    }
}
