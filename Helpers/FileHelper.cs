using AdventOfCode2023.Constants;

namespace AdventOfCode2023.Helpers
{
    public static class FileHelper
    {
        public static string[] GetLines(int day, bool isSample = false)
        {
            string suffix = isSample ? "sample" : "input";
            var filePath = $"{AdventConstants.FolderPath}day{day}_{suffix}.txt";

            Console.WriteLine($"Read file {filePath}");
            return File.ReadAllLines(filePath);
        }
    }
}
