namespace P07.InfernoInfinity.Models.Gems
{
    using Enumerations;

    public class Diamond : Gem
    {
        private const int DefaultStrength = 10;
        private const int DefaultAgility = 10;
        private const int DefaultVitality = 10;

        public Diamond(Clarity clarity, string type)
            : base(clarity, type, DefaultStrength, DefaultAgility, DefaultVitality)
        {
        }
    }
}