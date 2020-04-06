namespace _4_ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var people = new List<Person>();
            var products = new List<Product>();

            var peopleInput = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);
            foreach (var currentPerson in peopleInput)
            {
                var personParameters = currentPerson
                    .Split("=");
                var personName = personParameters[0];
                var money = decimal.Parse(personParameters[1]);

                try
                {
                    var person = new Person(personName, money);
                    people.Add(person);
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                    break;
                }
            }

            var productsInput = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);
            foreach (var productInput in productsInput)
            {
                var productParameters = productInput
                    .Split("=");

                var productName = productParameters[0];
                var price = decimal.Parse(productParameters[1]);

                try
                {
                    var product = new Product(productName, price);
                    products.Add(product);
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                    break;
                }
            }

            while (true)
            {
                var commandInput = Console.ReadLine();
                if (commandInput == "END")
                {
                    break;
                }

                var splitCommand = commandInput
                    .Split(" ");

                var personName = splitCommand[0];
                var productName = splitCommand[1];

                var person = people.FirstOrDefault(n => n.Name == personName);
                var product = products.FirstOrDefault(n => n.Name == productName);
                if (person != null && product != null)
                {
                    if (person.BuyProduct(product) == false)
                    {
                        Console.WriteLine($"{personName} can't afford {productName}");
                    }
                    else
                    {
                        Console.WriteLine($"{personName} bought {productName}");
                    }
                }
            }

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
