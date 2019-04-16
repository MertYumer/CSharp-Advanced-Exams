namespace P03_NumberWars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NumberWars
    {
        public static void Main()
        {
            var firstLine = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var secondLine = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var firstPlayer = new Queue<string>(firstLine);
            var secondPlayer = new Queue<string>(secondLine);
            int turns = 0;
            bool gameOver = false;

            while (turns < 1000000 && gameOver == false)
            {
                if (firstPlayer.Count == 0 || secondPlayer.Count == 0)
                {
                    break;
                }

                turns++;
                string firstPlayerCard = firstPlayer.Dequeue();
                string secondPlayerCard = secondPlayer.Dequeue();

                int firstCardValue = GetNumberValue(firstPlayerCard);
                int secondCardValue = GetNumberValue(secondPlayerCard);

                if (firstCardValue > secondCardValue)
                {
                    firstPlayer.Enqueue(firstPlayerCard);
                    firstPlayer.Enqueue(secondPlayerCard);
                }

                else if (firstCardValue < secondCardValue)
                {
                    secondPlayer.Enqueue(secondPlayerCard);
                    secondPlayer.Enqueue(firstPlayerCard);
                }

                else
                {
                    var cardsOnTable = new List<string> { firstPlayerCard, secondPlayerCard };

                    while (gameOver == false)
                    {
                        if (firstPlayer.Count < 3 && secondPlayer.Count < 3)
                        {
                            gameOver = true;
                            break;
                        }

                        int firstSum = 0;
                        int secondSum = 0;

                        for (int i = 0; i < 3; i++)
                        {
                            firstSum += firstPlayer.Peek().Last();
                            secondSum += secondPlayer.Peek().Last();

                            cardsOnTable.Add(firstPlayer.Dequeue());
                            cardsOnTable.Add(secondPlayer.Dequeue());
                        }

                        if (firstSum > secondSum)
                        {
                            AddWonCards(cardsOnTable, firstPlayer);
                            break;
                        }

                        else if (firstSum < secondSum)
                        {
                            AddWonCards(cardsOnTable, secondPlayer);
                            break;
                        }
                    }
                }
            }

            if (firstPlayer.Count != secondPlayer.Count)
            {
                Console.WriteLine($"{(firstPlayer.Count > secondPlayer.Count ? "First" : "Second")} " +
                    $"player wins after {turns} turns");
            }

            else
            {
                Console.WriteLine($"Draw after {turns} turns");
            }
        }

        public static int GetNumberValue(string playerCard)
        {
            return int.Parse(playerCard.Substring(0, playerCard.Length - 1));
        }

        public static void AddWonCards(List<string> cardsOnTable, Queue<string> player)
        {
            var orderedCards = cardsOnTable
                                .OrderByDescending(c => GetNumberValue(c))
                                .ThenByDescending(c => c.Last());

            foreach (var card in orderedCards)
            {
                player.Enqueue(card);
            }
        }
    }
}
