namespace P03.WildFarm.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Models.Foods;

    public abstract class Animal
    {
        protected List<Food> animalDiet;

        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.animalDiet = new List<Food>();
            this.SeedDietList();
        }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        protected virtual double WeightGainPerFoodEaten { get; }

        protected int FoodEaten { get; set; }

        public void Eat(string foodName, int foodQuantity)
        {
            var currentFood = this.animalDiet.FirstOrDefault(x => x.GetType().Name == foodName);
            if (currentFood == null)
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {foodName}!");
            }

            currentFood.Quantity = foodQuantity;
            this.FoodEaten += currentFood.Quantity;
            GainWeight(currentFood.Quantity);
        }

        public abstract string ProduceSound();

        protected void GainWeight(int foodQueantity) => this.Weight += foodQueantity * WeightGainPerFoodEaten;

        protected abstract void SeedDietList();
    }
}
