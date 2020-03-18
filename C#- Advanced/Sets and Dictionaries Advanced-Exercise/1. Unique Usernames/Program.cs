using System;
using System.Collections.Generic;

namespace _1._Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var uniqueNames = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                var name = Console.ReadLine();
                uniqueNames.Add(name);
            }

            Console.WriteLine(String.Join(Environment.NewLine, uniqueNames));
        }
    }
}
