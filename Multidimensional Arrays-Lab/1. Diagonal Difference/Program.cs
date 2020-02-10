using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            MatrixWrite(matrix);

            int[] matrixDiagonals = DiagonalSum(matrix);

            int rightDiagonal = matrixDiagonals[0];
            int leftDiagonal = matrixDiagonals[1];

            Console.WriteLine(Math.Abs(rightDiagonal - leftDiagonal))
        }


        static void MatrixWrite(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }


            }
        }

        static int[] DiagonalSum(int[,] matrix)
        {
            int[] matrixDiagonals = new int[2];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrixDiagonals[0] += matrix[row, row];
            }

            int col = matrix.GetLength(1) - 1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrixDiagonals[1] += matrix[row, col];
                col--;
            }

            return matrixDiagonals;
        }
    }


}
