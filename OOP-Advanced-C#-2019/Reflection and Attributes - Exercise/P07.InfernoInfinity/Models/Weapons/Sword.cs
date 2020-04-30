namespace P07.InfernoInfinity.Models.Weapons
{
    using Enumerations;

    public class Sword : Weapon
    {

        private const int NumberOfSocketHole = 4;
        private const int InitialMinDamage = 4;
        private const int InitialMaxDamage = 6;

        public Sword(Rarity rarity, string name)
            : base(rarity, name, InitialMinDamage, InitialMaxDamage, NumberOfSocketHole)
        {
        }
    }
}
