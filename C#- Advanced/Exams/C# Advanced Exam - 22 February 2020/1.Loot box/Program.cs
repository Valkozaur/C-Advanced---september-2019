namespace _1.Loot_box
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var firstBoxSequence = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            var secondBoxSequence = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            var firstBox = new Queue<int>(firstBoxSequence);
            var secondBox = new Stack<int>(secondBoxSequence);

            var sumOfCollectedItems = 0;

            while (true)
            {
                if (firstBox.Count == 0)
                {
                    Console.WriteLine("First lootbox is empty");
                    break;
                }
                else if (secondBox.Count == 0)
                {
                    Console.WriteLine("Second lootbox is empty");
                    break;
                }

                var firstBoxItem = firstBox.Peek();
                var secondBoxItem = secondBox.Pop();
                var sumOfTwoItems = firstBoxItem + secondBoxItem;

                if (sumOfTwoItems % 2 == 0)
                {
                    sumOfCollectedItems += sumOfTwoItems;
                    firstBox.Dequeue();
                    continue;
                }
                else
                {
                    firstBox.Enqueue(secondBoxItem);
                }
            }

            if (sumOfCollectedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {sumOfCollectedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sumOfCollectedItems}");
            }
        }
    }
}
