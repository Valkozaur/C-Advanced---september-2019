using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowInput = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split();

                if (command[0] == "END")
                {
                    break;
                }

                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int num = int.Parse(command[3]);

                bool rowIsValid = 0 <= row && row < matrix.GetLength(0);
                bool colIsValid = 0 <= col && col < matrix.GetLength(1);

                if (rowIsValid && colIsValid)
                {
                    if (command[0] == "Add")
                    {
                        matrix[row, col] += num;
                    }
                    else if (command[0] == "Subtract")
                    {
                        matrix[row, col] -= num;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
            }

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
