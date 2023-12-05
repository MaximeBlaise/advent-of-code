using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Days.Day3
{
    public class Day3Automate
    {
        public string NumberBuffer { get; set; } = "";
        public int BeginIndex { get; set; }
        public int EndIndex { get; set; }
        public bool IsBuildingDigit { get; set; }

        public int PartNumberSum { get; set; }
        public Dictionary<(int, int), List<int>> Part2 { get; set; } = new(); // a renommer
        public int CurrentLineIndex { get; set; }

        public int Run(string[] lines)
        {
            int sum = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                CurrentLineIndex = i;

                var previousLine = ((i - 1) >= 0) ? lines[i - 1] : string.Empty;
                var nextLine = ((i + 1) < lines.Length) ? lines[i + 1] : string.Empty;

                sum += Run(previousLine, lines[i], nextLine);
            }

            // part 2
            var part2filtered = Part2.Where(x => x.Value.Count == 2);
            int sumPart2 = 0;
            foreach(var part2item in part2filtered) {
                Console.WriteLine($"({part2item.Key.Item1},{part2item.Key.Item2}) -> {string.Join(',', part2item.Value)}");
                int currentSum = part2item.Value[0] * part2item.Value[1];
                sumPart2 += currentSum;
            }
            Console.WriteLine($"Sum part 2 : {sumPart2}");

            return sum;
        }

        public int Run(string previousLine, string line, string nextLine)
        {
            Console.Write($"Run for line {line}");
            NumberBuffer = "";
            PartNumberSum = 0;

            for (int i = 0; i < line.Length; i++)
            {
                if (Run(i, line[i]))
                {
                    if (IsPartNumberValid(previousLine, line, nextLine))
                        PartNumberSum += int.Parse(NumberBuffer);

                    NumberBuffer = "";
                    IsBuildingDigit = false;
                }
            }
            if (IsBuildingDigit)
            { // sûrement mieux à faire 
                EndIndex = line.Length - 1;
                if (IsPartNumberValid(previousLine, line, nextLine))
                        PartNumberSum += int.Parse(NumberBuffer);
                IsBuildingDigit = false;
            }

            Console.WriteLine($" -> {PartNumberSum}");
            return PartNumberSum;
        }

        public bool Run(int index, char c)
        {
            if (char.IsDigit(c))
            {
                if (!IsBuildingDigit)
                {
                    BeginIndex = index;
                    IsBuildingDigit = true;
                }

                NumberBuffer += $"{c}";
            }
            else
            {
                if (IsBuildingDigit)
                {
                    IsBuildingDigit = false;
                    EndIndex = index;
                    return true;
                }
            }

            return false;
        }
        

        public bool IsPartNumberValid(string previousLine, string line, string nextLine)
        {
            bool result = false;
            for (int i = BeginIndex - 1; i <= EndIndex; i++)
            {
                // part 2
                if (IsSymbol(previousLine, i) && previousLine[i] == '*') {
                    AddNumberToPart2(CurrentLineIndex - 1, i, int.Parse(NumberBuffer));
                }

                if (IsSymbol(line, i) && line[i] == '*') {
                    AddNumberToPart2(CurrentLineIndex, i, int.Parse(NumberBuffer));
                }

                if (IsSymbol(nextLine, i) && nextLine[i] == '*') {
                    AddNumberToPart2(CurrentLineIndex + 1, i, int.Parse(NumberBuffer));
                }


                if (IsSymbol(previousLine, i) || IsSymbol(line, i) || IsSymbol(nextLine, i)) // part 1
                    result = true;
            }

            return result;
        }

        public void AddNumberToPart2(int line, int column, int number) {
            bool isKeyExists = Part2.TryGetValue((line, column), out var intList);
            if (isKeyExists && intList != null) {
                intList.Add(number);
            }
            else {
                Part2.Add((line, column), new List<int>() { int.Parse(NumberBuffer)});
            }
        }

        public static bool IsSymbol(string line, int i)
        {
            if (string.IsNullOrEmpty(line))
                return false;

            if (i < 0 || i >= line.Length)
                return false;

            return IsSymbol(line[i]);
        }

        public static bool IsSymbol(char c)
        {
            return c != '.' && !char.IsDigit(c);
        }
    }
}
