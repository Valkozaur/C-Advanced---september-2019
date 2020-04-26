namespace P03.Raiding.Models.Heroes
{
    public class Rogue : Hero
    {
        public Rogue(string name) : base(name)
        {
            this.Power = 80;
        }

        public override string CastAbility() => $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
    }
}
