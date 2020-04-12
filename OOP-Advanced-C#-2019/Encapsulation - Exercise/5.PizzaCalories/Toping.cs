using System;
using System.Collections.Generic;

namespace _5.PizzaCalories
{
    public class Toping
    {
        private const double BaseCalories = 2;
        private const string InvalidTopingMessage = "Cannot place {0} on top of your pizza.";
        private const string InvalidWeightMessage = "{0} weight should be in the range[1..50].";

        private Dictionary<string, double> topingsAndCalories;

        private string currentToping;
        private double grams;

        public Toping(string toping, double grams)
        {
            this.topingsAndCalories = new Dictionary<string, double>();
            this.SeedTopings();

            this.CurrentToping = toping;
            this.Grams = grams;
        }

        private string CurrentToping
        {
            get => this.currentToping;
            set
            {
                if (!topingsAndCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(string.Format(InvalidTopingMessage, value));
                }

                this.currentToping = value;
            }
        }

        private double Grams
        {
            get => this.grams;
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException(string.Format(InvalidWeightMessage, this.CurrentToping));
                }

                this.grams = value;
            }
        }

        private void SeedTopings()
        {
            this.topingsAndCalories.Add("meat", 1.2);
            this.topingsAndCalories.Add("veggies", 0.8);
            this.topingsAndCalories.Add("cheese", 1.1);
            this.topingsAndCalories.Add("sauce", 0.9);
        }

        public double Calories => (BaseCalories * Grams) * topingsAndCalories[CurrentToping.ToLower()];

    }
}