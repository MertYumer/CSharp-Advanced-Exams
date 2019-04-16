namespace P02_Tagram
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tagram
    {
        public static void Main()
        {
            var users = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                var input = Console.ReadLine().Split(" -> ");

                if (input[0] == "end")
                {
                    break;
                }

                else if (input[0].Contains("ban"))
                {
                    var checkSplit = input[0].Split();
                    string searchedUser = checkSplit[1];

                    users.Remove(searchedUser);
                    continue;
                }

                string username = input[0];
                string tag = input[1];
                int likes = int.Parse(input[2]);

                if (!users.ContainsKey(username))
                {
                    users.Add(username, new Dictionary<string, int>());
                }

                if (!users[username].ContainsKey(tag))
                {
                    users[username].Add(tag, likes);
                }

                else
                {
                    users[username][tag] += likes;
                }
            }

            var orderedUsers = users
                .OrderByDescending(u => u.Value.Values.Sum())
                .ThenBy(u => u.Value.Count);

            foreach (var user in orderedUsers)
            {
                Console.WriteLine(user.Key);

                foreach (var tag in user.Value)
                {
                    Console.WriteLine($"- {tag.Key}: {tag.Value}");
                }
            }
        }
    }
}
