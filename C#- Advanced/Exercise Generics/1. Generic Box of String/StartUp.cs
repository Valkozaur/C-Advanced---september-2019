namespace _1._Generic_Box_of_String
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;

    public class StartUp
    {
        public static void Main()
        {
            var boxes = new List<Box<int>>();

            var numberOfInput = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInput; i++)
            {
                var inputName = int.Parse(Console.ReadLine());
                var box = new Box<int>(inputName);
                boxes.Add(box);
            }

            foreach (var box in boxes)
            {
                Console.WriteLine(box);
            }
        }
    }
}
