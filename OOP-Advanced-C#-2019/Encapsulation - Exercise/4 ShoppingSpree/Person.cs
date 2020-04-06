using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4_ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
        }


        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get => this.money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Money cannot be negative");
                }

                this.money = value;
            }
        }

        public bool BuyProduct(Product product)
        {
            if (Money >= product.Price)
            {
                Money -= product.Price;
                bag.Add(product);
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append($"{this.Name} - ");
            if (bag.Count != 0)
            {
                stringBuilder.Append(string.Join(", ", bag.Select(x => x.Name)));
            }
            else
            {
                stringBuilder.Append("Nothing bought");
            }

            return stringBuilder.ToString();
        }
    }
}
