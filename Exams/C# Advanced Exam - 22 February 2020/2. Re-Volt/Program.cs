namespace _2._Re_Volt
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var sizeOfMatrix = int.Parse(Console.ReadLine());
            var countOfCommands = int.Parse(Console.ReadLine());

            var matrixField = new char[sizeOfMatrix, sizeOfMatrix];
            var playerCoordinates = MatrixInput(matrixField, sizeOfMatrix);
            matrixField[playerCoordinates["row"], playerCoordinates["col"]] = '-';

            for (int i = 0; i < countOfCommands; i++)
            {
                var command = Console.ReadLine();

                var caller = command;

                Move(playerCoordinates, matrixField, caller);
            }

            matrixField[playerCoordinates["row"], playerCoordinates["col"]] = 'f';
            Console.WriteLine("Player lost!");
            Print(matrixField);
        }

        private static void Move(Dictionary<string, int> playerCoordinates, char[,] matrixField, string caller)
        {
            var moveRow = 0;
            var moveCol = 0;
            switch (caller)
            {
                case "up":
                    moveRow = -1;
                    moveCol = 0;
                    break;
                case "down":
                    moveRow = 1;
                    moveCol = 0;
                    break;
                case "left":
                    moveRow = 0;
                    moveCol = -1;
                    break;
                case "right":
                    moveRow = 0;
                    moveCol = 1;
                    break;
            }

            if (caller == "up" || caller == "down")
            {
                if (0 <= playerCoordinates["row"] + moveRow && playerCoordinates["row"] + moveRow < matrixField.GetLength(0))
                {
                    playerCoordinates["row"] = playerCoordinates["row"] + moveRow;
                }
                else
                {
                    if (0 > playerCoordinates["row"] + moveRow)
                    {
                        playerCoordinates["row"] = matrixField.GetLength(0) - 1;
                    }
                    else
                    {
                        playerCoordinates["row"] = 0;
                    }
                }
            }

            if (caller == "left" || caller == "right")
            {
                if (0 <= playerCoordinates["col"] + moveCol && playerCoordinates["col"] + moveCol < matrixField.GetLength(1))
                {
                    playerCoordinates["col"] = playerCoordinates["col"] + moveCol;
                }
                else
                {
                    if (0 > playerCoordinates["col"] + moveCol)
                    {
                        playerCoordinates["col"] = matrixField.GetLength(1) - 1;
                    }
                    else
                    {
                        playerCoordinates["col"] = 0;
                    }
                }
            }

            SpecialFields(playerCoordinates, matrixField, caller);
        }

        private static void SpecialFields(Dictionary<string, int> playerCoordinates, char[,] matrixField, string caller)
        {
            var currentField = matrixField[playerCoordinates["row"], playerCoordinates["col"]];
            if (currentField == 'B')
            {
                Move(playerCoordinates, matrixField, caller);
            }
            else if (currentField == 'T')
            {
                switch (caller)
                {
                    case "up":
                        Move(playerCoordinates, matrixField, "down");
                        break;
                    case "down":
                        Move(playerCoordinates, matrixField, "up");
                        break;
                    case "left":
                        Move(playerCoordinates, matrixField, "right");
                        break;
                    case "right":
                        Move(playerCoordinates, matrixField, "left");
                        break;
                }
            }
            else if (currentField == 'F')
            {
                matrixField[playerCoordinates["row"], playerCoordinates["col"]] = 'f';
                Console.WriteLine("Player won!");
                Print(matrixField);
                Environment.Exit(0);
            }
        }

        private static Dictionary<string, int> MatrixInput(char[,] matrixField, int sizeOfMatrix)
        {
            var playersCoordinates = new Dictionary<string, int>();
            for (int row = 0; row < sizeOfMatrix; row++)
            {
                var splitInput = Console.ReadLine();

                for (int col = 0; col < sizeOfMatrix; col++)
                {
                    var currentElement = splitInput[col];
                    if (currentElement == 'f')
                    {
                        playersCoordinates.Add("row", row);
                        playersCoordinates.Add("col", col);
                    }

                    matrixField[row, col] = currentElement;
                }
            }

            return playersCoordinates;
        }

        private static void Print(char[,] matrixField)
        {
            for (int row = 0; row < matrixField.GetLength(0); row++)
            {
                for (int col = 0; col < matrixField.GetLength(1); col++)
                {
                    var currentElemement = matrixField[row, col];
                    Console.Write(currentElemement);
                }

                Console.WriteLine();
            }
        }
    }
}
