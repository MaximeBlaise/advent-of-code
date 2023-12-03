using AdventOfCode2023.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Days.Day3
{
    public static class Day3Runner
    {
        public static void Run(bool isSample)
        {
            string[] lines = FileHelper.GetLines(3, isSample);

            var automate = new Day3Automate();
            int sumOfPartNumber = automate.Run(lines);
            Console.WriteLine($"Sum : {sumOfPartNumber}");
        }
    }
}
