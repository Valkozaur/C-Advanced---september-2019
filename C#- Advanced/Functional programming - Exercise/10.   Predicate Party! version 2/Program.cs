using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.___Predicate_Party__version_2
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

                Func<string, string, bool> predicate;
                predicate = GetFunc(criteria);

                if (command == "Remove")
                {
                    guestList = guestList.Where(x => !predicate(x, givenString)).ToList();
                }
                else if (command == "Double")
                {
                    List<string> guestsToDouble = new List<string>();
                    guestsToDouble = guestList.Where(x => predicate(x, givenString)).ToList();

                    foreach (var name in guestsToDouble)
                    {
                        guestList.Insert(guestList.IndexOf(name), name);
                    }
                }

                inputLine = Console.ReadLine();
            }

            Console.WriteLine(guestList.Any() ? $"{String.Join(", ", guestList)} are going to the party!" : "Nobody is going to the party!");
        }

        private static Func<string, string, bool> GetFunc(string criteria)
        {
            if (criteria == "StartsWith")
            {
                return (x, y) => x.StartsWith(y);
            }
            else if(criteria == "EndsWith")
            {
                return (x, y) => x.EndsWith(y);
            }
            else if(criteria == "Length")
            {
                return (x, y) => x.Length == int.Parse(y);
            }

            return null;
        }
    }
}
