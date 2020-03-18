using System.Security.Cryptography;
using Microsoft.VisualBasic;

namespace _7._Tuple
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var firstLine = Console.ReadLine()
                .Split(" ");

            var fullName = $"{firstLine[0]} {firstLine[1]}";
            var adress = firstLine[2];
            var town = firstLine.Length == 4
                ? firstLine[3]
                : $"{firstLine[3]} {firstLine[4]}"; 

            var firstTuple = new MyTuple<string, string, string>(fullName, adress, town);
            Console.WriteLine(firstTuple);

            var secondLine = Console.ReadLine()
                .Split(" ");

            var name = secondLine[0];
            var litersOfBeers = int.Parse(secondLine[1]);
            var drunkOrNot = secondLine[2];
            var secondTuple = new MyTuple<string, int, string>(name, litersOfBeers, drunkOrNot);
            Console.WriteLine(secondTuple);

            var thirdLine = Console.ReadLine()
                .Split(" ");

            name = thirdLine[0];
            var bankAccount = double.Parse(thirdLine[1]);
            var bankName = thirdLine[2];

            var thirdTuple = new MyTuple<string, double, string>(name, bankAccount, bankName);
            Console.WriteLine(thirdTuple);
        }
    }
}
