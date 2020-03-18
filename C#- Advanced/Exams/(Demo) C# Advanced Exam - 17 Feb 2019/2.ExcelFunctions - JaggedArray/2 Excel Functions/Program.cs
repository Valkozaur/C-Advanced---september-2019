using System;
using System.Collections.Generic;
using System.Linq;

namespace _2_Excel_Functions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var sizeOfTable = int.Parse(Console.ReadLine());
            var tableField = new string[sizeOfTable][];
            TableInput(tableField);

            var inputSplit = Console.ReadLine()
                .Split(" ");
            var command = inputSplit[0];
            var header = inputSplit[1];
            var indexOfHeader = Array.IndexOf(tableField[0], header);

            switch (command)
            {
                case "hide":
                    Hide(tableField, indexOfHeader);
                    break;
                case "sort":
                    Sort(tableField, indexOfHeader);
                    break;
                case "filter":
                    var value = inputSplit[2];
                    Filter(tableField, indexOfHeader, value);
                    break;
            }
        }

        private static void Hide(string[][] tableField, int indexOfHeader)
        {
            foreach (var row in tableField)
            {
                Console.WriteLine(String.Join(" | ", row
                    .Where((x, i) => i != indexOfHeader)
                    .ToArray()));
            }
        }

        private static void Sort(string[][] tableField, int indexOfHeader)
        {
            var headerRow = tableField[0];
            
            tableField = tableField
                .OrderBy(x => x[indexOfHeader])
                .ToArray();

            Console.WriteLine(String.Join(" | ", headerRow));
            foreach (var row in tableField)
            {
                if (row != headerRow)
                {
                    Console.WriteLine(String.Join(" | ", row));
                }
            }
        }

        private static void Filter(string[][] tableField, int indexOfHeader, string value)
        {
            var headerRow = tableField[0];
            Console.WriteLine(String.Join(" | ", headerRow));

            for (int row = 1; row < tableField.Length; row++)
            {
                if (tableField[row][indexOfHeader] == value)
                {
                    Console.WriteLine(String.Join(" | ", tableField[row]));
                }
            }
        }

        private static void TableInput(string[][] tableField)
        {
            for (int i = 0; i < tableField.Length; i++)
            {
                tableField[i] = Console.ReadLine()
                    .Split(", ");
            }
        }
    }
}
