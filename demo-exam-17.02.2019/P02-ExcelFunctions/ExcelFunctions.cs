namespace P02_ExcelFunctions
{
    using System;
    using System.Linq;

    public class ExcelFunctions
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = new string[n][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new[] { ',', ' ' }
                    , StringSplitOptions.RemoveEmptyEntries);
            }

            var command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string header = command[1];
            int columnIndex = -1;

            if (command[0] == "hide")
            {
                for (int row = 0; row < 1; row++)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (matrix[row][col] == header)
                        {
                            columnIndex = col;
                            break;
                        }
                    }
                }

                for (int row = 0; row < matrix.Length; row++)
                {
                    var tempArray = new string[matrix[row].Length - 1];
                    int index = 0;

                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (col == columnIndex)
                        {
                            continue;
                        }

                        tempArray[index] = matrix[row][col];
                        index++;
                    }

                    matrix[row] = tempArray;
                }

                foreach (var row in matrix)
                {
                    Console.WriteLine(string.Join(" | ", row));
                }
            }

            else if (command[0] == "filter")
            {
                string value = command[2];

                for (int row = 0; row < 1; row++)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (matrix[row][col] == header)
                        {
                            columnIndex = col;
                            break;
                        }
                    }
                }

                Console.WriteLine(string.Join(" | ", matrix[0]));

                for (int row = 1; row < matrix.Length; row++)
                {
                    if (matrix[row][columnIndex] == value)
                    {
                        Console.WriteLine(string.Join(" | ", matrix[row]));
                    }
                }
            }

            else if (command[0] == "sort")
            {
                string searchedCol = command[1];

                for (int row = 0; row < 1; row++)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (matrix[row][col] == searchedCol)
                        {
                            columnIndex = col;
                        }
                    }
                }

                var orderedMatrix = matrix.Skip(1).OrderBy(x => x[columnIndex]).ToArray();
                Console.WriteLine(string.Join(" | ", matrix[0]));

                foreach (var row in orderedMatrix)
                {
                    Console.WriteLine(string.Join(" | ", row));
                }
            }
        }
    }
}
