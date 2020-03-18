using System;
using System.Linq;

namespace _5._Square_with_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[matrixSize[0], matrixSize[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] numbersInput = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = numbersInput[col];
                }
            }

            int maxSum = int.MinValue;  
            int maxRow = 0;
            int maxCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int currentSum = matrix[row + 0, col + 0] + matrix[row + 0, col + 1] +
                                     matrix[row + 1, col + 0] + matrix[row + 1, col + 1];

                    if (maxSum < currentSum)
                    {
                        maxSum = currentSum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            Console.WriteLine($"{matrix[maxRow + 0, maxCol + 0]} {matrix[maxRow + 0, maxCol + 1]}");
            Console.WriteLine($"{matrix[maxRow + 1, maxCol + 0]} {matrix[maxRow + 1, maxCol + 1]}");
            Console.WriteLine(maxSum);          
        }
    }
}
