namespace P04_Hospital
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Hospital
    {
        public static void Main()
        {
            var hospital = new Dictionary<string, string[][]>();
            var doctors = new Dictionary<string, List<string>>();

            while (true)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "Output")
                {
                    break;
                }

                string department = input[0];
                string doctor = input[1] + ' ' + input[2];
                string patient = input[3];
                bool foundBed = false;

                if (!hospital.ContainsKey(department))
                {
                    hospital[department] = new string[20][];
                }

                for (int room = 0; room < hospital[department].Length; room++)
                {
                    if (hospital[department][room] == null)
                    {
                        hospital[department][room] = new string[3];
                    }

                    for (int bed = 0; bed < hospital[department][room].Length; bed++)
                    {
                        if (hospital[department][room][bed] == null)
                        {
                            hospital[department][room][bed] = patient;
                            foundBed = true;
                            break;
                        }
                    }

                    if (foundBed)
                    {
                        break;
                    }
                }

                if (!doctors.ContainsKey(doctor))
                {
                    doctors[doctor] = new List<string>();
                }

                doctors[doctor].Add(patient);
            }

            while (true)
            {
                var command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "End")
                {
                    break;
                }

                int room = -1;

                if (command.Length == 2)
                {
                    if (int.TryParse(command[1], out room))
                    {
                        string department = command[0];
                        room = int.Parse(command[1]) - 1;

                        var filteredRoom = hospital[department][room]
                            .Where(p => p != null)
                            .OrderBy(p => p);

                        foreach (var patient in filteredRoom)
                        {
                            Console.WriteLine(patient);
                        }
                    }

                    else
                    {
                        string doctor = command[0] + ' ' + command[1];

                        foreach (var patient in doctors[doctor].OrderBy(p => p))
                        {
                            Console.WriteLine(patient);
                        }
                    }
                }

                else
                {
                    string department = command[0];

                    foreach (var chamber in hospital[department].Where(c => c != null))
                    {
                        Console.WriteLine(string.Join(Environment.NewLine,
                            chamber.Where(p => p != null)));
                    }
                }
            }
        }
    }
}
