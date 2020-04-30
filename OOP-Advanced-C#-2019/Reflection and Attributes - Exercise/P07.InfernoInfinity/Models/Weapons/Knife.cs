namespace P07.InfernoInfinity.Models.Weapons
{
    using Enumerations;

    public class Knife : Weapon
    {
        private const int NumberOfSocketHole = 3;
        private const int InitialMinDamage = 3;
        private const int InitialMaxDamage = 4;

        public Knife(Rarity rarity, string name) 
            : base(rarity, name, InitialMinDamage, InitialMaxDamage, NumberOfSocketHole)
        {
        }
    }
}
