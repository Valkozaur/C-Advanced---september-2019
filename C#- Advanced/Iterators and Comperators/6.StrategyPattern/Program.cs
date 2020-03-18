using System;
using System.Collections.Generic;

namespace _6.StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var sortedByName = new SortedSet<Person>(new NameComperator());
            var sortedByAge = new SortedSet<Person>(new AgeComperator());

            var linesOfInput = int.Parse(Console.ReadLine());
            for (int i = 0; i < linesOfInput; i++)
            {
                var input = Console.ReadLine()
                    .Split();

                var name = input[0];
                var age = int.Parse(input[1]);

                var person = new Person(name, age);
                sortedByName.Add(person);
                sortedByAge.Add(person);    
            }

            foreach (var person in sortedByName)
            {
                Console.WriteLine(person);
            }

            foreach (var person in sortedByAge)
            {
                Console.WriteLine(person);
            }
        }
    }
}
