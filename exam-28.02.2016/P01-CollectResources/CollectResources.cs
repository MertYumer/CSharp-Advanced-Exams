namespace P01_CollectResources
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class CollectResources
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            string pattern = @"([a-z]+)(_([0-9]+))*";
            int bestCollection = 0;
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var command = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int start = command[0];
                int step = command[1];
                int currentCollection = 0;
                var visitedIndexes = new List<int>();

                for (int j = start; j < input.Length; j++)
                {
                    Match matchedResource = Regex.Match(input[j], pattern);
                    string resourceAndQuantity = matchedResource.Groups[0].Value;
                    string resource = matchedResource.Groups[1].Value;

                    int quantity = matchedResource.Groups[3].Value != string.Empty
                        ? int.Parse(matchedResource.Groups[3].Value)
                        : 1;

                    if (!visitedIndexes.Contains(j) && (resource == "gold" || resource == "wood"
                        || resource == "stone" || resource == "food"))
                    {
                        currentCollection += quantity;
                        visitedIndexes.Add(j);
                    }

                    else if (visitedIndexes.Contains(j) || step >= input.Length)
                    {
                        break;
                    }

                    j += step - 1;

                    if (j + 1 >= input.Length)
                    {
                        j -= input.Length;
                    }
                }

                if (currentCollection > bestCollection)
                {
                    bestCollection = currentCollection;
                }
            }

            Console.WriteLine(bestCollection);
        }
    }
}
