using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.PizzaCalories
{
    public class Pizza
    {
        private const string NameLenghtErrorMessage = "Pizza name should be between 1 and 15 symbols.";

        private string name;
        private Dough dough;
        private List<Toping> topings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.dough = dough;
            this.topings = new List<Toping>();
        }

        public string Name 
        {
            get => this.name;
            set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException(NameLenghtErrorMessage);
                }

                this.name = value;
            }
        }

        public int NumberOfTopings => this.topings.Count;
        public double TotalCalories => this.dough.Calories + this.topings.Select(x => x.Calories).Sum();

        public int ToppingCount => this.topings.Count;

        public void AddToping(Toping topping)
        {
            if (ToppingCount == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.topings.Add(topping);
        }
    }
}
