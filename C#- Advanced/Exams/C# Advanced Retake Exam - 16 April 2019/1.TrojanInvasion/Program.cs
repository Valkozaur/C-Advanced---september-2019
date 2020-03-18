namespace _1.TrojanInvasion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var numberOfWaves = int.Parse(Console.ReadLine());

            var spartanDefense = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            var trojansWinners = new Stack<int>();
            for (var currentWave = 1; currentWave <= numberOfWaves; currentWave++)
            {
                var newTrojanWave = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToList();

                if (currentWave % 3 == 0)
                {
                    var extraLineOfDefense = int.Parse(Console.ReadLine());
                    spartanDefense.Add(extraLineOfDefense);
                }

                var trojanWave = new Stack<int>(newTrojanWave);

                var spartanPlate = spartanDefense.First();
                while (trojanWave.Any() && spartanDefense.Any())
                {
                    var trojan = trojanWave.Pop();
                    if (trojan > spartanPlate)
                    {
                        trojan -= spartanPlate;
                        trojanWave.Push(trojan);
                        spartanDefense.RemoveAt(0);
                        if (spartanDefense.Count != 0)
                        {
                            spartanPlate = spartanDefense.First();
                        }
                    }
                    else if (trojan < spartanPlate)
                    {
                        spartanPlate -= trojan;
                        spartanDefense[0] = spartanPlate;
                    }
                    else
                    {
                        spartanDefense.RemoveAt(0);
                        if (spartanDefense.Count != 0)
                        {
                            spartanPlate = spartanDefense.First();
                        }
                    }
                }

                trojansWinners = trojanWave;

                if (!spartanDefense.Any())
                {
                    break;
                }
            }

            var trojanWon = !spartanDefense.Any();

            if (trojanWon)
            {
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine("Warriors left: " + String.Join(", ", trojansWinners));
            }
            else
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine("Plates left: " + String.Join(", ", spartanDefense));
            }
        }
    }
}