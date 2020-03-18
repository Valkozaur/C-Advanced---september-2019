using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace _2.Helen_sAbduction
{
    public class Program
    {
        static void Main(string[] args)
        {
            var energy = int.Parse(Console.ReadLine());
            var numberOfRows = int.Parse(Console.ReadLine());
            var sparta = new char[numberOfRows][];
            var parisCoordinates = SpartaInput(sparta);

            while (true)
            {
                var splitInput = Console.ReadLine()
                    .Split(" ");

                var moveDirection = splitInput[0];
                var spawnRow = int.Parse(splitInput[1]);
                var spawnCol = int.Parse(splitInput[2]);

                sparta[spawnRow][spawnCol] = 'S'; // Spawn

                energy = ParisMove(sparta, moveDirection, energy, parisCoordinates);

                if (energy <= 0)
                {
                    break;
                }
            }

            Console.WriteLine($"Paris died at {parisCoordinates["row"]};{parisCoordinates["col"]}.");
            sparta[parisCoordinates["row"]][parisCoordinates["col"]] = 'X';
            Print(sparta);

        }

        private static  int ParisMove(char[][] sparta, string moveDirection, int energy, Dictionary<string, int> parisCoordinates)
        {
            var moveRow = 0;
            var moveCol = 0;
            switch (moveDirection)
            {
                case "up":
                    moveRow = -1;
                    break;
                case "down":
                    moveRow = 1;
                    break;
                case "left":
                    moveCol = -1;
                    break;
                case "right":
                    moveCol = 1;
                    break;
            }
                var newRowIsValid = parisCoordinates["row"] + moveRow < sparta.Length && parisCoordinates["row"] + moveRow >= 0;
                var newColIsValid = parisCoordinates["col"] + moveCol < sparta.Length && parisCoordinates["col"] + moveCol >= 0;
               
                if (newRowIsValid && newColIsValid)
                {
                    sparta[parisCoordinates["row"]][parisCoordinates["col"]] = '-';
                    energy--;
                    parisCoordinates["row"] += moveRow; 
                    parisCoordinates["col"] += moveCol;
                    energy = SpecialSymbols(sparta, parisCoordinates, energy);
                }
                else
                {
                    energy--;
                }

                return energy;
        }

        private static int SpecialSymbols(char[][] sparta, Dictionary<string, int> parisCoordinates, int energy)
        {
            if (sparta[parisCoordinates["row"]][parisCoordinates["col"]] == 'S')
            {
                energy -= 2;
                if (energy <= 0)
                {
                    sparta[parisCoordinates["row"]][parisCoordinates["col"]] = 'X';
                    Console.WriteLine($"Paris died at {parisCoordinates["row"]};{parisCoordinates["col"]}.");
                    Print(sparta);
                    Environment.Exit(0);
                }
                else
                {
                    sparta[parisCoordinates["row"]][parisCoordinates["col"]] = 'P';
                }
            }
            else if (sparta[parisCoordinates["row"]][parisCoordinates["col"]] == 'H')
            {
                sparta[parisCoordinates["row"]][parisCoordinates["col"]] = '-';
                Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");
                Print(sparta);
                Environment.Exit(0);
            }

            return energy;
        }

        private static Dictionary<string,int>  SpartaInput(char[][] sparta)
        {
            var parisCoordinates = new Dictionary<string,int>();
            for (var row = 0; row < sparta.Length; row++)
            {
                sparta[row] = Console.ReadLine()
                    .ToCharArray();

                var containsIndex = Array.IndexOf(sparta[row], 'P');
                if (containsIndex != -1)
                {
                    parisCoordinates["row"] = row;
                    parisCoordinates["col"] = Array.IndexOf(sparta[row], 'P');
                }
            }

            return parisCoordinates;
        }

        private static void Print(char[][] sparta)
        {
            for (int row = 0; row < sparta.Length; row++)
            {
                Console.WriteLine(String.Join("", sparta[row]));
            }
        }
    }
}
