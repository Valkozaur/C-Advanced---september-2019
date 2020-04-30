namespace P07.InfernoInfinity.Models.Gems
{
    using Enumerations;
    
    public class Ruby : Gem
    {
        private const int DefaultStrength = 7;
        private const int DefaultAgility = 2;
        private const int DefaultVitality = 5;

        public Ruby(Clarity clarity, string type) 
            : base(clarity, type, DefaultStrength, DefaultAgility, DefaultVitality)
        {
        }
    }
}
