namespace P03.WildFarm.Models.Animals.Birds
{
    using Models.Foods;

    public class Hen : Bird
    {
        private const double HenWeightGain = 0.35;

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override string ProduceSound() => "Cluck";

        protected override double WeightGainPerFoodEaten => HenWeightGain;

        protected override void SeedDietList()
        {
            this.animalDiet.Add(new Vegetable());
            this.animalDiet.Add(new Fruit());
            this.animalDiet.Add(new Meat());
            this.animalDiet.Add(new Seeds());
        }
    }
}
