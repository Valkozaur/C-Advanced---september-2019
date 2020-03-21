namespace P03_JediGalaxy
{
    using System;
    using System.Linq;

    public class Program
    {
        private static int[,] matrix;

        public static void Main()
        {
            MatrixInput();
            Console.WriteLine(GalaxyFights());
        }

        public static void MatrixInput()
        {
            var dimensions = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            var rows = dimensions[0];
            var columns = dimensions[1];

            matrix = new int[rows, columns];

            var value = 0;
            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                for (var col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = value++;
                }
            }
        }

        public static int GalaxyFights()
        {
            var command = Console.ReadLine();
            var sum = 0;
            while (command != "Let the Force be with you")
            {
                var ivoS = command
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                var evil = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                var evilRow = evil[0];
                var evilCol = evil[1];
                var isEvil = true;
                Func<int, bool> func = i => i >= 0;

                Movement(evilRow, evilCol, isEvil, func);

                var ivoRow = ivoS[0];
                var ivoCol = ivoS[1];
                isEvil = false;
                func = i => i < matrix.GetLength(1);

                sum = Movement(ivoRow, ivoCol, isEvil, func);

                command = Console.ReadLine();
            }

            return sum;
        }

        public static bool RowColValidator(int row, int col) =>
            row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);

        public static int Movement(int initialRow, int initialCol, bool isEvil, Func<int, bool> func)
        {
            var sum = 0;
            while (initialRow >= 0 && func(initialCol))
            {
                if (isEvil)
                {
                    if (RowColValidator(initialRow, initialCol))
                    {
                        matrix[initialRow--, initialCol--] = 0;
                    }
                    else
                    {
                        initialRow--;
                        initialCol--;
                    }
                }
                else
                {
                    if (RowColValidator(initialRow, initialCol))
                    {
                        sum += matrix[initialRow--, initialCol++];
                    }
                    else
                    {

                        initialRow--;
                        initialCol++;
                    }
                }
            }

            return sum;
        }
    }
}
