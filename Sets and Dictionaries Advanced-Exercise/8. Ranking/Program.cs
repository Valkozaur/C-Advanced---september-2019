using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_8._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var contestsAndPasswords = new Dictionary<string, string>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "end of contests")
                {
                    break;
                }

                var splittedInput = input
                    .Split(":");

                var contestName = splittedInput[0];
                var password = splittedInput[1];

                contestsAndPasswords.Add(contestName, password);
            }

            var usersAndPoints = new Dictionary<string, Dictionary<string, int>>();
            var usersRanking = new Dictionary<string, int>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "end of submissions")
                {
                    break;
                }

                var splittedInput = input
                    .Split("=>");

                var contestName = splittedInput[0];
                var password = splittedInput[1];
                var user = splittedInput[2];
                var points = int.Parse(splittedInput[3]);

                if (!contestsAndPasswords.ContainsKey(contestName) || contestsAndPasswords[contestName] != password)
                {
                    continue;
                }

                if (!usersAndPoints.ContainsKey(user))
                {
                    usersAndPoints.Add(user, new Dictionary<string, int>());
                }

                if (!usersAndPoints[user].ContainsKey(contestName))
                {
                    usersAndPoints[user][contestName] = points;
                }
                else
                {
                    if (usersAndPoints[user][contestName] < points)
                    {
                        usersRanking[user] -= usersAndPoints[user][contestName];
                        usersAndPoints[user][contestName] = points;
                    }
                    else
                    {
                        continue;
                    }
                }

                if (!usersRanking.ContainsKey(user))
                {
                    usersRanking.Add(user, 0);
                }
                usersRanking[user] += points;
            }

            usersRanking = usersRanking
                .OrderByDescending(x => x.Value)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var user in usersRanking)
            {
                Console.WriteLine($"Best candidate is {user.Key} with total {user.Value} points.");
                break;
            }


            Console.WriteLine("Ranking:");
            foreach (var (user, contestCollection) in usersAndPoints.OrderBy(x => x.Key))
            {
                Console.WriteLine(user);

                foreach (var (contest, points) in contestCollection.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest} -> {points}");
                }
            }
        }
    }
}
