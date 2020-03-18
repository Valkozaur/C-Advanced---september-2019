using System;
using System.Collections.Generic;

namespace _5._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var occuranceOfSymbols = new SortedDictionary<char, int>();

            foreach (var symbol  in input)
            {
                if (!occuranceOfSymbols.ContainsKey(symbol))
                {
                    occuranceOfSymbols.Add(symbol, 0);
                }

                occuranceOfSymbols[symbol]++;
            }

            foreach (var symbol in occuranceOfSymbols)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
