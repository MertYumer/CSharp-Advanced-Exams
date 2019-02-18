namespace P02_ExcelFunctions
{
    using System;
    using System.Collections.Generic;
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
            int headerIndex = Array.IndexOf(matrix[0], header);

            if (command[0] == "hide")
            {
                for (int row = 0; row < matrix.Length; row++)
                {
                    var tempRow = new List<string>();
                    tempRow.AddRange(matrix[row].Take(headerIndex));
                    tempRow.AddRange(matrix[row].Skip(headerIndex + 1));
                    matrix[row] = tempRow.ToArray();
                }

                foreach (var row in matrix)
                {
                    Console.WriteLine(string.Join(" | ", row));
                }
            }

            else if (command[0] == "filter")
            {
                string value = command[2];
                Console.WriteLine(string.Join(" | ", matrix[0]));

                for (int row = 1; row < matrix.Length; row++)
                {
                    if (matrix[row][headerIndex] == value)
                    {
                        Console.WriteLine(string.Join(" | ", matrix[row]));
                    }
                }
            }

            else if (command[0] == "sort")
            {
                var orderedMatrix = matrix.Skip(1).OrderBy(x => x[headerIndex]).ToArray();
                Console.WriteLine(string.Join(" | ", matrix[0]));

                foreach (var row in orderedMatrix)
                {
                    Console.WriteLine(string.Join(" | ", row));
                }
            }
        }
    }
}
