namespace P03.Raiding.Models.Heroes
{
    public class Paladin : Hero
    {
        public Paladin(string name) 
            : base(name)
        {
            this.Power = 100;
        }

        public override string CastAbility() => $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
    }
}
