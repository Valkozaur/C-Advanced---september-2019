using P07.InfernoInfinity.Enumerations;

namespace P07.InfernoInfinity.Models.Weapons
{
    public class Staff : Weapon
    {
        private const int NumberOfSocketHole = 5;
        private const int InitialMinDamage = 3;
        private const int InitialMaxDamage = 12;

        public Staff(Rarity rarity, string name)
            : base(rarity, name, InitialMinDamage, InitialMaxDamage, NumberOfSocketHole)
        {
        }
    }
}