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
                var firstLineInput = Console.ReadLine()
                    .ToLower();

                if (firstLineInput == "beast!")
                {
                    break;
                }

                var animalAttributes = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    var name = animalAttributes[0];

                    var ageIsValid = int.TryParse(animalAttributes[1], out int age);
                    if (!ageIsValid)
                    {
                        throw new ArgumentException("Invalid input!");
                    }

                    var gender = animalAttributes[2];

                    if (firstLineInput == "cat")
                    {
                        animals.Add(new Cat(name, age, gender));
                    }
                    else if (firstLineInput == "dog")
                    {
                        animals.Add(new Dog(name,age,gender));
                    }
                    else if (firstLineInput == "frog")
                    {     
                        animals.Add(new Frog(name,age,gender));
                    }
                    else if (firstLineInput == "kitten")    
                    {
                        animals.Add(new Kitten(name,age));
                    }
                    else if (firstLineInput == "tomcat")
                    {
                        animals.Add(new Tomcat(name,age));
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
