namespace P03.WildFarm.Models.Animals.Mammals.Felines
{
    using Models.Foods;

    public class Cat : Feline
    {
        private const double CatWeightGain = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override double WeightGainPerFoodEaten => CatWeightGain;

        public override string ProduceSound() => "Meow";

        protected override void SeedDietList()
        {
            this.animalDiet.Add(new Vegetable());
            this.animalDiet.Add(new Meat());
        }
    }
}
