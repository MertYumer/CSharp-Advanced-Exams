namespace P04_HitList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HitList
    {
        public static void Main()
        {
            int targetIndex = int.Parse(Console.ReadLine());
            int infoIndex = 0;
            var people = new Dictionary<string, Dictionary<string, string>>();

            while (true)
            {
                var input = Console.ReadLine().Split(new[] { '=', ':', ';' });

                if (input[0] == "end transmissions")
                {
                    break;
                }

                string name = input[0];

                if (!people.ContainsKey(name))
                {
                    people.Add(name, new Dictionary<string, string>());
                }

                for (int i = 1; i < input.Length - 1; i += 2)
                {
                    string key = input[i];
                    string value = input[i + 1];

                    if (!people[name].ContainsKey(key))
                    {
                        people[name].Add(key, value);
                    }

                    else
                    {
                        people[name][key] = value;
                    }
                }
            }

            var command = Console.ReadLine().Split();
            string searchedPerson = command[1];
            var orderedInfo = people[searchedPerson].OrderBy(k => k.Key);

            Console.WriteLine($"Info on {searchedPerson}:");

            foreach (var kvp in orderedInfo)
            {
                Console.WriteLine($"---{kvp.Key}: {kvp.Value}");
                infoIndex += kvp.Key.Length + kvp.Value.Length;
            }

            Console.WriteLine($"Info index: {infoIndex}");
            if (infoIndex >= targetIndex)
            {
                Console.WriteLine("Proceed");
            }

            else
            {
                Console.WriteLine($"Need {targetIndex - infoIndex} more info.");
            }
        }
    }
}
