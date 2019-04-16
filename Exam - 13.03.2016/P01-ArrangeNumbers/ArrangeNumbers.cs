namespace P01_ArrangeNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ArrangeNumbers
    {
        public static void Main()
        {
            var numbers = new List<Number>();
            var input = Console.ReadLine()
                .Split(new string[] { ", " }
                , StringSplitOptions.RemoveEmptyEntries);

            foreach (var value in input)
            {
                string name;
                var stringBuilder = new StringBuilder();

                for (int i = 0; i < value.Length; i++)
                {
                    name = FindNumberName(value[i].ToString());

                    if (i == 0)
                    {
                        stringBuilder.Append(name);
                    }

                    else
                    {
                        stringBuilder.Append("-" + name);
                    }
                }

                name = stringBuilder.ToString();
                var currentNumber = new Number(name, value);
                numbers.Add(currentNumber);
            }

            var orderedNumbers = numbers.OrderBy(n => n.Name);
            Console.WriteLine(string.Join(", ", orderedNumbers.Select(n => n.Value)));
        }

        public static string FindNumberName(string number)
        {
            int currentNumber = int.Parse(number);

            switch (currentNumber)
            {
                case 1:
                    return "one";

                case 2:
                    return "two";

                case 3:
                    return "three";

                case 4:
                    return "four";

                case 5:
                    return "five";

                case 6:
                    return "six";

                case 7:
                    return "seven";

                case 8:
                    return "eight";

                case 9:
                    return "nine";

                default:
                    return "zero";
            }
        }
    }

    public class Number
    {
        public Number(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        public string Name { get; set; }

        public string Value { get; set; }
    }
}
