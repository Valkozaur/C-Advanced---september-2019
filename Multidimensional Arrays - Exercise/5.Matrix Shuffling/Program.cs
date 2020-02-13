using System;
using System.Linq;

namespace Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var matrix = new string[dimensions[0], dimensions[1]];
            MatrixWrite(matrix);

            while (true)
            {
                var tokens = Console.ReadLine()
                    .Split();

                var command = tokens[0];
                if (command == "END")
                {
                    break;
                }
                else if(command == "swap")
                {

                    var maxtrixRows = matrix.GetLength(0);
                    var matrixCols = matrix.GetLength(1);

                    var firstRow = int.Parse(tokens[1]);
                    var firstCol = int.Parse(tokens[2]);
                    var secondRow = int.Parse(tokens[3]);
                    var secondCol = int.Parse(tokens[4]);

                    var firstAreValid = 0 <= firstRow && firstRow < maxtrixRows && 0 <= firstCol && firstCol < matrixCols;
                    var secondAreValid = 0 <= secondRow && secondRow < maxtrixRows && 0 <= secondCol && secondCol < matrixCols;

                    if (firstAreValid && secondAreValid)
                    {
                        var temp = "";
                        temp = matrix[firstRow, firstCol];
                        matrix[firstRow, firstCol] = matrix[secondRow, secondCol];
                        matrix[secondRow, secondCol] = temp;

                        MatrixPrint(matrix);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
            }
        }

        static void MatrixWrite(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var inputRows = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputRows[col];
                }
            }
        }

        static void MatrixPrint(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
