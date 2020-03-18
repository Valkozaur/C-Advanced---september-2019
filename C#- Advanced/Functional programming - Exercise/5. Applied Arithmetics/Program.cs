using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>,Func<int, int>, List<int>> cicle = (collection, function) =>
            {
                var modifiedList = new List<int>();
                foreach (var number in collection)
                {
                    modifiedList.Add(function(number));
                }

                return modifiedList;
            };
            Func<int, int> add = x => x + 1;
            Func<int, int> multiply = x => x * 2;
            Func<int, int> subtract = x => x - 1;
            Action<List<int>> print = x => Console.WriteLine(String.Join(" ", x));

            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                var command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }

                switch (command)
                {
                    case "add":
                        numbers = cicle(numbers, add);
                        break; 

                    case "multiply":
                        numbers = cicle(numbers, multiply);
                        break;

                    case "subtract":
                        numbers = cicle(numbers, subtract);
                        break;

                    case "print":
                        print(numbers);
                        break;
                }
            }
        }
    }
}
