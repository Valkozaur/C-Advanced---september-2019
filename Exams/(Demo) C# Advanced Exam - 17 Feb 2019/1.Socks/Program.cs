using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Socks
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var leftSocksInput = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            var rightSocksInput = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            var leftSocks = new Stack<int>(leftSocksInput);
            var rightSocks = new Queue<int>(rightSocksInput);
            var pairs = new List<int>();
            var biggestPair = int.MinValue;

            var leftSock = 0;
            var rightSock = 0;
            var takeRightSock = true;

            while (true)
            {
                if (leftSocks.Any())
                {
                    leftSock = leftSocks.Pop();
                }
                else
                {
                    break;
                }

                if (rightSocks.Any())
                {
                    if (takeRightSock)
                    {
                    rightSock = rightSocks.Dequeue();
                    }
                }
                else
                {
                    break;
                }

                if (leftSock > rightSock)
                {
                    takeRightSock = true;
                    PairingSocks(leftSock, rightSock, pairs, ref biggestPair);
                }
                else if (leftSock < rightSock)
                {
                    takeRightSock = false;
                }
                else
                {

                    leftSock++;
                    takeRightSock = true;
                    leftSocks.Push(leftSock);
                }
            }

            Console.WriteLine(biggestPair);
            Console.WriteLine(String.Join(" ", pairs));
        }

        public static void PairingSocks(int leftSock, int rightSock, List<int> pairs, ref int biggestPair)
        {
            int currentPair = leftSock + rightSock;
            pairs.Add(currentPair);

            if (currentPair >= biggestPair)
            {
                biggestPair = currentPair;
            }
        }
    }
}
