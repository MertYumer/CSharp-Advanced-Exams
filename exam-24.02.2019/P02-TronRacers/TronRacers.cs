namespace P02_TronRacers
{
    using System;

    public class TronRacers
    {
        public static int n = int.Parse(Console.ReadLine());
        public static bool deadPlayer = false;
        public static int playerOneRow = -1;
        public static int playerOneCol = -1;
        public static int playerTwoRow = -1;
        public static int playerTwoCol = -1;

        public static void Main()
        {
            var field = new char[n][];

            for (int row = 0; row < n; row++)
            {
                field[row] = Console.ReadLine().ToCharArray();

                for (int col = 0; col < field[row].Length; col++)
                {
                    if (field[row][col] == 'f')
                    {
                        playerOneRow = row;
                        playerOneCol = col;
                    }

                    else if (field[row][col] == 's')
                    {
                        playerTwoRow = row;
                        playerTwoCol = col;
                    }
                }
            }

            while (true)
            {
                var commands = Console.ReadLine().Split();
                string firstCommand = commands[0];
                string secondCommand = commands[1];

                MovePlayer(field, playerOneRow, playerOneCol, firstCommand, 'f', 's');

                if (deadPlayer)
                {
                    PrintField(field);
                    break;
                }

                MovePlayer(field, playerTwoRow, playerTwoCol, secondCommand, 's', 'f');

                if (deadPlayer)
                {
                    PrintField(field);
                    break;
                }
            }
        }

        public static void PrintField(char[][] field)
        {
            foreach (var row in field)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        public static void MovePlayer(char[][] field, int row, int col,
            string command, char symbol, char enemy)
        {
            switch (command)
            {
                case "up":
                    row = row > 0 ? row - 1 : n - 1;
                    break;

                case "right":
                    col = col < n - 1 ? col + 1 : 0;
                    break;

                case "down":
                    row = row < n - 1 ? row + 1 : 0;
                    break;

                case "left":
                    col = col > 0 ? col - 1 : n - 1;
                    break;
            }

            if (field[row][col] == enemy)
            {
                deadPlayer = true;
                field[row][col] = 'x';
            }

            else
            {
                field[row][col] = symbol;
            }

            playerOneRow = symbol == 'f' ? row : playerOneRow;
            playerOneCol = symbol == 'f' ? col : playerOneCol;
            playerTwoRow = symbol == 's' ? row : playerTwoRow;
            playerTwoCol = symbol == 's' ? col : playerTwoCol;
        }
    }
}
