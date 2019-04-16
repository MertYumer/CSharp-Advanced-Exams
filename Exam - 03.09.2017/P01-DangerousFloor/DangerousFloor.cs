namespace P01_DangerousFloor
{
    using System;
    using System.Linq;

    public class DangerousFloor
    {
        public static void Main()
        {
            var board = new char[8, 8];

            for (int row = 0; row < board.GetLength(0); row++)
            {
                var elements = Console.ReadLine().Split(',').Select(char.Parse).ToArray();

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = elements[col];
                }
            }

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                char piece = command[0];
                int currentRow = (int)char.GetNumericValue(command[1]);
                int currentCol = (int)char.GetNumericValue(command[2]);
                int nextRow = (int)char.GetNumericValue(command[4]);
                int nextCol = (int)char.GetNumericValue(command[5]);

                if (board[currentRow, currentCol] != piece)
                {
                    Console.WriteLine("There is no such a piece!");
                    continue;
                }

                switch (piece)
                {
                    case 'K':
                        if (!CheckKing(currentRow, currentCol, nextRow, nextCol))
                        {
                            Console.WriteLine($"Invalid move!");
                            continue;
                        }

                        break;

                    case 'R':
                        if (!CheckRock(currentRow, currentCol, nextRow, nextCol))
                        {
                            Console.WriteLine($"Invalid move!");
                            continue;
                        }

                        break;

                    case 'B':
                        if (!CheckBishop(currentRow, currentCol, nextRow, nextCol))
                        {
                            Console.WriteLine($"Invalid move!");
                            continue;
                        }

                        break;

                    case 'Q':
                        if (!CheckQueen(currentRow, currentCol, nextRow, nextCol))
                        {
                            Console.WriteLine($"Invalid move!");
                            continue;
                        }

                        break;

                    case 'P':
                        if (!CheckPawn(currentRow, currentCol, nextRow, nextCol))
                        {
                            Console.WriteLine($"Invalid move!");
                            continue;
                        }

                        break;
                }

                if (!ValidCoordinates(currentRow, currentCol, nextRow, nextCol))
                {
                    Console.WriteLine($"Move go out of board!");
                    continue;
                }

                board[nextRow, nextCol] = piece;
                board[currentRow, currentCol] = 'x';
            }
        }

        public static bool CheckKing(int currentRow, int currentCol, int nextRow, int nextCol)
        {
            if (Math.Abs(currentRow - nextRow) == Math.Abs(currentCol - nextCol)
                || (currentRow == nextRow && Math.Abs(currentCol - nextCol) <= 1)
                || (currentCol == nextCol && Math.Abs(currentRow - nextRow) <= 1))
            {
                return true;
            }

            return false;
        }

        public static bool CheckRock(int currentRow, int currentCol, int nextRow, int nextCol)
        {
            if (nextRow == currentRow || nextCol == currentCol)
            {
                return true;
            }

            return false;
        }

        public static bool CheckBishop(int currentRow, int currentCol, int nextRow, int nextCol)
        {
            if (Math.Abs(currentRow - nextRow) == Math.Abs(currentCol - nextCol))
            {
                return true;
            }

            return false;
        }

        public static bool CheckQueen(int currentRow, int currentCol, int nextRow, int nextCol)
        {
            if (Math.Abs(currentRow - nextRow) == Math.Abs(currentCol - nextCol)
                || currentRow == nextRow
                || currentCol == nextCol)
            {
                return true;
            }

            return false;
        }

        public static bool CheckPawn(int currentRow, int currentCol, int nextRow, int nextCol)
        {
            if (nextCol == currentCol && nextRow == currentRow - 1)
            {
                return true;
            }

            return false;
        }

        public static bool ValidCoordinates(int currentRow, int currentCol, int nextRow, int nextCol)
        {
            if (nextRow < 0
                || nextRow >= 8
                || nextCol < 0
                || nextCol >= 8)
            {

                return false;
            }

            return true;
        }
    }
}
