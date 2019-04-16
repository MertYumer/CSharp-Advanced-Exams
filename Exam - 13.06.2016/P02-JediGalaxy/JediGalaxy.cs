namespace P02_JediGalaxy
{
    using System;
    using System.Linq;

    public class JediGalaxy
    {
        public static void Main()
        {
            var matrixSizes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var matrix = new int[matrixSizes[0], matrixSizes[1]];
            int value = 0;
            long ivoPoints = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = value;
                    value++;
                }
            }

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Let the Force be with you")
                {
                    Console.WriteLine(ivoPoints);
                    break;
                }

                var coordinates = input
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int ivoRow = coordinates[0];
                int ivoCol = coordinates[1];

                coordinates = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int evilRow = coordinates[0];
                int evilCol = coordinates[1];

                while (evilRow >= 0 && evilCol >= 0)
                {
                    if (evilRow < matrix.GetLength(0) && evilCol < matrix.GetLength(1))
                    {
                        matrix[evilRow, evilCol] = 0;
                    }

                    evilRow--;
                    evilCol--;
                }

                while (ivoRow >= 0 && ivoCol < matrix.GetLength(1))
                {
                    if (ivoRow < matrix.GetLength(0) && ivoCol >= 0)
                    {
                        ivoPoints += matrix[ivoRow, ivoCol];
                    }

                    ivoRow--;
                    ivoCol++;
                }
            }
        }
    }
}
