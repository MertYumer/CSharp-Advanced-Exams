namespace P03_GreedyTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class GreedyTimes
    {
        public static void Main()
        {
            long bagCapacity = long.Parse(Console.ReadLine());
            var allTypes = new Dictionary<string, Dictionary<string, long>>();
            allTypes["Gold"] = new Dictionary<string, long>();
            allTypes["Gem"] = new Dictionary<string, long>();
            allTypes["Cash"] = new Dictionary<string, long>();
            var summedQuantity = new Dictionary<string, long>();
            summedQuantity["Gold"] = 0;
            summedQuantity["Gem"] = 0;
            summedQuantity["Cash"] = 0;

            string input = Console.ReadLine();
            string pattern = @"(gold|[a-zA-Z]{3}|[a-zA-Z]+gem)[\s]+([0-9]+)";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matchedTypes = regex.Matches(input);

            foreach (Match match in matchedTypes)
            {
                string item = match.Groups[1].Value;
                long quantity = long.Parse(match.Groups[2].Value);

                if (bagCapacity >= quantity)
                {
                    if (item.ToLower() == "gold")
                    {
                        if (!allTypes["Gold"].ContainsKey(item))
                        {
                            allTypes["Gold"][item] = 0;
                        }

                        allTypes["Gold"][item] += quantity;
                        summedQuantity["Gold"] += quantity;
                        bagCapacity -= quantity;
                    }

                    else if (item.ToLower().EndsWith("gem") && item.Length > 3)
                    {
                        if (summedQuantity["Gem"] + quantity > summedQuantity["Gold"])
                        {
                            continue;
                        }

                        if (!allTypes["Gem"].ContainsKey(item))
                        {
                            allTypes["Gem"][item] = 0;
                        }

                        allTypes["Gem"][item] += quantity;
                        summedQuantity["Gem"] += quantity;
                        bagCapacity -= quantity;
                    }

                    else if (item.Length == 3)
                    {
                        if (summedQuantity["Cash"] + quantity > summedQuantity["Gem"])
                        {
                            continue;
                        }

                        if (!allTypes["Cash"].ContainsKey(item))
                        {
                            allTypes["Cash"][item] = 0;
                        }

                        allTypes["Cash"][item] += quantity;
                        summedQuantity["Cash"] += quantity;
                        bagCapacity -= quantity;
                    }
                }
            }

            foreach (var type in allTypes.Where(t => t.Value.Any()))
            {
                Console.WriteLine($"<{type.Key}> ${summedQuantity[type.Key]}");

                var orderedItems = allTypes[type.Key]
                    .OrderByDescending(i => i.Key)
                    .ThenBy(i => i.Value);

                foreach (var item in orderedItems)
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
        }
    }
}
