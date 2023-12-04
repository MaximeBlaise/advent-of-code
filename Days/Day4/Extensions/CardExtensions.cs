using AdventOfCode2023.Days.Day4.Model;

namespace AdventOfCode2023.Days.Day4.Extensions
{
    public static class CardExtensions
    {

        public static List<Card> ReadFromLines(string[] lines)
        {
            List<Card> cards = new();
            lines.ToList().ForEach(line =>
            {
                cards.Add(ReadFromLine(line));
            });
            return cards;
        }

        public static Card ReadFromLine(string line)
        {
            var tmpSplit = line.Split(':');

            var idSplit = tmpSplit[0].Split(' ');
            int id = int.Parse(idSplit[idSplit.Length - 1]); // vérif à effectuer

            var pipeSplit = tmpSplit[1].Split('|');
            List<int> winningNumbers = GetListNumbers(pipeSplit[0]);
            List<int> ownNumbers = GetListNumbers(pipeSplit[1]);

            return new Card
            {
                Id = id,
                WinningNumbers = winningNumbers,
                OwnNumbers = ownNumbers
            };
        }

        public static int ComputeValue(this Card card)
        {
            int nbWinning = NumberOfWinningCards(card);
            return nbWinning == 0 ? 0 : (int)Math.Pow(2, nbWinning - 1);
        }

        public static int NumberOfWinningCards(this Card card) 
        {
            return card.OwnNumbers.Where(n => card.WinningNumbers.Contains(n)).Count();
        }

        private static List<int> GetListNumbers(string line)
        {
            List<int> result = new();
            line.Trim().Split(' ').ToList().ForEach(x =>
            {
                if (!string.IsNullOrWhiteSpace(x))
                    result.Add(int.Parse(x));
            });
            return result;
        }
    }
}
