namespace P03.WildFarm.Models.Animals.Birds
{
    using Models.Foods;

    public class Owl : Bird
    {
        private const double OlwWeightGain = 0.25;

        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override string ProduceSound() => "Hoot Hoot";

        protected override double WeightGainPerFoodEaten => OlwWeightGain;

        protected override void SeedDietList()
        {
            this.animalDiet.Add(new Meat());
        }
    }
}
