using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimension = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = dimension[0];
            var cols = dimension[1];

            var matrix = new char[rows, cols];

            var snakeString = Console.ReadLine();

            var snakeQueue = new Queue<char>(snakeString);
            var colStack = new Stack<int>();
          
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    var startCol = 0;
                    colStack.Push(startCol);
                    while (colStack.Count <= matrix.GetLength(1))
                    {
                        var col = colStack.Peek();

                        var currentChar = snakeQueue.Dequeue();
                        matrix[row, col] = currentChar;
                        snakeQueue.Enqueue(currentChar);
                        if (colStack.Count == matrix.GetLength(1))
                        {
                            break;
                        }

                        colStack.Push(++col);
                    }
                }
                else
                {
                    while (colStack.Count > 0)
                    {
                        var col = colStack.Peek();

                        var currentChar = snakeQueue.Dequeue();
                        matrix[row, col] = currentChar;
                        snakeQueue.Enqueue(currentChar);

                        colStack.Pop();
                    }
                }
            }


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }

                Console.WriteLine();
            }
        }
    }
}
