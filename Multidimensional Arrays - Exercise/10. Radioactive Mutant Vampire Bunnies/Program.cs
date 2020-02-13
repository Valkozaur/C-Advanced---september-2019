using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static char[,] bunnyLair;
        static int playerRow;
        static int playerCol;
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();


            int rows = dimensions[0];
            int cols = dimensions[1];
            bunnyLair = new char[rows, cols];
            bunnyLairWrite();

            char[] movesInput = Console.ReadLine()
                .ToCharArray();

            for (int move = 0; move < movesInput.Length; move++)
            {
                char currentMove = movesInput[move];

                switch (currentMove)
                {
                    case 'L':
                        Move(0, -1);
                        break;
                    case 'R':
                        Move(0, 1);
                        break;
                    case 'U':
                        Move(-1, 0);
                        break;
                    case 'D':
                        Move(1, 0);
                        break;
                }
            }
        }
        static void Write()
        {
            for (int row = 0; row < bunnyLair.GetLength(0); row++)
            {
                for (int col = 0; col < bunnyLair.GetLength(1); col++)
                {
                    Console.Write(bunnyLair[row, col]);
                }
                Console.WriteLine();
            }
        }
        static void Spread()
        {
            List<int> bunniesIndexes = new List<int>();

            for (int row = 0; row < bunnyLair.GetLength(0); row++)
            {
                for (int col = 0; col < bunnyLair.GetLength(1); col++)
                {
                    if (bunnyLair[row, col] == 'B')
                    {
                        bunniesIndexes.Add(row);
                        bunniesIndexes.Add(col);
                    }
                }
            }

            for (int i = 0; i < bunniesIndexes.Count; i += 2)
            {
                int bunnyRow = bunniesIndexes[i];
                int bunnyCol = bunniesIndexes[i + 1];

                if (IndexIsValid(bunnyRow + -1, bunnyCol + 0))
                {
                    bunnyLair[bunnyRow + -1, bunnyCol + 0] = 'B';
                }

                if (IndexIsValid(bunnyRow + 1, bunnyCol + 0))
                {
                    bunnyLair[bunnyRow + 1, bunnyCol + 0] = 'B';
                }

                if (IndexIsValid(bunnyRow + 0, bunnyCol + -1))
                {
                    bunnyLair[bunnyRow + 0, bunnyCol - 1] = 'B';
                }

                if (IndexIsValid(bunnyRow + 0, bunnyCol + 1))
                {
                    bunnyLair[bunnyRow + 0, bunnyCol + 1] = 'B';
                }
            }
        }

        private static void Move(int row, int col)
        {
            if (!IndexIsValid(playerRow + row, playerCol + col))
            {
                Write();
                Console.WriteLine($"won: {playerRow} {playerCol}");
                Environment.Exit(0);
            }

            bunnyLair[playerRow, playerCol] = '.';
            playerRow += row;
            playerCol += col;

            Spread();

            if (bunnyLair[playerRow, playerCol] == 'B')
            {
                Write();
                Console.WriteLine($"dead: {playerRow} {playerCol}");
                Environment.Exit(0);
            }
        }

        private static bool IndexIsValid(int row, int col)
        {
            return 0 <= row && row < bunnyLair.GetLength(0)
                && 0 <= col && col < bunnyLair.GetLength(1);
        }

        private static void bunnyLairWrite()
        {
            for (int row = 0; row < bunnyLair.GetLength(0); row++)
            {
                char[] rowInput = Console.ReadLine()
                    .ToCharArray();

                for (int col = 0; col < bunnyLair.GetLength(1); col++)
                {
                    bunnyLair[row, col] = rowInput[col];

                    if (bunnyLair[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
        }
    }
}
