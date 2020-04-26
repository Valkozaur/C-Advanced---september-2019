namespace P03.Raiding.Models.Heroes
{
    public class Druid : Hero   
    {
        public Druid(string name) : base(name)
        {
            this.Power = 80;
        }

        public override string CastAbility() => $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
    }
}
