using System;
using System.Linq;

namespace _1._Sort_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, bool> findEven = x => x % 2 == 0;
            Action<int> print = x => Console.Write(x + " ");

            Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .Where(findEven)
                .OrderBy(x => x)
                .ToList()
                .ForEach(print);
        }
    }
}
