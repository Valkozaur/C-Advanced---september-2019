namespace P07.InfernoInfinity.Models.Gems
{
    using Enumerations;

    public class Emerald : Gem
    {
        private const int DefaultStrength = 1; 
        private const int DefaultAgility = 4;
        private const int DefaultVitality = 9;

        public Emerald(Clarity clarity, string type)
            : base(clarity, type, DefaultStrength, DefaultAgility, DefaultVitality)
        {
        }
    }
}