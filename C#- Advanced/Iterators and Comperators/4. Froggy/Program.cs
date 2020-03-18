namespace _4._Froggy
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            var stones = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            var lake = new Lake(stones);
            Console.WriteLine(String.Join(", ", lake));
        }
    }
}