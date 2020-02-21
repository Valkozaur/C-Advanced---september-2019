using System;
using System.Linq;

namespace Problem_1._Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = item => Console.WriteLine(item);

            var input = Console.ReadLine()
                .Split()
                .ToList();
        }       
    }
}
