using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            var vLogger = new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Statistics")
                {
                    break;
                }

                var splittedInput = input
                    .Split();
                var vloggerName = splittedInput[0];
                var command = splittedInput[1];  

                if (command ==  "joined")
                {
                    if (!vLogger.ContainsKey(vloggerName))
                    {
                        vLogger.Add(vloggerName, new Dictionary<string, SortedSet<string>>());
                        vLogger[vloggerName].Add("Followers", new SortedSet<string>());
                        vLogger[vloggerName].Add("Following", new SortedSet<string>());
                    }
                }
                else if(command == "followed")
                {
                    var vloggerToFollow = splittedInput[2];
                    if (
                        !vLogger.ContainsKey(vloggerName)
                        || !vLogger.ContainsKey(vloggerToFollow)
                        || vloggerName == vloggerToFollow
                        )
                    {
                        continue;
                    }

                    vLogger[vloggerName]["Following"].Add(vloggerToFollow);
                    vLogger[vloggerToFollow]["Followers"].Add(vloggerName);
                }
            }

            vLogger = vLogger
                .OrderByDescending(x => x.Value["Followers"].Count)
                .ThenBy(x => x.Value["Following"].Count)
                .ToDictionary(k => k.Key, v => v.Value);

            Console.WriteLine($"The V-Logger has a total of {vLogger.Count} vloggers in its logs.");

            var counter = 0;
            foreach (var (vlogger, collectionOfPeople) in vLogger)
            {
                Console.WriteLine($"{++counter}. {vlogger} : {vLogger[vlogger]["Followers"].Count} followers, {vLogger[vlogger]["Following"].Count} following");

                if (counter == 1)
                {
                    foreach (var follower  in collectionOfPeople["Followers"])
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
            }
        }
    }
}
