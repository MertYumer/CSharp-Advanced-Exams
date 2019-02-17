namespace P01_Socks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Socks
    {
        public static void Main()
        {
            var firstLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var secondLine = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var leftSocks = new Stack<int>(firstLine);
            var rightSocks = new Queue<int>(secondLine);
            var pairs = new List<int>();

            while (leftSocks.Any() && rightSocks.Any())
            {
                if (leftSocks.Peek() > rightSocks.Peek())
                {
                    pairs.Add(leftSocks.Pop() + rightSocks.Dequeue());
                }

                else if (leftSocks.Peek() < rightSocks.Peek())
                {
                    leftSocks.Pop();
                }

                else
                {
                    rightSocks.Dequeue();
                    int leftSock = leftSocks.Pop() + 1;
                    leftSocks.Push(leftSock);
                }
            }

            Console.WriteLine(pairs.Max());
            Console.WriteLine(string.Join(" ", pairs));
        }
    }
}
