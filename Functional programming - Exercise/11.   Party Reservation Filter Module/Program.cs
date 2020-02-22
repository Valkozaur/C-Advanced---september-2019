using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.___Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> invitations = Console.ReadLine()
                .Split(" ")
                .ToList();
            List<string> activeFilters = new List<string>();

            string input = Console.ReadLine();
            while(input != "Print")
            {
                string[] tokens = input
                    .Split(';', 2);
                string command = tokens[0];
                string filterType = tokens[1];  

                switch (command)
                {
                    case "Add filter":
                        activeFilters.Add(filterType);
                        break;
                    case "Remove filter":
                        activeFilters.Remove(filterType);                        
                        break;
                }

                input = Console.ReadLine();
            }

            foreach (var filter in activeFilters)
            {
                string[] filterTokens = filter
                    .Split(";");
                string filterType = filterTokens[0];
                string filterParameter = filterTokens[1];

                Func<string, string, bool> filterToApply = FunctionType(filterType);

                invitations = invitations
                    .Where(x => !filterToApply(x, filterParameter))
                    .ToList();
            }

            Console.WriteLine(String.Join(" ", invitations));
        }

        static Func<string, string, bool> FunctionType(string filterType)
        {
            if (filterType == "Starts with")
            {
                return (name, parameter) => name.StartsWith(parameter);
            }
            else if(filterType == "Ends with")
            {
                return (name, parameter) => name.EndsWith(parameter);
            }
            else if(filterType == "Length")
            {
                return (name, parameter) => name.Length == int.Parse(parameter);
            }
            else if(filterType == "Contains")
            {
                return (name, parameter) => name.Contains(parameter);
            }
            return null;
        }
    }
}
