namespace P04_Events
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Events
    {
        public static void Main()
        {
            string pattern =
                @"^#(?<name>[A-Za-z]+): *@(?<location>[A-Za-z]+) *(?<time>(0[0-9]|1[0-9]|2[0-3]):([0-5][0-9]))$";

            int lines = int.Parse(Console.ReadLine());
            var events = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < lines; i++)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    string location = match.Groups["location"].Value;
                    string time = match.Groups["time"].Value;

                    if (!events.ContainsKey(location))
                    {
                        events[location] = new Dictionary<string, List<string>>();
                    }

                    if (!events[location].ContainsKey(name))
                    {
                        events[location][name] = new List<string>();
                    }

                    events[location][name].Add(time);
                }
            }

            var searchedLocations = Console.ReadLine().Split(',');
            var orderedEvents = events.OrderBy(e => e.Key);

            foreach (var currentEvent in orderedEvents)
            {
                if (searchedLocations.Any(l => l == currentEvent.Key))
                {
                    Console.WriteLine($"{currentEvent.Key}:");
                    var orderedPeople = currentEvent.Value.OrderBy(p => p.Key);
                    int place = 1;

                    foreach (var person in orderedPeople)
                    {
                        var orderedTime = person.Value.OrderBy(t => t);
                        Console.WriteLine($"{place++}. {person.Key} ->" +
                            $" {string.Join(", ", orderedTime)}");
                    }
                }
            }
        }
    }
}
