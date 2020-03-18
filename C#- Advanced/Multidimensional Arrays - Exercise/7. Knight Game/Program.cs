using System;
using System.Collections.Generic;

namespace _7._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int side = int.Parse(Console.ReadLine());
            char[,] chessBoard = new char[side, side];
            MatrixWrite(chessBoard);

            int kilellersCount = 0;
            int killerRow = 0;
            int killerCol = 0;

            while (true)
            {

                int maxKnightAttacks = 0;
                for (int row = 0; row < chessBoard.GetLength(0); row++)
                {

                    int currentAttacks = 0;
                    for (int col = 0; col < chessBoard.GetLength(1); col++)
                    {
                        if (chessBoard[row, col] == 'K')
                        {
                            currentAttacks = FindNumberOfAttacks(chessBoard, row, col, ref killerRow, ref killerCol);
                        }

                        if (maxKnightAttacks < currentAttacks)
                        {
                            maxKnightAttacks = currentAttacks;
                            killerRow = row;
                            killerCol = col;
                        }
                    }
                }

                if (maxKnightAttacks > 0)
                {
                    chessBoard[killerRow, killerCol] = '0';
                    kilellersCount++;
                }
                else
                {
                    Console.WriteLine(kilellersCount);
                    break;
                }
            }
        }

        private static int FindNumberOfAttacks(char[,] chessBoard, int currentRow, int currentCol, ref int nextKnightRow, ref int nextKnightCol)
        {

            Dictionary<int, List<int>> coordinates = InputOfCoordinates();

            int numberOfAttacks = 0;
            foreach (var row in coordinates)
            {
                foreach (var col in row.Value)
                {
                    if (IndexIsValid(chessBoard, currentRow + row.Key, currentCol + col) && chessBoard[currentRow + row.Key, currentCol + col] == 'K')
                    {
                        numberOfAttacks++;
                    }
                }
            }

            return numberOfAttacks;
        }

        private static Dictionary<int, List<int>> InputOfCoordinates()
        {
            Dictionary<int, List<int>> coordinates = new Dictionary<int, List<int>>();

            coordinates.Add(-2, new List<int>());
            coordinates[-2].Add(-1);
            coordinates[-2].Add(1);
            coordinates.Add(-1, new List<int>());
            coordinates[-1].Add(-2);
            coordinates[-1].Add(2);
            coordinates.Add(1, new List<int>());
            coordinates[1].Add(-2);
            coordinates[1].Add(2);
            coordinates.Add(2, new List<int>());
            coordinates[2].Add(-1);
            coordinates[2].Add(1);

            return coordinates;
        }

        private static bool IndexIsValid(char[,] chessBoard, int row, int col)
        {
            return 0 <= row && row < chessBoard.GetLength(0)
                && 0 <= col && col < chessBoard.GetLength(1);
        }

        private static void MatrixWrite(char[,] chessBoard)
        {
            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                char[] inputRow = Console.ReadLine()
                    .ToCharArray();

                for (int col = 0; col < chessBoard.GetLength(1); col++)
                {
                    chessBoard[row, col] = inputRow[col];
                }
            }
        }
    }
}
