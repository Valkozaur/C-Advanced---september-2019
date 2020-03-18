namespace _9.List_of_Predicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ListOfPredicates
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            List<Predicate<int>> listOfPredicates = dividers
                .Select(div => (Predicate<int>)(n => n % div == 0))
                .ToList();

            for (int currentNumber = 1; currentNumber <= n; currentNumber++)
            {
                if (IsDivisible(currentNumber, listOfPredicates))
                {
                    Console.Write(currentNumber + " ");
                }
            }
        }

        static bool IsDivisible(int number,List<Predicate<int>> predicates)
        {
            foreach (var predicate in predicates)
            {
                if (!predicate(number))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
