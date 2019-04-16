namespace P03_CubicAssault
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class CubicAssault
    {
        public static void Main()
        {
            var regions = new Dictionary<string, Dictionary<string, long>>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Count em all")
                {
                    var orderedRegions = regions
                        .OrderByDescending(r => r.Value["Black"])
                        .ThenBy(r => r.Key.Length)
                        .ThenBy(r => r.Key);

                    foreach (var currentRegion in orderedRegions)
                    {
                        Console.WriteLine(currentRegion.Key);
                        var orderedMeteors = currentRegion.Value
                            .OrderByDescending(m => m.Value)
                            .ThenBy(m => m.Key);

                        foreach (var currentMeteor in orderedMeteors)
                        {
                            Console.WriteLine($"-> {currentMeteor.Key} : {currentMeteor.Value}");
                        }
                    }

                    break;
                }

                var info = input
                    .Split(new string[] { " -> " }
                    , StringSplitOptions.RemoveEmptyEntries);

                string region = info[0];
                string meteor = info[1];
                long defeatedUnits = long.Parse(info[2]);

                if (!regions.ContainsKey(region))
                {
                    regions[region] = new Dictionary<string, long>();
                    regions[region].Add("Black", 0);
                    regions[region].Add("Red", 0);
                    regions[region].Add("Green", 0);
                }

                regions[region][meteor] += defeatedUnits;

                if (regions[region]["Green"] >= 1000000)
                {
                    regions[region]["Red"] += regions[region]["Green"] / 1000000;
                    regions[region]["Green"] = regions[region]["Green"] % 1000000;
                }

                if (regions[region]["Red"] >= 1000000)
                {
                    regions[region]["Black"] += regions[region]["Red"] / 1000000;
                    regions[region]["Red"] = regions[region]["Red"] % 1000000;
                }
            }
        }
    }
}
