namespace P02_ParkingSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ParkingSystem
    {
        public static void Main()
        {
            var parkingSize = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rows = parkingSize[0];
            int cols = parkingSize[1];
            var usedCells = new Dictionary<int, HashSet<int>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "stop")
                {
                    break;
                }

                var coordinates = input
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int entryRow = coordinates[0];
                int targetRow = coordinates[1];
                int targetCol = coordinates[2];
                int currentCol = 0;

                if (!IsUsed(usedCells, targetRow, targetCol))
                {
                    currentCol = targetCol;
                }

                else
                {
                    for (int col = 1; col < cols - 1; col++)
                    {
                        if (targetCol - col > 0
                            && !IsUsed(usedCells, targetRow, targetCol - col))
                        {
                            currentCol = targetCol - col;
                            break;
                        }

                        else if (targetCol + col < cols
                            && !IsUsed(usedCells, targetRow, targetCol + col))
                        {
                            currentCol = targetCol + col;
                            break;
                        }
                    }
                }

                if (currentCol == 0)
                {
                    Console.WriteLine($"Row {targetRow} full");
                    continue;
                }

                usedCells[targetRow].Add(currentCol);
                int moves = Math.Abs(targetRow - entryRow) + currentCol + 1;
                Console.WriteLine(moves);
            }
        }

        public static bool IsUsed(Dictionary<int, HashSet<int>> usedCells,
            int row, int col)
        {
            if (usedCells.ContainsKey(row))
            {
                if (usedCells[row].Contains(col))
                {
                    return true;
                }
            }

            else
            {
                usedCells[row] = new HashSet<int>();
            }

            return false;
        }
    }
}
