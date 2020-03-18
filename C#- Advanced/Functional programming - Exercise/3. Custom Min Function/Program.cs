using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            Func<List<int>, int> minNumber = x =>
             {
                 int minNumber = int.MaxValue;
                 foreach (var number in x)
                 {
                     if (number < minNumber)
                     {
                         minNumber = number;
                     }
                 }
                 return minNumber;
             };

            Console.WriteLine(minNumber(numbers));
        }
    }
}
