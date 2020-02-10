using System;
using System.Linq;

namespace _2._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            var matrix = new int[dimensions[0], dimensions[1]];
            MatrixWrite(matrix);

            var subMatrixRow = 3;
            var subMatrixCol = 3;

            var maxSum = int.MinValue;
            var maxRow = -1;
            var maxCol = -1;
            FindMaxSubMatrixSum(matrix, subMatrixRow, subMatrixCol, ref maxSum, ref maxRow, ref maxCol);

            Console.WriteLine($"Sum = {maxSum}");
            for (int row = 0; row < subMatrixRow; row++)
            {
                for (int col = 0; col < subMatrixCol; col++)
                {
                    Console.Write(matrix[maxRow + row, maxCol + col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void FindMaxSubMatrixSum(int[,] matrix, int subMatrixRow, int subMatrixCol, ref int maxSum, ref int maxRow, ref int maxCol)
        {
            for (int row = 0; row < matrix.GetLength(0) - subMatrixRow + 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(0) - subMatrixCol + 1; col++)
                {
                    var currentSum = 0;

                    for (int subRow = 0; subRow < subMatrixRow; subRow++)
                    {
                        for (int subCol = 0; subCol < subMatrixCol; subCol++)
                        {
                            currentSum += matrix[row + subRow, col + subCol];
                        }
                    }

                    if (maxSum < currentSum)
                    {
                        maxSum = currentSum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }
        }

        private static void MatrixWrite(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }
        }
    }
}
