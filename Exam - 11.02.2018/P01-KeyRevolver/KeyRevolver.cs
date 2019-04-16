namespace P01_KeyRevolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class KeyRevolver
    {
        public static void Main()
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            var bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            var locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int intelligence = int.Parse(Console.ReadLine());

            int usedBullets = 0;
            int earnings = 0;

            while (bullets.Any() && locks.Any())
            {
                if (bullets.Pop() <= locks.Peek())
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }

                else
                {
                    Console.WriteLine("Ping!");
                }

                usedBullets++;

                if (usedBullets % barrelSize == 0 && bullets.Any())
                {
                    Console.WriteLine("Reloading!");
                }

                if (locks.Count == 0)
                {
                    earnings = intelligence - (usedBullets * bulletPrice);
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${earnings}");
                    break; ;
                }

                else if (bullets.Count == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    break;
                }
            }
        }
    }
}
