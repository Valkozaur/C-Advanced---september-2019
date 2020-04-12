using System;
using System.Collections.Generic;

namespace _5.PizzaCalories
{
    public class Dough
    {
        private const int BaseCalories = 2;
        private const string InvalidParametersMessage = "Invalid type of dough.";
        private const string InvalidGramsMessage = "Dough weight should be in the range [1..200].";

        private Dictionary<string, double> flourTypeAndCalories;
        private Dictionary<string, double> bakingTechniqueAndCalories;

        private string flourType;
        private string bakingTechnique;
        private double grams;

        public Dough(string flourType, string bakingTechnique, double grams)
        {
            this.flourTypeAndCalories = new Dictionary<string, double>();
            this.SeedFlourType();
            this.bakingTechniqueAndCalories = new Dictionary<string, double>();
            this.SeedBakingTechniques();

            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Grams = grams;
        }


        private string FlourType
        {
            get => this.flourType;
            set
            {
                if (!flourTypeAndCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(InvalidParametersMessage);
                }

                this.flourType = value;
            }
        }

        private string BakingTechnique
        {
            get => this.bakingTechnique;
            set
            {
                if (!bakingTechniqueAndCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(InvalidParametersMessage);
                }

                this.bakingTechnique = value;
            }
        }

        private double Grams
        {
            get => this.grams;
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(InvalidGramsMessage);
                }

                this.grams = value;
            }
        }

        private void SeedFlourType()
        {
            this.flourTypeAndCalories.Add("white", 1.5);
            this.flourTypeAndCalories.Add("wholegrain", 1.0);
        }

        private void SeedBakingTechniques()
        {
            this.bakingTechniqueAndCalories.Add("crispy", 0.9);
            this.bakingTechniqueAndCalories.Add("chewy", 1.1);
            this.bakingTechniqueAndCalories.Add("homemade", 1.0);
        }

        public double Calories => (BaseCalories * grams) * flourTypeAndCalories[this.FlourType.ToLower()] * bakingTechniqueAndCalories[this.BakingTechnique.ToLower()];
    }
}