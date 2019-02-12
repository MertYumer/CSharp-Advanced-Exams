namespace P03_Bombs
{
    using System;
    using System.Linq;

    public class Bombs
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                var elements = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            var bombs = Console.ReadLine().Split();

            foreach (var pair in bombs)
            {
                var bomb = pair.Split(',').Select(int.Parse).ToArray();

                if (matrix[bomb[0], bomb[1]] > 0)
                {
                    int value = matrix[bomb[0], bomb[1]];

                    for (int row = bomb[0] - 1; row <= bomb[0] + 1; row++)
                    {
                        for (int col = bomb[1] - 1; col <= bomb[1] + 1; col++)
                        {
                            if (row >= 0 && row < n && col >= 0 && col < n)
                            {
                                if (CellIsAlive(matrix, row, col))
                                {
                                    matrix[row, col] -= value;
                                }
                            }
                        }
                    }
                }
            }

            int aliveCells = 0;
            int sum = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCells++;
                        sum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        public static bool CellIsAlive(int[,] matrix, int row, int col)
        {
            return matrix[row, col] > 0
                ? true
                : false;
        }
    }
}
