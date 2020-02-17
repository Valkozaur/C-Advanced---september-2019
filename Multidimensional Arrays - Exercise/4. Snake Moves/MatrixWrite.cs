using System;

public class MatrixWrite
{
	public MatrixWrite()
	{
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
