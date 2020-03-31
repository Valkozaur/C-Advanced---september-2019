using System.Security.Cryptography;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double CakeGrams = 250;
        private const double CakeCalories = 1000;
        private const decimal CakePrice = 5M;

        public Cake(string name) 
            : base(name, 0,0,0)
        {
        }

        public override double Grams
            => CakeGrams;


        public override double Calories
            => CakeCalories;

        public override decimal Price
            => CakePrice;
    }
}
