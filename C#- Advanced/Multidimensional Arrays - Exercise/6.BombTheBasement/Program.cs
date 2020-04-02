using System.Linq;

namespace _6.BombTheBasement
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var matrixDimensions = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            var rows = matrixDimensions[0];
            var cols = matrixDimensions[1];

            var basement = MatrixWrite(rows, cols);

            var bombParameters = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray(); ;

            var targetRow = bombParameters[0];
            var targetCol = bombParameters[1];
            var bombRadius = bombParameters[2];

            Bomb(basement, targetRow, targetCol, bombRadius);

            for (int row = 0; row < basement.Length; row++)
            {
                for (int col = 0; col < basement[row].Length; col++)
                {
                    if (basement[row][col] == 1)
                    {
                        var minus = 1;
                        while (IndexIsValid(row - minus, basement.Length) && basement[row - minus][col] == 0)
                        {
                            basement[row - minus + 1][col] = 0;
                            basement[row - minus][col] = 1;
                            minus++;
                        }
                    }
                }
            }

            PrintMatrix(basement);
        }
    

        private static void Bomb(int[][] basement, int targetRow, int targetCol, int bombRadius)
        {
            var currentBombPower = 0;
            for (var currentRow = targetRow - bombRadius; currentRow <= targetRow; currentRow++)
            {
                currentBombPower = UpperPartOfTheMatrix(basement, targetCol, currentRow, ref currentBombPower);
            }

            currentBombPower = bombRadius - 1;
            for (int currentRow = targetRow + 1; currentRow < targetRow + bombRadius; currentRow++)
            {
                LowerPartOfTheMatrix(basement, currentRow, targetCol, ref currentBombPower);
            }
        }

        private static int UpperPartOfTheMatrix(int[][] basement, int targetCol, int currentRow, ref int currentBombPower)
        {
            if (IndexIsValid(currentRow, basement.Length))
            {
                Up(basement, currentRow, targetCol, currentBombPower);
                Down(basement, currentRow, targetCol, currentBombPower);
                Left(basement, currentRow, targetCol, currentBombPower);
                Right(basement, currentRow, targetCol, currentBombPower);
                basement[currentRow][targetCol] = 1;

                currentBombPower++;
            }
            else
            {
                basement[currentRow][targetCol] = 1;
            }

            return currentBombPower;
        }
        private static void LowerPartOfTheMatrix(int[][] basement, int currentRow, int targetCol,
            ref int currentBombPower)
        {
            if (IndexIsValid(currentRow, basement.Length) && currentBombPower != 0)
            {
                Up(basement, currentRow, targetCol, currentBombPower);
                Down(basement, currentRow, targetCol, currentBombPower);
                Left(basement, currentRow, targetCol, currentBombPower);
                Right(basement, currentRow, targetCol, currentBombPower);
                basement[currentRow][targetCol] = 1;
                currentBombPower--;
            }
            else
            {
                basement[currentRow][targetCol] = 1;
            }
        }



        private static void Up(int[][] basement, int currentRow, int currentCol, int currentBombPower)
        {
            for (var rowToBombard = 1; rowToBombard <= currentBombPower; rowToBombard++)
            {
                if (IndexIsValid(currentRow - rowToBombard, basement.Length))
                {
                    basement[currentRow - rowToBombard][currentCol] = 1;
                }
            }
        }

        private static void Down(int[][] basement, int currentRow, int currentCol, int currentBombPower)
        {
            for (var rowToBombard = 1; rowToBombard <= currentBombPower; rowToBombard++)
            {
                if (IndexIsValid(currentRow + rowToBombard, basement.Length))
                {
                    basement[currentRow + rowToBombard][currentCol] = 1;
                }
            }
        }

        private static void Left(int[][] basement, int currentRow, int targetCol, int currentBombPower)
        {
            for (var colToBombard = 1; colToBombard <= currentBombPower; colToBombard++)
            {
                if (IndexIsValid(targetCol - colToBombard, basement[currentRow].Length))
                {
                    basement[currentRow][targetCol - colToBombard] = 1;
                }
            }
        }

        private static void Right(int[][] basement, int currentRow, int targetCol, int currentBombPower)
        {
            for (var colToBombard = 1; colToBombard <= currentBombPower; colToBombard++)
            {
                if (IndexIsValid(targetCol + colToBombard, basement[currentRow].Length))
                {
                    basement[currentRow][targetCol + colToBombard] = 1;
                }
            }
        }

        public static int[][] MatrixWrite(int rows, int cols)
        {
            var matrix = new int[rows][];

            for (var i = 0; i < rows; i++)
            {
                matrix[i] = new int[cols];
            }

            return matrix;
        }

        public static void PrintMatrix(int[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        public static bool IndexIsValid(int bombardingBox, int arrayLength)
        {
            return bombardingBox >= 0 && bombardingBox < arrayLength;
        }
    }
}
