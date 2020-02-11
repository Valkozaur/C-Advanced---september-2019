using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            double[][] jaggedArray = new double[rows][];

            FillJaggedArray(jaggedArray);
            Analyze(jaggedArray);

            while (true)
            {
                string[] commandInfo = Console.ReadLine()
                    .Split(" ");

                string command = commandInfo[0];

                if (command == "End")
                {
                    break;
                }

                int targetRow = int.Parse(commandInfo[1]);
                int targetCol = int.Parse(commandInfo[2]);
                int value = int.Parse(commandInfo[3]);

                if (!CoordinatesAreValid(jaggedArray, targetRow, targetCol))
                {
                    continue;
                }

                if (command == "Add")
                {
                    jaggedArray[targetRow][targetCol] += value;
                }
                else if (command == "Subtract")
                {
                    jaggedArray[targetRow][targetCol] -= value;
                }
            }

            foreach (var row in jaggedArray)
            {
                Console.WriteLine(String.Join(" ", row));
            }
        }

        private static bool CoordinatesAreValid(double[][] jaggedArray, int targetRow, int targetCol)
        {
            return 0 <= targetRow && targetRow < jaggedArray.Length
                    && 0 <= targetCol && targetCol < jaggedArray[targetRow].Length; 
        }

        static void FillJaggedArray(double[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = Console.ReadLine()
                    .Split()
                    .Select(double.Parse)
                    .ToArray();
            }
        }

        static void Analyze(double[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.Length - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] *= 2;
                        jaggedArray[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] /= 2;
                    }
                    for (int col = 0; col < jaggedArray[row + 1].Length; col++)
                    {
                        jaggedArray[row + 1][col] /= 2;
                    }
                }
            }
        }
    }
}
