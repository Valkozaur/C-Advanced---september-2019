using System;
using System.Linq;

namespace _2._2X2_Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = dimensions[0];
            var cols = dimensions[1];
            var matrix = new char[rows, cols];
            var subMatrixRows = 2;
            var subMatrixCols = 2;

            MatrixWrite(matrix);

            int countOfEqualPairs = CountOfEqualPairs(matrix, subMatrixRows, subMatrixCols);

            Console.WriteLine(countOfEqualPairs);

        }

        static void MatrixWrite(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
        }

        static int CountOfEqualPairs(char[,] matrix, int subMatrixRows, int subMatrixCols)
        {
            int equalPairsCount = 0;
            for (int row = 0; row < matrix.GetLength(0) - subMatrixRows + 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - subMatrixCols + 1; col++)
                {
                    char currentChar = matrix[row + 0, col + 0];
                    bool oneIsNotEqual = true;
                    bool charIsEqual = false;

                    for (int subRow = 0; subRow < subMatrixRows; subRow++)
                    {
                        for (int subCol = 0; subCol < subMatrixCols; subCol++)
                        {
                            if (oneIsNotEqual)
                            {
                                if (matrix[row + subRow, col + subCol] == currentChar)
                                {
                                    charIsEqual = true;
                                }
                                else
                                {
                                    charIsEqual = false;
                                    oneIsNotEqual = false;
                                }
                            }
                        }
                    }

                    if (charIsEqual)
                    {
                        equalPairsCount++;
                    }
                }
            }

            return equalPairsCount;
        }
    }
}
