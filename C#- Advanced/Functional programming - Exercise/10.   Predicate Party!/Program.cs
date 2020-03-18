using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.___Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guestList = Console.ReadLine()
                .Split()
                .ToList();

            string inputLine = Console.ReadLine();
            while (inputLine != "Party!")
            {
                string[] commandArgs = inputLine
                    .Split();

                string command = commandArgs[0];
                string criteria = commandArgs[1];
                string givenString = commandArgs[2];

                switch (criteria)
                {
                    case "StartsWith":
                        Predicate<string> startsWith = name => name.StartsWith(givenString);
                        guestList = listWalkthrogh(guestList, startsWith, command);
                        break;

                    case "EndsWith":
                        Predicate<string> endsWith = name => name.EndsWith(givenString);
                        guestList = listWalkthrogh(guestList, endsWith, command);
                        break;

                    case "Length":
                        Predicate<string> lenghtIsValid = name => name.Length == int.Parse(givenString );
                        guestList = listWalkthrogh(guestList, lenghtIsValid, command);
                        break;
                }

                inputLine = Console.ReadLine();
            }

            Console.WriteLine(guestList.Any() ? $"{String.Join(", ", guestList)} are going to the party!" : "Nobody is going to the party!");
        }

        static List<string> listWalkthrogh(List<string> guests, Predicate<string> filter, string command)
        {
            var changedList = new List<string>();
            foreach (var guest in guests)
            {
                if (filter(guest))
                {
                    if (command == "Remove")
                    {
                        continue;
                    }
                    else if (command == "Double")
                    {
                        changedList.Add(guest);
                    }
                }

                changedList.Add(guest);
            }

            return changedList;
        }
    }
}
