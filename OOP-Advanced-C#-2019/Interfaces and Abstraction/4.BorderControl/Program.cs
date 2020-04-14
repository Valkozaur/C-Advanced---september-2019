namespace _4.BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    public class Program
    {
        public static void Main()
        {
            var buyers = new List<Buyer>();

            var numbersOfInput = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbersOfInput; i++)
            {
                var buyerInfo = Console.ReadLine()
                    .Split();

                if (buyerInfo.Length == 4)
                {
                    var name = buyerInfo[0];
                    var age = int.Parse(buyerInfo[1]);
                    var id = buyerInfo[2];
                    var birthDate = buyerInfo[3];

                    buyers.Add(new Human(name, age, id, birthDate)); 
                }
                else
                {
                    var name = buyerInfo[0];
                    var age = int.Parse(buyerInfo[1]);
                    var group = buyerInfo[2];

                    buyers.Add(new Rebel(name, age, group));
                }
            }

            while (true)
            {
                var inputName = Console.ReadLine();
                if (inputName == "End")
                {
                    break;
                }

                var buyer = buyers.FirstOrDefault(x => x.Name == inputName);
                if (buyer != default)
                {
                    buyer.BuyFood();
                }
            }

            var totalFoodBought = buyers.Sum(x => x.Food);
            Console.WriteLine(totalFoodBought);
        }
    }
}
