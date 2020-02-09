using System;
using System.Linq;

namespace _4._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] squareMatrix = new char[size, size];

            for (int row = 0; row < squareMatrix.GetLength(0); row++)
            {
                char[] inputRow = Console.ReadLine()
                    .ToCharArray();

                for (int col = 0; col < squareMatrix.GetLength(1); col++)
                {
                    squareMatrix[row, col] = inputRow[col];
                }
            }

            char symbolToFind = char.Parse(Console.ReadLine());

            for (int row = 0; row < squareMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < squareMatrix.GetLength(1); col++)
                {
                    char currentSymbol = squareMatrix[row, col];
                    if (currentSymbol == symbolToFind)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{symbolToFind} does not occur in the matrix ");
        }
    }
}
