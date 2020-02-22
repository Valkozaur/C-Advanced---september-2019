using System;
using System.Linq;

namespace _12.___TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Func<string, char[]> toCharArray = x => x.ToCharArray();
            Func<char, int> castFunc = y => (int)y;
            Func<string, bool> finalFunc = x => toCharArray(x).Select(castFunc).Sum() >= number;
            
            Console.WriteLine
                (Console.ReadLine()
                .Split(" ")
                .FirstOrDefault(finalFunc));
        }
    }
}
