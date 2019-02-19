namespace P02_Sneaking
{
    using System;

    public class Sneaking
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            var field = new char[rows][];
            int samRow = -1;
            int samCol = -1;

            for (int row = 0; row < rows; row++)
            {
                field[row] = Console.ReadLine().ToCharArray();

                for (int col = 0; col < field[row].Length; col++)
                {
                    if (field[row][col] == 'S')
                    {
                        samRow = row;
                        samCol = col;
                    }
                }
            }

            string directions = Console.ReadLine();

            foreach (var direction in directions)
            {
                for (int row = 0; row < field.GetLength(0); row++)
                {
                    for (int col = 0; col < field[row].Length; col++)
                    {
                        if (field[row][col] == 'd')
                        {
                            if (col == 0)
                            {
                                field[row][col] = 'b';
                            }

                            else
                            {
                                field[row][col] = '.';
                                field[row][col - 1] = 'd';
                            }

                            continue;
                        }

                        if (field[row][col] == 'b')
                        {
                            if (col == field[row].Length - 1)
                            {
                                field[row][col] = 'd';
                            }

                            else
                            {
                                field[row][col] = '.';
                                field[row][col + 1] = 'b';
                                col++;
                            }
                        }
                    }
                }


                switch (direction)
                {
                    case 'U':
                        if (CaughtByEnemy(field, samRow, samCol))
                        {
                            field[samRow][samCol] = 'X';
                            Console.WriteLine($"Sam died at {samRow}, {samCol}");
                            PrintField(field);
                            return;
                        }

                        field[samRow][samCol] = '.';
                        samRow--;
                        field[samRow][samCol] = 'S';

                        for (int col = 0; col < field[samRow].Length; col++)
                        {
                            if (field[samRow][col] == 'N')
                            {
                                field[samRow][col] = 'X';
                                Console.WriteLine("Nikoladze killed!");
                                PrintField(field);
                                return;
                            }
                        }

                        break;

                    case 'D':
                        if (CaughtByEnemy(field, samRow, samCol))
                        {
                            field[samRow][samCol] = 'X';
                            Console.WriteLine($"Sam died at {samRow}, {samCol}");
                            PrintField(field);
                            return;
                        }

                        field[samRow][samCol] = '.';
                        samRow++;
                        field[samRow][samCol] = 'S';

                        for (int col = 0; col < field[samRow].Length; col++)
                        {
                            if (field[samRow][col] == 'N')
                            {
                                field[samRow][col] = 'X';
                                Console.WriteLine("Nikoladze killed!");
                                PrintField(field);
                                return;
                            }
                        }

                        break;

                    case 'L':
                        if (CaughtByEnemy(field, samRow, samCol))
                        {
                            field[samRow][samCol] = 'X';
                            Console.WriteLine($"Sam died at {samRow}, {samCol}");
                            PrintField(field);
                            return;
                        }

                        field[samRow][samCol] = '.';
                        samCol--;
                        field[samRow][samCol] = 'S';
                        break;

                    case 'R':
                        if (CaughtByEnemy(field, samRow, samCol))
                        {
                            field[samRow][samCol] = 'X';
                            Console.WriteLine($"Sam died at {samRow}, {samCol}");
                            PrintField(field);
                            return;
                        }

                        field[samRow][samCol] = '.';
                        samCol++;
                        field[samRow][samCol] = 'S';
                        break;
                }
            }
        }

        public static bool CaughtByEnemy(char[][] field, int samRow, int samCol)
        {
            for (int col = 0; col < samCol; col++)
            {
                if (field[samRow][col] == 'b')
                {
                    return true;
                }
            }

            for (int col = samCol + 1; col < field[samRow].Length; col++)
            {
                if (field[samRow][col] == 'd')
                {
                    return true;
                }
            }

            return false;
        }

        public static void PrintField(char[][] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                Console.WriteLine(string.Join("", field[row]));
            }
        }
    }
}