using AdventOfCode2023.Helpers;

namespace AdventOfCode2023.Days.Day1
{
    public static class Day1Runner
    {
        public static void Run(bool isSample)
        {
            string[] lines = FileHelper.GetLines(1, isSample);
            int sumOfCalibrationValues = SumOfCalibrationValues(lines);

            Console.WriteLine($"Sum of calibration values : {sumOfCalibrationValues}");
        }

        private static int SumOfCalibrationValues(string[] lines)
        {
            int sum = 0;
            foreach (string line in lines)
            {
                sum += CalibrationValueForLine(line);
            }
            return sum;
        }

        static string[] days = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        private static int IndexInDays(string line)
        {
            int maxIndex = -1; int digitResult = 0;
            foreach(var day in days)
            {
                int lastIndexOfDay = line.LastIndexOf(day);
                if (line.Contains(day) && lastIndexOfDay > maxIndex)
                {
                    maxIndex = lastIndexOfDay;
                    digitResult = Array.IndexOf(days, day) + 1;
                }
            }
            return digitResult;
        }

        private static int CalibrationValueForLine(string line)
        {
            Console.WriteLine($"CalibrationValueForLine {line}");
            int firstDigit = 0, lastDigit = 0;
            bool firstDigitFound = false;

            string acc = "";
            foreach (var c in line)
            {
                acc += c;

                int digit = 0;
                bool digitFound = false;
                if (char.IsDigit(c))
                { // part 1
                    digit = int.Parse($"{c}");
                    digitFound = true;

                    acc = "";
                }
                int indexInDays = IndexInDays(acc);
                if (!digitFound && indexInDays > 0) // part 2
                {
                    digit = indexInDays;
                    digitFound = true;
                }

                if (digitFound)
                {
                    if (!firstDigitFound)
                    {
                        firstDigit = digit;
                        firstDigitFound = true;
                    }

                    lastDigit = digit;
                }
            }

            _ = int.TryParse($"{firstDigit}{lastDigit}", out int calibrationValue); // for this case, we can ignore result
            Console.WriteLine($"calibrationValue = {calibrationValue}");
            return calibrationValue;
        }
    }
}
