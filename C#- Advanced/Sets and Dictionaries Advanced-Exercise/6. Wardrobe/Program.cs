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

            var targetClothing = Console.ReadLine()
                .Split();
            var targetColor = targetClothing[0];
            var clothingToFind = targetClothing[1];

            foreach (var (color, clothes) in wardrobe)
            {
                Console.WriteLine($"{color} clothes:");

                foreach (var (clothing, count) in clothes)
                {
                    if (targetColor == color && clothingToFind == clothing)
                    {
                        Console.WriteLine($"* {clothing} - {count} (found!)");
                        continue;
                    }

                    Console.WriteLine($"* {clothing} - {count}");

                }
            }
        }
    }
}
