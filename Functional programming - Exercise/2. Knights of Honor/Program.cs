using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine()
                .Split()
                .ToList();

            Func<string, string> append = x => $"Sir {x}";
            Action<List<string>> print = x => 
                Console.WriteLine(String.Join(Environment.NewLine, x.Select(append)));

            print(names);
        }
    }
}
