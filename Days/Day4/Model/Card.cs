using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Days.Day4.Model
{
    public class Card
    {
        public int Id { get; set; }
        public List<int> WinningNumbers { get; set; } = new();
        public List<int> OwnNumbers { get; set; } = new();
    }
}
