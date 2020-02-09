using System;
using System.Linq;

namespace _1.Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixDimensions = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int rows = matrixDimensions[0];
            int columns = matrixDimensions[1];

            int[,] matrix = new int[rows, columns];
            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] numbers = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = numbers[col];
                    sum += matrix[row, col];
                }
            }

            Console.WriteLine
                (
                matrix.GetLength(0) + Environment.NewLine +
                matrix.GetLength(1) + Environment.NewLine +
                sum
                );
        }
    }
}
