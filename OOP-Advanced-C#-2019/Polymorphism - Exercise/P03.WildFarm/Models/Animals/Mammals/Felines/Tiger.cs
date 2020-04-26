namespace P03.WildFarm.Models.Animals.Mammals.Felines
{
    using Models.Foods;

    public class Tiger : Feline
    {
        private const double TigerWeightGain = 1;

        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override double WeightGainPerFoodEaten => TigerWeightGain;

        public override string ProduceSound() => "ROAR!!!";

        protected override void SeedDietList()
        {
            this.animalDiet.Add(new Meat());
        }
    }
}
