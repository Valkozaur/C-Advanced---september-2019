﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] minerField = new char[size, size];

            string[] movesInput = Console.ReadLine()
                .Split(" ");
            Queue<string> minerMoves = new Queue<string>(movesInput);
            Dictionary<string, List<int>> moves = new Dictionary<string, List<int>>();
            MovesCoordinates(moves); 

            int minerRow = 0;
            int minerCol = 0;
            int coalsTotalCount = 0;
            MinerFieldWrite(minerField, ref minerRow, ref minerCol,ref coalsTotalCount);

            int coalCounter = 0;
            
            while(minerMoves.Count != 0)
            {
                string nextMove = minerMoves.Dequeue();

                int moveRow = 0; 
                int moveCol = 0; 
                switch (nextMove)
                {
                    case "left":
                        moveRow = moves["left"][0];
                        moveCol = moves["left"][1];
                        if (StaysInTheField(minerField, minerRow + moveRow, minerCol + moveCol))
                        {
                            minerField[minerRow, minerCol] = '*';
                            minerRow = minerRow + moveRow;
                            minerCol = minerCol + moveCol;

                            if (minerField[minerRow, minerCol] == 'c')
                            {
                                coalCounter++;
                            }
                            else if(minerField[minerRow, minerCol] == 'e')
                            {
                                Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                                return;
                            }

                            minerField[minerRow, minerCol] = 'm';
                        }
                        break;

                    case "right":
                        moveRow = moves["right"][0];
                        moveCol = moves["right"][1];
                        if (StaysInTheField(minerField, minerRow + moveRow, minerCol + moveCol))
                        {
                            minerField[minerRow, minerCol] = '*';
                            minerRow = minerRow + moveRow;
                            minerCol = minerCol + moveCol;

                            if (minerField[minerRow, minerCol] == 'c')
                            {
                                coalCounter++;
                            }
                            else if (minerField[minerRow, minerCol] == 'e')
                            {
                                Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                                return;
                            }

                            minerField[minerRow, minerCol] = 'm';
                        }
                        break;

                    case "up":
                        moveRow = moves["up"][0];
                        moveCol = moves["up"][1];
                        if (StaysInTheField(minerField, minerRow + moveRow, minerCol + moveCol))
                        {
                            minerField[minerRow, minerCol] = '*';
                            minerRow = minerRow + moveRow;
                            minerCol = minerCol + moveCol;

                            if (minerField[minerRow, minerCol] == 'c')
                            {
                                coalCounter++;
                            }
                            else if (minerField[minerRow, minerCol] == 'e')
                            {
                                Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                                return;
                            }

                            minerField[minerRow, minerCol] = 'm';
                        }
                        break;

                    case "down":
                        moveRow = moves["down"][0];
                        moveCol = moves["down"][1];
                        if (StaysInTheField(minerField, minerRow + moveRow, minerCol + moveCol))
                        {
                            minerField[minerRow, minerCol] = '*';
                            minerRow = minerRow + moveRow;
                            minerCol = minerCol + moveCol;

                            if (minerField[minerRow, minerCol] == 'c')
                            {
                                coalCounter++;
                            }
                            else if (minerField[minerRow, minerCol] == 'e')
                            {
                                Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                                return;
                            }

                            minerField[minerRow, minerCol] = 'm';
                        }
                        break;
                }

                if (coalCounter == coalsTotalCount)
                {
                    Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                    return;
                }
            }

            Console.WriteLine($"{coalsTotalCount - coalCounter} coals left. ({minerRow}, {minerCol})");
        }
        private static bool StaysInTheField(char[,] minerField, int row, int col)
        {
            return 0 <= row && row < minerField.GetLength(0)
                && 0 <= col && col < minerField.GetLength(1);
        }

        private static void MovesCoordinates(Dictionary<string, List<int>> moves)
        {
            moves.Add("left", new List<int>());
            moves["left"].Add(0);
            moves["left"].Add(-1);

            moves.Add("right", new List<int>());
            moves["right"].Add(0);
            moves["right"].Add(1);

            moves.Add("up", new List<int>());
            moves["up"].Add(-1);
            moves["up"].Add(0);

            moves.Add("down", new List<int>());
            moves["down"].Add(1);
            moves["down"].Add(0);
        }

        private static void MinerFieldWrite(char[,] minerField, ref int minerStartRow, ref int minerStartCol,ref int coalsCount)
        {
            coalsCount = 0;
            for (int row = 0; row < minerField.GetLength(0); row++)
            {
                char[] rowInput = Console.ReadLine()
                    .Split(" ")
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < minerField.GetLength(1); col++)
                {
                    minerField[row, col] = rowInput[col];
                    if (rowInput[col] == 's')
                    {
                        minerStartRow = row;
                        minerStartCol = col;
                    }
                    else if(rowInput[col] == 'c')
                    {
                        coalsCount++;
                    }
                }
            }
        }

    }
}
