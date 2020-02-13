using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var periodicTable = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                var chemicalElementsInput = Console.ReadLine()
                    .Split(" ");

                foreach (var chemicalElement in chemicalElementsInput)
                {
                    periodicTable.Add(chemicalElement);
                }
            }

            Console.WriteLine(String.Join(" ", periodicTable));
        }
    }
}
