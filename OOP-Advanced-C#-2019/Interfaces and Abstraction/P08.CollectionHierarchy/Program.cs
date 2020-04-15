using P08.CollectionHierarchy.Collections;
using System;

namespace P08.CollectionHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            var addCollection = new AddCollection<string>();
            var addRemoveCollection = new AddRemoveCollection<string>();
            var myList = new MyList<string>();

            var input = Console.ReadLine()
                .Split(" ");
            var numberOfRemoveOperations = int.Parse(Console.ReadLine());

            foreach (var item in input)
            {
                Console.Write(addCollection.Add(item) + " ");
            }

            Console.WriteLine();

            foreach (var item in input)
            {
                Console.Write(addRemoveCollection.Add(item) + " ");
            }

            Console.WriteLine();

            foreach (var item in input)
            {
                Console.Write(myList.Add(item) + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < numberOfRemoveOperations; i++)
            {
                Console.Write(addRemoveCollection.Remove() + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < numberOfRemoveOperations; i++)
            {
                Console.Write(myList.Remove() + " ");
            }
        }
    }
}
