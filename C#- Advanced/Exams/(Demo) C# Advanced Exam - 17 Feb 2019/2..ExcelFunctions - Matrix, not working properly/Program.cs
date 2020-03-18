using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._._ExcelFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            var countOfInputs = int.Parse(Console.ReadLine());
            var headers = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

            var tableMatrix = new string[countOfInputs - 1, headers.Count];
            MatrixInput(tableMatrix);

            var splitInput = Console.ReadLine()
                .Split(" ");

            var matrixResult = new string[1, 1];
            var header = splitInput[1];

            if (splitInput[0] == "hide")
            {
                matrixResult = Hide(tableMatrix, headers, header);
                PrintMatrix(matrixResult, headers);
            }
            else if (splitInput[0] == "sort")
            {
                matrixResult = Sort(tableMatrix, headers, header);
                PrintMatrix(matrixResult, headers);
            }
            else if (splitInput[0] == "filter")
            {
                var value = splitInput[2];
                var filterResult = new string[tableMatrix.GetLength(1)];
                filterResult = Filter(tableMatrix, headers, header, value);
                PrintArray(filterResult, headers);
            }
        }

        private static string[] Filter(string[,] tableMatrix, List<string> headers, string header, string value)
        {
            var result = new string[tableMatrix.GetLength(1)];
            var columnToFilter = headers.IndexOf(header);

            var rowOfFilteredElement = -1;
            for (int row = 0; row < tableMatrix.GetLength(0); row++)
            {
                var currentElement = tableMatrix[row, columnToFilter];
                if (currentElement == value)
                {
                    rowOfFilteredElement = row;
                    break;
                }
            }

            for (int col = 0; col < tableMatrix.GetLength(1); col++)
            {
                result[col] = tableMatrix[rowOfFilteredElement, col];
            }

            return result;
        }

        private static string[,] Hide(string[,] tableMatrix, List<string> headers, string headerToHide)
        {
            var matrixResult = new string[tableMatrix.GetLength(0), tableMatrix.GetLength(1)];
            var headersToHideCol = headers.IndexOf(headerToHide);
            headers.RemoveAt(headersToHideCol);

            for (int rows = 0; rows < tableMatrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < tableMatrix.GetLength(1); cols++)
                {
                    var currentElement = tableMatrix[rows, cols];

                    if (cols != headersToHideCol)
                    {
                        matrixResult[rows, cols] = currentElement;
                    }
                    else
                    {
                        matrixResult[rows, cols] = null;
                    }
                }
            }

            return matrixResult;
        }

        private static string[,] Sort(string[,] tablesMatrix, List<string> headers, string headerToSort)
        {
            var resultMatrix = new string[tablesMatrix.GetLength(0), tablesMatrix.GetLength(1)];
            int colOfHeaderToSort = headers.IndexOf(headerToSort);

            var sortedColumn = new SortedList<string, int>();
            for (int row = 0; row < tablesMatrix.GetLength(0); row++)
            {
                var elementToSort = tablesMatrix[row, colOfHeaderToSort];
                sortedColumn.Add(elementToSort, row);
            }

            var currentRow = 0;
            foreach (var (element, row) in sortedColumn)
            {
                for (int col = 0; col < tablesMatrix.GetLength(1); col++)
                {
                    resultMatrix[currentRow, col] = tablesMatrix[row, col];
                }

                currentRow++;
            }

            return resultMatrix;
        }
        private static void MatrixInput(string[,] tableMatrix)
        {
            for (int rows = 0; rows < tableMatrix.GetLength(0); rows++)
            {
                var input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                for (int cols = 0; cols < tableMatrix.GetLength(1); cols++)
                {
                    var currentWord = input[cols];
                    tableMatrix[rows, cols] = currentWord;
                }
            }
        }

        private static void PrintMatrix(string[,] tablesMatrix, List<string> headers)
        {
            Console.WriteLine(String.Join(" | ", headers));
            for (int row = 0; row < tablesMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < tablesMatrix.GetLength(1); col++)
                {
                    var currentElement = tablesMatrix[row, col];

                    if (currentElement != null)
                    {
                        Console.Write(currentElement);
                        if (col != tablesMatrix.GetLength(1) - 1)
                        {
                            Console.Write(" | ");
                        }
                    }
                }

                Console.WriteLine();
            }
        }

        private static void PrintArray(string[] filterResult, List<string> headers)
        {
            Console.WriteLine(String.Join(" | ", headers));
            Console.WriteLine(String.Join(" | ", filterResult));
        }

    }
}