using P07.InfernoInfinity.Enumerations;

namespace P07.InfernoInfinity.Models.Weapons
{
    public class Axe : Weapon
    {
        private const int NumberOfSocketHole = 4;
        private const int InitialMinDamage = 5;
        private const int InitialMaxDamage = 10;

        public Axe(Rarity rarity, string name) 
            : base(rarity, name, InitialMinDamage, InitialMaxDamage, NumberOfSocketHole)
        {
        }
    }
}
