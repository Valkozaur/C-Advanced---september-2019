namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double CoffeeMilliliters = 50;
        private const decimal CoffeePrice = 3.50M;

        public Coffee(string name, double caffeine)
            : base(name, 0, 0)
        {
            this.Caffeine = caffeine;
        }

        public override double Milliliters
            => CoffeeMilliliters;

        public override decimal Price
            => CoffeePrice;

        public double Caffeine { get; set; }
    }
}
