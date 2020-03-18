using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            long[,] bombField = new long[size, size];

            MatrixWrite(bombField);
            string[] bombsCoordinates = Console.ReadLine()
                .Split(" ");

            int activeCells = 0;
            long sum = 0;

            foreach (var bombCoordinate in bombsCoordinates)
            {
                string[] coordinates = bombCoordinate
                    .Split(',');
                int bombRow = int.Parse(coordinates[0]);
                int bombCol = int.Parse(coordinates[1]);
                long bombPower = bombField[bombRow, bombCol];

                bombField[bombRow, bombCol] = 0;

                Queue<int> bombRange = BombRange();

                while (bombRange.Count > 0)
                {
                    int bombRangeRow = bombRange.Dequeue();
                    int bombRangeCol = bombRange.Dequeue();
                    if (IndexIsValid(bombField, bombRow + bombRangeRow, bombCol + bombRangeCol) && bombPower > 0)
                    {
                        if (bombField[bombRow + bombRangeRow, bombCol + bombRangeCol] > 0)
                        {
                            bombField[bombRow + bombRangeRow, bombCol + bombRangeCol] -= bombPower;
                        }

                    }
                }
            }

            foreach (var num in bombField)
            {
                if (num > 0)
                {
                    activeCells++;
                    sum += num;
                }
            }


            Console.WriteLine($"Alive cells: {activeCells}"
                + Environment.NewLine + $"Sum: {sum}");

            MatrixPrint(bombField);
        }

        private static void MatrixPrint(long[,] bombField)
        {
            for (int row = 0; row < bombField.GetLength(0); row++)
            {
                for (int col = 0; col < bombField.GetLength(1); col++)
                {
                    Console.Write(bombField[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static bool IndexIsValid(long[,] bombField, int row, int col)
        {
            return 0 <= row && row < bombField.GetLength(0)
                && 0 <= col && col < bombField.GetLength(1);
        }

        static Queue<int> BombRange()
        {
            Queue<int> bombRange = new Queue<int>();
            //Row              //Col
            bombRange.Enqueue(-1); bombRange.Enqueue(-1);
            bombRange.Enqueue(-1); bombRange.Enqueue(0);
            bombRange.Enqueue(-1); bombRange.Enqueue(1);
            bombRange.Enqueue(0); bombRange.Enqueue(-1);
            bombRange.Enqueue(0); bombRange.Enqueue(1);
            bombRange.Enqueue(1); bombRange.Enqueue(-1);
            bombRange.Enqueue(1); bombRange.Enqueue(0);
            bombRange.Enqueue(1); bombRange.Enqueue(1);

            return bombRange;
        }

        private static void MatrixWrite(long[,] bombField)
        {
            for (int row = 0; row < bombField.GetLength(0); row++)
            {
                int[] rowInput = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < bombField.GetLength(1); col++)
                {
                    bombField[row, col] = rowInput[col];
                }
            }
        }
    }
}
