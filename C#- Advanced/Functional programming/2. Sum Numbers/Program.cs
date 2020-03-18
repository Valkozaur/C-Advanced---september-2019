using System;
using System.Linq;

namespace _2._Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = int.Parse;

            var numbers = Console.ReadLine()
                .Split(
                    new[] { ' ', ',' },
                    StringSplitOptions.RemoveEmptyEntries
                    )
                .Select(parser)
                .ToArray();

            Console.WriteLine(numbers.Length
                + Environment.NewLine + numbers.Sum());
        }
    }
}
