using System;

namespace _7._Predicate_for_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split();

            Func<string, bool> lenghtIsValid = x => x.Length <= n;

            foreach (var name in names)
            {
                if (lenghtIsValid(name))
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
