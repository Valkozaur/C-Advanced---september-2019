namespace P03.WildFarm
{
    using System;
    using System.Collections.Generic;
    using WildFarm.Models;

    public class Program
    {
        public static void Main()
        {
            var animals = new List<Animal>();
            var animalFactory = new AnimalFactory();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                Animal currentAnimal = animalFactory.(input);
                animals.Add(currentAnimal);

                var foodInput = Console.ReadLine().Split();
                var foodName = foodInput[0];
                var quantity = int.Parse(foodInput[1]);

                Console.WriteLine(currentAnimal.ProduceSound());
                try
                {
                    currentAnimal.Eat(foodName, quantity);
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
