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

            var rows = dimensions[0];
            var cols = dimensions[1];

            var matrix = new int[rows, cols];
            MatrixWrite(matrix);

            var subMatrixRow = 3;
            var subMatrixCol = 3;

            var maxSum = int.MinValue;
            var maxRow = 0;
            var maxCol = 0;
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

        private static void FindMaxSubMatrixSum(int[,] matrix, int subMatrixRows, int subMatrixCols, ref int maxSum, ref int maxRow, ref int maxCol)
        {
            for (int row = 0; row < matrix.GetLength(0) - subMatrixRows + 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - subMatrixCols + 1; col++)
                {
                    var currentSum = 0;

                    for (int subRow = 0; subRow < subMatrixRows; subRow++)
                    {
                        for (int subCol = 0; subCol < subMatrixCols; subCol++)
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
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
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
