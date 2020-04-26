namespace P03.WildFarm.Models.Animals.Mammals
{
    using Models.Foods;

    public class Mouse : Mammal
    {
        private const double MouseWeightGain = 0.10;

        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        protected override double WeightGainPerFoodEaten => MouseWeightGain;

        public override string ProduceSound() => "Squeak";

        protected override void SeedDietList()
        {
            this.animalDiet.Add(new Vegetable());
            this.animalDiet.Add(new Fruit());
        }
    }
}
