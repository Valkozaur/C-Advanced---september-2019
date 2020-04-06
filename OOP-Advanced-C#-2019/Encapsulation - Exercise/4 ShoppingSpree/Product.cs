namespace _4_ShoppingSpree
{
    using System;

    public class Product
    {
        private string name;
        private decimal price;

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine($"{nameof(this.Name)} cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Price 
        {
            get => this.price;
            private set 
            {
                if (price < 0)
                {
                    Console.WriteLine($"{nameof(this.Price)} cannot be negative");
                }

                this.price = value;
            }
        }
    }
}
