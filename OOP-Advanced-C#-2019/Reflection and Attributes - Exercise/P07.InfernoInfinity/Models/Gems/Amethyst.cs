namespace P07.InfernoInfinity.Models.Gems
{
    using Enumerations;

    public class Amethyst  : Gem
    {
        private const int DefaultStrength = 2;
        private const int DefaultAgility = 8;
        private const int DefaultVitality = 4;

        public Amethyst(Clarity clarity, string type)
            : base(clarity, type, DefaultStrength, DefaultAgility, DefaultVitality)
        {
        }
    }
}

