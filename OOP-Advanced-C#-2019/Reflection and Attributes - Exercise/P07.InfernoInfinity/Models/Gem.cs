namespace P07.InfernoInfinity.Models
{
    using System.Linq;

    using Contracts;
    using Attributes;
    using Enumerations;

    public class Gem : IGem
    {
        protected Gem(Clarity clarity, string type, int strength, int agility, int vitality)
        {
            this.Clarity = clarity;
            this.Type = type;
            this.Strength = strength;
            this.Agility = agility;
            this.Vitality = vitality;
            GetBonusFromClarity();
        }

        public Clarity Clarity { get; }

        public string Type { get; }

        [Moddifiable]
        public int Strength { get; set; }

        [Moddifiable]
        public int Agility { get; set; }

        [Moddifiable]
        public int Vitality { get; set; }

        private void GetBonusFromClarity()
        {
            var fields = this.GetType()
                .GetProperties()
                .Where(p => p.CustomAttributes.Any(a => a.AttributeType == typeof(ModdifiableAttribute)));

            foreach (var modifiable in fields)
            {
                modifiable.SetValue(this, (int) modifiable.GetValue(this) + (int)this.Clarity);
            }
        }
    }
}
