using P03.Raiding.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Raiding
{
    public class Program
    {
        public static void Main()
        {
            var heroFactory = new HeroFactory();
            var raidGroup = new List<Hero>();

            var numberOfRaidGroup = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfRaidGroup; i++)
            {
                var heroName = Console.ReadLine();
                var heroType = Console.ReadLine();

                var currentHero = heroFactory.CreateHero(heroType, heroName);

                if (currentHero == null)
                {
                    Console.WriteLine("Invalid hero!");
                    i--;
                    continue;
                }

                raidGroup.Add(currentHero);
            }

            if (int.TryParse(Console.ReadLine(), out int bossPower))
            {
                foreach (var hero in raidGroup)
                {
                    Console.WriteLine(hero.CastAbility());
                }

                if (raidGroup.Sum(x => x.Power) >= bossPower)
                {
                    Console.WriteLine("Victory!");
                }
                else
                {
                    Console.WriteLine("Defeat...");
                }
            }

        }
    }
}
