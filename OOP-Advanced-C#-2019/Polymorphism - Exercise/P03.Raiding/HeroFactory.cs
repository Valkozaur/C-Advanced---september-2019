using P03.Raiding.Models;
using P03.Raiding.Models.Heroes;

namespace P03.Raiding
{
    public class HeroFactory
    {
        public Hero CreateHero(params string[] heroArgs)
        {
            Hero currentHero = null;
            var heroType = heroArgs[0];
            var heroName = heroArgs[1];

            if (heroType == nameof(Druid))
            {
                currentHero = new Druid(heroName);
            }
            else if (heroType == nameof(Paladin))
            {
                currentHero = new Paladin(heroName);
            }
            else if (heroType == nameof(Rogue))
            {
                currentHero = new Rogue(heroName);
            }
            else if (heroType == nameof(Warrior))
            {
                currentHero = new Warrior(heroName);
            }

            return currentHero;
        }
    }
}
