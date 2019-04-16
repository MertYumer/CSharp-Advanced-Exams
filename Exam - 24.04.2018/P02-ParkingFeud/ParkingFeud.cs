namespace P02_ParkingFeud
{
    using System;
    using System.Linq;

    public class ParkingFeud
    {
        static int rows = 0;
        static int cols = 0;

        public static void Main()
        {
            var matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            rows = matrixSize[0];
            cols = matrixSize[1];
            int totalSteps = 0;

            int entrance = int.Parse(Console.ReadLine());

            while (true)
            {
                var input = Console.ReadLine().Split();
                string samSpot = input[entrance - 1];
                int samSteps = GetSteps(entrance, samSpot);
                bool isParked = true;

                for (int i = 0; i < input.Length; i++)
                {
                    bool isSameSpot = input[i] == samSpot;
                    bool isDifferentRow = i + 1 != entrance;

                    if (isSameSpot && isDifferentRow)
                    {
                        int otherDriverSteps = GetSteps(i + 1, input[i]);

                        if (otherDriverSteps < samSteps)
                        {
                            totalSteps += samSteps * 2;
                            isParked = false;
                            break;
                        }
                    }
                }

                if (isParked)
                {
                    totalSteps += samSteps;
                    Console.WriteLine($"Parked successfully at {input[entrance - 1]}.");
                    Console.WriteLine($"Total Distance Passed: {totalSteps}");
                    return;
                }
            }
        }

        public static int GetSteps(int samRow, string samSpot)
        {
            int parkingRow = int.Parse(samSpot.Substring(1));
            int parkingCol = samSpot[0] - 'A' + 1;

            int currentSteps = 0;
            bool moveRight = true;

            while (parkingRow != samRow && parkingRow - 1 != samRow)
            {
                currentSteps += cols + 3;

                if (samRow > parkingRow)
                {
                    samRow--;
                }

                else if (samRow < parkingRow)
                {
                    samRow++;
                }

                moveRight = !moveRight;
            }

            if (moveRight)
            {
                currentSteps += parkingCol;
            }

            else
            {
                currentSteps += cols - parkingCol + 1;
            }

            return currentSteps;
        }
    }
}
