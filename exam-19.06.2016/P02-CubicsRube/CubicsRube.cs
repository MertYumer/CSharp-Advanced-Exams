namespace P02_CubicsRube
{
    using System;
    using System.Linq;

    public class CubicsRube
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            long sum = 0;
            int changedCells = 0;

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Analyze")
                {

                    break;
                }

                var coordinates = input.Split().Select(int.Parse).ToArray();
                int table = coordinates[0];
                int row = coordinates[1];
                int col = coordinates[2];
                int value = coordinates[3];

                if (HasValidCoordinates(table, row, col, n) && value != 0)
                {
                    sum += value;
                    changedCells++;
                }
            }

            Console.WriteLine(sum);
            Console.WriteLine(Math.Pow(n, 3) - changedCells);
        }

        public static bool HasValidCoordinates(int table, int row, int col, int n)
        {
            if (table >= 0 && table < n
                && row >= 0 && row < n
                && col >= 0 && col < n)
            {
                return true;
            }

            return false;
        }
    }
}
