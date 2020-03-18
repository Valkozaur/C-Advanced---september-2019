namespace _7.EqualityLogic
{
    using System;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main()
        {
            var hashPeople = new HashSet<Person>();
            var sortedPeople = new SortedSet<Person>();

            var numberOfLines = int.Parse(Console.ReadLine());

            for (var i = 0; i < numberOfLines; i++)
            {
                var input = Console.ReadLine()
                    .Split();

                var name = input[0];
                var age = int.Parse(input[1]);

                var person = new Person(name, age);
                hashPeople.Add(person);
                sortedPeople.Add(person);
            }

            Console.WriteLine(hashPeople.Count);
            Console.WriteLine(sortedPeople.Count);
        }
    }
}
