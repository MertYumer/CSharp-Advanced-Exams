using System;
using System.Collections.Generic;
using System.Linq;

public class Sneaking
{
    public static void Main()
    {
        var rows = int.Parse(Console.ReadLine());
        var cols = rows * 2;
        var field = new char[rows][];

        GetField(field, cols);
        var input = Console.ReadLine();
        var commands = new Queue<char>(input);
        while (true)
        {

            MoveMonsters(field);
            bool samIsAlive = CheckSamIsAlive(field);
            if (!samIsAlive)
            {
                int[] samLastPositions = FindSamLastPosition(field);
                Console.WriteLine($"Sam died at {samLastPositions[0]}, {samLastPositions[1]}");
                break;
            }

            FIndSam(field, commands);
            bool nikoladzeIsAlive = CheckNikoladze(field);
            if (!nikoladzeIsAlive)
            {
                Console.WriteLine("Nikoladze killed!");
                break;
            }
        }
        PrintField(field);
    }

    private static int[] FindSamLastPosition(char[][] field)
    {
        var samPositions = new int[2];
        for (int rowIndex = 0; rowIndex < field.Length; rowIndex++)
        {
            for (int colIndex = 0; colIndex < field[rowIndex].Length; colIndex++)
            {
                if (field[rowIndex][colIndex] == 'X')
                {
                    samPositions[0] = rowIndex;
                    samPositions[1] = colIndex;
                    break;
                }
            }
        }

        return samPositions;
    }

    private static bool CheckNikoladze(char[][] field)
    {
        for (int rowIndex = 0; rowIndex < field.Length; rowIndex++)
        {
            if (field[rowIndex].Contains('S') && field[rowIndex].Contains('N'))
            {
                for (int colIndex = 0; colIndex < field[rowIndex].Length; colIndex++)
                {
                    if (field[rowIndex][colIndex] == 'N')
                    {
                        field[rowIndex][colIndex] = 'X';
                        return false;
                    }
                }
            }
        }

        return true;
    }

    private static void FIndSam(char[][] field, Queue<char> commands)
    {
        var currentCommand = commands.Dequeue();
        for (int rowIndex = 0; rowIndex < field.Length; rowIndex++)
        {
            if (field[rowIndex].Contains('S'))
            {

                for (int colIndex = 0; colIndex < field[rowIndex].Length; colIndex++)
                {
                    if (field[rowIndex][colIndex] == 'S')
                    {
                        var samColIndex = colIndex;

                        MoveSam(field, rowIndex, samColIndex, currentCommand);
                        return;
                    }

                }

            }
        }
    }

    private static void MoveSam(char[][] field, int rowIndex, int samColIndex, char currentCommand)
    {
        if (currentCommand == 'D')
        {
            field[rowIndex + 1][samColIndex] = 'S';

        }
        else if (currentCommand == 'U')
        {
            field[rowIndex - 1][samColIndex] = 'S';
        }
        else if (currentCommand == 'R')
        {
            field[rowIndex][samColIndex + 1] = 'S';
        }
        else if (currentCommand == 'L')
        {
            field[rowIndex][samColIndex - 1] = 'S';
        }

        if (currentCommand != 'W')
        {
            field[rowIndex][samColIndex] = '.';
        }
    }

    private static bool CheckSamIsAlive(char[][] field)
    {
        var samIsAlive = false;
        for (int rowIndex = 0; rowIndex < field.Length; rowIndex++)
        {
            if (field[rowIndex].Contains('S'))
            {
                samIsAlive = true;
                for (int colIndex = 0; colIndex < field[rowIndex].Length; colIndex++)
                {

                    if (field[rowIndex][colIndex] == 'S')
                    {
                        var samColIndex = colIndex;
                        for (int i = 0; i < samColIndex; i++)
                        {
                            if (field[rowIndex][i] == 'b')
                            {
                                field[rowIndex][samColIndex] = 'X';
                                return false;
                            }
                        }

                        for (int i = samColIndex; i < field[rowIndex].Length; i++)
                        {
                            if (field[rowIndex][i] == 'd')
                            {
                                field[rowIndex][colIndex] = 'X';
                                return false;
                            }
                        }
                    }

                }
            }
        }

        return samIsAlive;
    }

    private static void MoveMonsters(char[][] field)
    {
        for (int rowIndex = 0; rowIndex < field.Length; rowIndex++)
        {
            for (int colIndex = 0; colIndex < field[rowIndex].Length; colIndex++)
            {
                var currentChar = field[rowIndex][colIndex];
                if (currentChar == 'd')
                {
                    if (colIndex == 0)
                    {
                        field[rowIndex][colIndex] = 'b';
                    }
                    else
                    {
                        field[rowIndex][colIndex] = '.';
                        field[rowIndex][colIndex - 1] = 'd';
                        colIndex++;
                    }
                }
                else if (currentChar == 'b')
                {
                    if (colIndex == field[rowIndex].Length - 1)
                    {
                        field[rowIndex][colIndex] = 'd';
                    }
                    else
                    {
                        field[rowIndex][colIndex] = '.';
                        field[rowIndex][colIndex + 1] = 'b';
                        colIndex++;
                    }
                }
            }
        }
    }

    private static void PrintField(char[][] field)
    {
        foreach (var rows in field)
        {
            Console.WriteLine(string.Join("", rows));
        }
    }

    private static void GetField(char[][] field, int cols)
    {
        for (int rowIndex = 0; rowIndex < field.GetLength(0); rowIndex++)
        {
            var input = Console.ReadLine()?.ToCharArray();
            field[rowIndex] = new char[cols];
            field[rowIndex] = input;
        }
    }
}
