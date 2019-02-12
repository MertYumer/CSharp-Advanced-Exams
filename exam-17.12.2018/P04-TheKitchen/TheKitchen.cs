namespace P04_TheKitchen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TheKitchen
    {
        public static void Main()
        {
            var firstLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var secondLine = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var knives = new Stack<int>(firstLine);
            var forks = new Queue<int>(secondLine);
            var collection = new List<int>();

            while (knives.Count > 0 && forks.Count > 0)
            {
                if (knives.Peek() < forks.Peek())
                {
                    knives.Pop();
                }

                else if (knives.Peek() == forks.Peek())
                {
                    forks.Dequeue();
                    int knife = knives.Pop() + 1;
                    knives.Push(knife);
                }

                else
                {
                    int knife = knives.Pop();
                    int fork = forks.Dequeue();
                    collection.Add(knife + fork);
                }
            }

            Console.WriteLine($"The biggest set is: {collection.Max()}");
            Console.WriteLine(string.Join(" ", collection));
        }
    }
}
