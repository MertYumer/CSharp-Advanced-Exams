namespace P01_Crossroads
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Crossroads
    {
        public static void Main()
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            var cars = new Queue<string>();
            int passedCars = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    Console.WriteLine("Everyone is safe.");
                    Console.WriteLine($"{passedCars} total cars passed the crossroads.");
                    break;
                }

                else if (input == "green")
                {
                    if (cars.Any())
                    {
                        int greenWindow = greenLight;

                        while (cars.Count > 0 && greenWindow > 0)
                        {
                            var currentCar = cars.Dequeue();

                            if (currentCar.Length <= greenWindow)
                            {
                                passedCars++;
                                greenWindow -= currentCar.Length;
                            }

                            else if (currentCar.Length <= greenWindow + freeWindow)
                            {
                                passedCars++;
                                break;
                            }

                            else
                            {
                                int letterIndex = greenWindow + freeWindow;
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{currentCar} was hit at {currentCar[letterIndex]}.");
                                return;
                            }
                        }
                    }
                }

                else
                {
                    cars.Enqueue(input);
                }
            }
        }
    }
}
