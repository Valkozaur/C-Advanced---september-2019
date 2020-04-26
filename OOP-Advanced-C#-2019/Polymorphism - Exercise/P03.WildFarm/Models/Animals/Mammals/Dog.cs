namespace P03.WildFarm.Models.Animals.Mammals
{
    using Models.Foods;

    public class Dog : Mammal
    {
        private const double DogWeightGain = 0.40;

        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        protected override double WeightGainPerFoodEaten => DogWeightGain;

        public override string ProduceSound() => "Woof!";

        protected override void SeedDietList()
        {
            this.animalDiet.Add(new Meat());
        }

    }
}
