namespace P03.Raiding.Models
{
    public class Warrior : Hero
    {
        public Warrior(string name) 
            : base(name)
        {
            this.Power = 100;
        }

        public override string CastAbility() => $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
    }
}
