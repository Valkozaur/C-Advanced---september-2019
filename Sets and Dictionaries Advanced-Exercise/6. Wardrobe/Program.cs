using System;
using System.Collections.Generic;

namespace _6._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            var linesOfInput = int.Parse(Console.ReadLine());
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < linesOfInput; i++)
            {
                var input = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                var colorToFind = input[0];
                var clothes = input[1]
                    .Split(",");

                if (!wardrobe.ContainsKey(colorToFind))
                {
                    wardrobe.Add(colorToFind, new Dictionary<string, int>());
                }
                    foreach (var clothing in clothes)
                    {
                        if (!wardrobe[colorToFind].ContainsKey(clothing))
                        {
                            wardrobe[colorToFind].Add(clothing, 0);
                        }

                        wardrobe[colorToFind][clothing]++;
                    }

            }

            var toFind = Console.ReadLine()
                .Split();
            var color = toFind[0];
            var clothingToFind = toFind[1];

            foreach (var colorCollection in wardrobe)
            {
                Console.WriteLine($"{colorCollection.Key} clothes:");

                foreach (var clothing in colorCollection.Value)
                {
                    if (color == colorCollection.Key && clothingToFind == clothing.Key)
                    {
                        Console.WriteLine($"* {clothing.Key} - {clothing.Value} (found!)");
                        continue;
                    }

                    Console.WriteLine($"* {clothing.Key} - {clothing.Value}");

                }
            }
        }
    }
}
