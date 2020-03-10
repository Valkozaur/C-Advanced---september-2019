using System;
using System.Collections.Generic;

namespace _5.ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            var peoples = new List<Person>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                var spittedInput = input
                    .Split(" ");
                var name = spittedInput[0];
                var age = int.Parse(spittedInput[1]);
                var town = spittedInput[0];

                var person = new Person(name,age,town);
                peoples.Add(person);
            }

            var personNumber = int.Parse(Console.ReadLine());
            var searchedPerson = peoples[personNumber - 1];

            var equalPeople = 0;
            var nonEqualPeople = 0;

            foreach (var person in peoples)
            {
                if (searchedPerson.CompareTo(person) == 0)
                {
                    equalPeople++;
                }
                else
                {
                    nonEqualPeople++;
                }
            }

            if (equalPeople > 1)
            {
                Console.WriteLine($"{equalPeople} {nonEqualPeople} {peoples.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
