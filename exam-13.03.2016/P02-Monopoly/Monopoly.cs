namespace P02_Monopoly
{
    using System;
    using System.Linq;

    public class Monopoly
    {
        public static int playerMoney;
        public static int hotelsCount;
        public static int turns;
        public static int row;
        public static int col;

        public static void Main()
        {
            var fieldSize = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var field = new char[fieldSize[0], fieldSize[1]];
            playerMoney = 50;
            hotelsCount = 0;
            turns = 0;

            for (row = 0; row < fieldSize[0]; row++)
            {
                var elements = Console.ReadLine();

                for (col = 0; col < fieldSize[1]; col++)
                {
                    field[row, col] = elements[col];
                }
            }

            for (row = 0; row < fieldSize[0]; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < fieldSize[1]; col++)
                    {
                        CheckCell(field);
                    }
                }

                else
                {
                    for (col = fieldSize[1] - 1; col >= 0; col--)
                    {
                        CheckCell(field);
                    }
                }
            }

            Console.WriteLine($"Turns {turns}");
            Console.WriteLine($"Money {playerMoney}");
        }

        public static void CheckCell(char[,] field)
        {
            switch (field[row, col])
            {
                case 'H':
                    BuyHotel();
                    break;

                case 'J':
                    GoToJail();
                    break;

                case 'S':
                    SpendMoney();
                    break;
            }

            turns++;
            playerMoney += (hotelsCount * 10);
        }

        public static void SpendMoney()
        {
            int spentMoney = (row + 1) * (col + 1);
            spentMoney = playerMoney >= spentMoney
                ? spentMoney
                : playerMoney;

            playerMoney = Math.Max(0, playerMoney - spentMoney);
            Console.WriteLine($"Spent {spentMoney} money at the shop.");
        }

        public static void GoToJail()
        {
            Console.WriteLine($"Gone to jail at turn {turns}.");
            turns += 2;
            playerMoney += (hotelsCount * 20);
        }

        public static void BuyHotel()
        {
            hotelsCount++;
            Console.WriteLine($"Bought a hotel for {playerMoney}." +
                $" Total hotels: {hotelsCount}.");
            playerMoney = 0;
        }
    }
}
