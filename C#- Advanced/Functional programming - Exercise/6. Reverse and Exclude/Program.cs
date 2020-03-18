using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            var divisbleBy = int.Parse(Console.ReadLine());

            Predicate<int> isDivisible = x => x % divisbleBy == 0;

            Func<List<int>,Predicate<int>, List<int>> reverseAndFilter = (collection, predicate) =>
            {
                var reversedCollection = new List<int>();

                for (int i = collection.Count - 1; i >= 0; i--)
                {
                    if (!predicate(numbers[i]))
                    {
                        reversedCollection.Add(numbers[i]);
                    }
                }

                return reversedCollection;
            };

            numbers = reverseAndFilter(numbers, isDivisible);
            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
