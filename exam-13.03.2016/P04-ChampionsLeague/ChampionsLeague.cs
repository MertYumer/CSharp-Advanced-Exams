namespace P04_ChampionsLeague
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ChampionsLeague
    {
        public static void Main()
        {
            var teams = new List<Team>();

            while (true)
            {
                var input = Console.ReadLine()
                    .Split(new string[] { " | " }
                    , StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "stop")
                {
                    var orderedTeams = teams
                        .OrderByDescending(t => t.Wins)
                        .ThenBy(t => t.Name);

                    foreach (var team in orderedTeams)
                    {
                        Console.WriteLine(team.Name);
                        Console.WriteLine($"- Wins: {team.Wins}");
                        Console.WriteLine($"- Opponents: " +
                            $"{string.Join(", ", team.Opponents.OrderBy(o => o))}");
                    }

                    break;
                }

                string firstName = input[0];
                string secondName = input[1];
                int firstIndex = teams.FindIndex(t => t.Name == firstName);
                int secondIndex = teams.FindIndex(t => t.Name == secondName);

                Team firstTeam = firstIndex != -1
                    ? teams[firstIndex]
                    : new Team(firstName);

                Team secondTeam = secondIndex != -1
                    ? teams[secondIndex]
                    : new Team(secondName);

                var firstResult = input[2]
                    .Split(':')
                    .Select(int.Parse)
                    .ToArray();

                var secondResult = input[3]
                    .Split(':')
                    .Select(int.Parse)
                    .ToArray();

                if (firstResult[0] + secondResult[1] > firstResult[1] + secondResult[0])
                {
                    firstTeam.Wins++;
                }

                else if (firstResult[1] + secondResult[0] > firstResult[0] + secondResult[1])
                {
                    secondTeam.Wins++;
                }

                else
                {
                    if (firstResult[1] > secondResult[1])
                    {
                        secondTeam.Wins++;
                    }

                    else
                    {
                        firstTeam.Wins++;
                    }
                }

                firstTeam = FindOpponent(firstTeam, secondName);
                secondTeam = FindOpponent(secondTeam, firstName);

                CheckTeam(teams, firstIndex, firstTeam);
                CheckTeam(teams, secondIndex, secondTeam);
            }
        }

        public static void CheckTeam(List<Team> teams, int index, Team team)
        {
            if (index == -1)
            {
                teams.Add(team);
            }

            else
            {
                teams[index] = team;
            }
        }

        public static Team FindOpponent(Team team, string name)
        {
            if (!team.Opponents.Contains(name))
            {
                team.Opponents.Add(name);
            }

            return team;
        }
    }

    public class Team
    {
        public Team(string name)
        {
            this.Name = name;
            this.Opponents = new List<string>();
        }

        public string Name { get; set; }

        public int Wins { get; set; }

        public List<string> Opponents { get; set; }
    }
}
