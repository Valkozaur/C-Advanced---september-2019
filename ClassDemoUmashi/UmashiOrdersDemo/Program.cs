using System;
using System.Collections.Generic;

namespace UmashiOrdersDemo
{
    class Program
    {
        static HashSet<string> Menu = new HashSet<string>
        {
            "kaburimaki", "hosumaki", "futomaki", "tempura", "kartofelrejer", "summerfulrejer", "rejerfamily"
        };
        static void Main(string[] args)
        {
            Console.WriteLine(String.Join(", ", Menu));

            string command = Console.ReadLine();
            while (command != "Closing time!")
            {
                string[] order = command
                            .Split(new[] { ' ', ',', '.' },
                             StringSplitOptions.RemoveEmptyEntries);

                if (!OrderIsValid(order))
                {
                    continue;
                }
                Client currentClient;

                string orderType = Console.ReadLine();
                if (orderType == "Eat here")
                {
                    int numberOfPeople = int.Parse(Console.ReadLine());
                    currentClient = new Client(order, orderType, numberOfPeople);
                }
                else if (orderType == "Take away")
                {
                    currentClient = new Client(order, orderType);
                }
            }
        }
        private static bool OrderIsValid(string[] currentOrder)
        {
            foreach (var item in currentOrder)
            {
                if (!Menu.Contains(item.ToLower()))
                {
                    Console.WriteLine($"{item}, is not in the order, try again!");
                    return false;
                }
            }
            return true;
        }
    }
}
