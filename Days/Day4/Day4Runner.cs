using AdventOfCode2023.Days.Day4.Extensions;
using AdventOfCode2023.Days.Day4.Model;
using AdventOfCode2023.Helpers;

namespace AdventOfCode2023.Days.Day4
{
    public static class Day4Runner
    {
        public static void Run(bool isSample)
        {
            string[] lines = FileHelper.GetLines(4, isSample);

            // read cards
            List<Card> cards = CardExtensions.ReadFromLines(lines);
            Dictionary<int, int> nbWinningMap = new();
            Dictionary<int, int> userCards = new();
            cards.ForEach(card => {
                nbWinningMap.Add(card.Id, card.NumberOfWinningCards());
                userCards.Add(card.Id, 1);
            });

            // part 1
            int sumOfValues = cards.Sum(card => card.ComputeValue());
            Console.WriteLine($"Sum of values : {sumOfValues}");

            // part 2
            foreach(var userCard in userCards) {
                int nbWinning = nbWinningMap[userCard.Key];
                for(int i = userCard.Key + 1; i <= userCard.Key + nbWinning; i++)
                {
                    userCards[i] = userCards[i] + userCards[userCard.Key];
                }
            }
            int sumOfCards = userCards.Select(x => x.Value).Sum();
            Console.WriteLine($"Sum of cards : {sumOfCards}");
        }
    }
}
