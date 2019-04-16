namespace P03_Miner
{
    using System;
    using System.Linq;

    public class Miner
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var field = new char[n, n];
            int coalsCount = 0;
            int playerRow = -1;
            int playerCol = -1;

            var commands = Console.ReadLine().Split();

            for (int row = 0; row < n; row++)
            {
                var elements = Console.ReadLine().Split().Select(char.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    field[row, col] = elements[col];

                    if (field[row, col] == 'c')
                    {
                        coalsCount++;
                    }

                    else if (field[row, col] == 's')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            foreach (var command in commands)
            {
                switch (command)
                {
                    case "up":
                        if (playerRow - 1 >= 0)
                        {
                            if (field[playerRow - 1, playerCol] == 'e')
                            {
                                Console.WriteLine($"Game over! ({playerRow - 1}, {playerCol})");
                                return;
                            }

                            else if (field[playerRow - 1, playerCol] == 'c')
                            {
                                coalsCount--;
                                field[playerRow - 1, playerCol] = '*';
                            }

                            playerRow -= 1;
                        }

                        break;

                    case "down":
                        if (playerRow + 1 < n)
                        {
                            if (field[playerRow + 1, playerCol] == 'e')
                            {
                                Console.WriteLine($"Game over! ({playerRow + 1}, {playerCol})");
                                return;
                            }

                            else if (field[playerRow + 1, playerCol] == 'c')
                            {
                                coalsCount--;
                                field[playerRow + 1, playerCol] = '*';
                            }

                            playerRow += 1;
                        }

                        break;

                    case "left":
                        if (playerCol - 1 >= 0)
                        {
                            if (field[playerRow, playerCol - 1] == 'e')
                            {
                                Console.WriteLine($"Game over! ({playerRow}, {playerCol - 1})");
                                return;
                            }

                            else if (field[playerRow, playerCol - 1] == 'c')
                            {
                                coalsCount--;
                                field[playerRow, playerCol - 1] = '*';
                            }

                            playerCol -= 1;
                        }

                        break;

                    case "right":
                        if (playerCol + 1 < n)
                        {
                            if (field[playerRow, playerCol + 1] == 'e')
                            {
                                Console.WriteLine($"Game over! ({playerRow}, {playerCol + 1})");
                                return;
                            }

                            else if (field[playerRow, playerCol + 1] == 'c')
                            {
                                coalsCount--;
                                field[playerRow, playerCol + 1] = '*';
                            }

                            playerCol += 1;
                        }

                        break;
                }

                if (coalsCount == 0)
                {
                    Console.WriteLine($"You collected all coals! ({playerRow}, {playerCol})");
                    return;
                }
            }

            Console.WriteLine($"{coalsCount} coals left. ({playerRow}, {playerCol})");
        }
    }
}
