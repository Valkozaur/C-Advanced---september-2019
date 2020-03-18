using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var linesOfInput = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var n = linesOfInput[0];
            var m = linesOfInput[1];

            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();

            for (int i = 1; i <= n + m; i++)
            {
                var number = int.Parse(Console.ReadLine());

                if (i <= n)
                {
                    firstSet.Add(number);
                    continue;
                }

                secondSet.Add(number);
            }

            foreach (var number in firstSet)
            {
                if (secondSet.Contains(number))
                {
                    Console.Write(number + " ");
                }
            }
        }
    }
}
