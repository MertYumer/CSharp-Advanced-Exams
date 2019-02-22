namespace P01_JediMeditation
{
    using System;
    using System.Collections.Generic;

    public class JediMeditation
    {
        public static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            var masters = new List<string>();
            var knights = new List<string>();
            var padawans = new List<string>();
            var ourPadawans = new List<string>();
            bool isYodaHere = false;

            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine().Split();

                for (int j = 0; j < input.Length; j++)
                {
                    string currentJedi = input[j];

                    switch (currentJedi[0])
                    {
                        case 'm':
                            masters.Add(currentJedi);
                            break;

                        case 'k':
                            knights.Add(currentJedi);
                            break;

                        case 'p':
                            padawans.Add(currentJedi);
                            break;

                        case 's':
                        case 't':
                            ourPadawans.Add(currentJedi);
                            break;

                        case 'y':
                            isYodaHere = true;
                            break;
                    }
                }
            }

            if (isYodaHere)
            {
                Console.WriteLine(string.Join(" ", masters) + " " + string.Join(" ", knights) + " "
                    + string.Join(" ", ourPadawans) + " " + string.Join(" ", padawans));
            }

            else
            {
                Console.WriteLine(string.Join(" ", ourPadawans) + " " + string.Join(" ", masters) + " "
                    + string.Join(" ", knights) + " " + string.Join(" ", padawans));
            }
        }
    }
}
