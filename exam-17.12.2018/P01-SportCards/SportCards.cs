namespace P01_SportCards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SportCards
    {
        public static void Main()
        {
            var cards = new Dictionary<string, Dictionary<string, decimal>>();

            while (true)
            {
                var input = Console.ReadLine().Split(" - ");

                if (input[0] == "end")
                {
                    break;
                }

                else if (input[0].Contains("check"))
                {
                    var checkSplit = input[0].Split();
                    string searchedCard = checkSplit[1];

                    if (cards.ContainsKey(searchedCard))
                    {
                        Console.WriteLine($"{searchedCard} is available!");
                    }

                    else
                    {
                        Console.WriteLine($"{searchedCard} is not available!");
                    }

                    continue;
                }

                string cardName = input[0];
                string sport = input[1];
                decimal price = decimal.Parse(input[2]);

                if (!cards.ContainsKey(cardName))
                {
                    cards.Add(cardName, new Dictionary<string, decimal>());
                }

                if (!cards[cardName].ContainsKey(sport))
                {
                    cards[cardName].Add(sport, price);
                }

                else
                {
                    cards[cardName][sport] = price;
                }
            }

            var orderedCards = cards.OrderByDescending(c => c.Value.Count);

            foreach (var card in orderedCards)
            {
                Console.WriteLine($"{card.Key}:");

                var orderedSports = card.Value.OrderBy(s => s.Key);

                foreach (var sport in orderedSports)
                {
                    Console.WriteLine($"  -{sport.Key} - {sport.Value:f2}");
                }
            }
        }
    }
}
