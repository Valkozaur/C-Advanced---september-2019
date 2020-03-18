namespace _3._Generic_Swap_Method_Strings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var boxes = new List<Box<int>>();
            var numberOfItems = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfItems; i++)
            {
                var input = int.Parse(Console.ReadLine());
                var box = new Box<int>();
                box.Value = input;
                boxes.Add(box);
            }

            var indexes = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            var firstIndex = indexes[0];
            var secondIndex = indexes[1];

            Swap(boxes, firstIndex,secondIndex);
            
            foreach (var box in boxes)
            {
                Console.WriteLine(box);
            }
        }
        public static void Swap<T>(List<T> list, int indexOne, int indexTwo)
        {
            if (!IndexValidator(list.Count, indexOne) &&
                !IndexValidator(list.Count, indexOne))
            {
                throw new IndexOutOfRangeException("Index is not in the bounds of the bounds of the list");
            }
            T temp = list[indexOne];
            list[indexOne] = list[indexTwo];
            list[indexTwo] = temp;
        }

        private static bool IndexValidator(int listCount, int index)
        {
            return 0 <= index && index < listCount;
        }
    } 
}
