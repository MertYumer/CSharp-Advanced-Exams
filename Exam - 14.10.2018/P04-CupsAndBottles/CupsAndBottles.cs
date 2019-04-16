namespace P04_CupsAndBottles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CupsAndBottles
    {
        public static void Main()
        {
            var firstLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var secondLine = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var cups = new Stack<int>(firstLine.Reverse());
            var bottles = new Queue<int>(secondLine.Reverse());
            int wastedLitters = 0;

            while (cups.Count > 0 && bottles.Count > 0)
            {
                if (cups.Peek() > bottles.Peek())
                {
                    var cup = cups.Pop();
                        cup -= bottles.Dequeue();

                    if (cup > 0)
                    {
                        cups.Push(cup);
                    }
                }

                else
                {
                    wastedLitters += (bottles.Dequeue() - cups.Pop());
                }
            }

            if (cups.Count > 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }

            else if (bottles.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedLitters}");
        }
    }
}
