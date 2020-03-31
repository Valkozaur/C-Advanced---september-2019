using System.Collections.Generic;
using System.Linq;
using _5.Mordor_sCruelPlan.Moods;

namespace _5.Mordor_sCruelPlan
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var foodFactory = new FoodFactory();

            var foodInput = Console.ReadLine()
                .Split()
                .Select(x => x.ToLower())
                .ToArray();
                
            var foods = new List<Food.Food>();

            foreach (var food in foodInput)
            {
                foods.Add(foodFactory.GetFood(food));
            }

            var totalHappiness = foods
                .Select(x => x == null ? -1 : x.Happines)
                .Sum();

            Console.WriteLine(totalHappiness);

            if (totalHappiness < -5)
            {
                Console.WriteLine(nameof(Angry));
            }
            else if (totalHappiness >= -5 && totalHappiness <= 0)
            {
                Console.WriteLine(nameof(Sad));
            }
            else if (totalHappiness > 0 && totalHappiness <= 15)
            {
                Console.WriteLine(nameof(Happy));
            }
            else if (totalHappiness > 15)
            {
                Console.WriteLine(nameof(JavaScript));
            }
        }
    }
}
