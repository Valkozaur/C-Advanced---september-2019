using System;
using System.Linq;

namespace _4._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            var boundries = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            var lowerBoundry = boundries[0];
            var upperBoundry = boundries[1];

            var evenOrOdd = Console.ReadLine();

            Func<string, int, bool> isEven = (x, y) => x == "even" && y % 2 == 0;
            Func<string, int, bool> isOdd = (x, y) => x == "odd" && y % 2 == 1;
            Action<int> print = x => Console.Write(x + " "); 

            for (int currentNumber = lowerBoundry + 1; currentNumber < upperBoundry; currentNumber++)
            {
                if (isEven(evenOrOdd, currentNumber))
                {
                    print(currentNumber);
                }
                else if(isOdd(evenOrOdd, currentNumber))
                {
                    print(currentNumber);
                }
            }
        }
    }
}
