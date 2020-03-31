using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var animals = new List<Animal>();

            while (true)
            {
                var firstLineInput = Console.ReadLine();

                if (firstLineInput == "Beast!")
                {
                    break;
                }

                var animalAttributes = Console.ReadLine()
                    .Split();

                var name = animalAttributes[0];
                var age = int.Parse(animalAttributes[1]);
                var gender = animalAttributes[2];

                try
                {
                    if (firstLineInput == "Cat")
                    {
                        animals.Add(new Cat(name, age, gender));
                    }
                    else if (firstLineInput == "Dog")
                    {
                        animals.Add(new Dog(name,age,gender));
                    }
                    else if (firstLineInput == "Frog")
                    {     
                        animals.Add(new Frog(name,age,gender));
                    }
                    else if (firstLineInput == "Kitten")    
                    {
                        animals.Add(new Kitten(name,age));
                    }
                    else
                    {
                        animals.Add(new TomCat(name,age));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
                Console.WriteLine(animal.ProduceSound());
            }
        }
    }
}
