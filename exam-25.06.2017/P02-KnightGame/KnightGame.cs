namespace P02_KnightGame
{
    using System;

    public class KnightGame
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var field = new char[n, n];
            int bestKnightRow = -1;
            int bestKnightCol = -1;
            int mostAttackedKnights = 0;
            int removedKnights = 0;

            for (int row = 0; row < n; row++)
            {
                var elements = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    field[row, col] = elements[col];
                }
            }

            while (true)
            {
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (field[row, col] == 'K')
                        {
                            int attackedKnights = CheckAttackedKnights(field, row, col);

                            if (attackedKnights > mostAttackedKnights)
                            {
                                mostAttackedKnights = attackedKnights;
                                bestKnightRow = row;
                                bestKnightCol = col;
                            }
                        }
                    }
                }

                if (mostAttackedKnights > 0)
                {
                    field[bestKnightRow, bestKnightCol] = '0';
                    mostAttackedKnights = 0;
                    removedKnights++;
                }

                else
                {
                    Console.WriteLine(removedKnights);
                    return;
                }
            }
        }

        public static int CheckAttackedKnights(char[,] field, int knightRow, int knightCol)
        {
            int attackedKnights = 0;

            if (knightRow - 1 >= 0 && knightCol - 2 >= 0)
            {
                if (field[knightRow - 1, knightCol - 2] == 'K')
                {
                    attackedKnights++;
                }
            }

            if (knightRow + 1 < field.GetLength(0) && knightCol - 2 >= 0)
            {
                if (field[knightRow + 1, knightCol - 2] == 'K')
                {
                    attackedKnights++;
                }
            }

            if (knightRow - 2 >= 0 && knightCol - 1 >= 0)
            {
                if (field[knightRow - 2, knightCol - 1] == 'K')
                {
                    attackedKnights++;
                }
            }

            if (knightRow - 2 >= 0 && knightCol + 1 < field.GetLength(1))
            {
                if (field[knightRow - 2, knightCol + 1] == 'K')
                {
                    attackedKnights++;
                }
            }

            if (knightRow - 1 >= 0 && knightCol + 2 < field.GetLength(1))
            {
                if (field[knightRow - 1, knightCol + 2] == 'K')
                {
                    attackedKnights++;
                }
            }

            if (knightRow + 1 < field.GetLength(0) && knightCol + 2 < field.GetLength(1))
            {
                if (field[knightRow + 1, knightCol + 2] == 'K')
                {
                    attackedKnights++;
                }
            }

            if (knightRow + 2 < field.GetLength(0) && knightCol - 1 >= 0)
            {
                if (field[knightRow + 2, knightCol - 1] == 'K')
                {
                    attackedKnights++;
                }
            }

            if (knightRow + 2 < field.GetLength(0) && knightCol + 1 < field.GetLength(1))
            {
                if (field[knightRow + 2, knightCol + 1] == 'K')
                {
                    attackedKnights++;
                }
            }

            return attackedKnights;
        }
    }
}
