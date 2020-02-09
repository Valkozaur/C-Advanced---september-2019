using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] squareMatrix = new int[size, size];

            for (int row = 0; row < squareMatrix.GetLength(0); row++)
            {
                int[] numbersInRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < squareMatrix.GetLength(1); col++)
                {
                    squareMatrix[row, col] = numbersInRow[col];
                }
            }

            int sum = 0;
            for (int row = 0; row < squareMatrix.GetLength(0); row++)
            {
                sum += squareMatrix[row, row];
            }

            Console.WriteLine(sum);
        }
    }
}
