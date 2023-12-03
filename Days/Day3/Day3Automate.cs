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

        public int Run(string[] lines)
        {
            int sum = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                var previousLine = ((i - 1) >= 0) ? lines[i - 1] : string.Empty;
                var nextLine = ((i + 1) < lines.Length) ? lines[i + 1] : string.Empty;

                sum += Run(previousLine, lines[i], nextLine);
            }
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
            for (int i = (BeginIndex - 1); i <= EndIndex; i++)
            {
                if (IsSymbol(previousLine, i) || IsSymbol(line, i) || IsSymbol(nextLine, i))
                    return true;
            }

            return false;
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
