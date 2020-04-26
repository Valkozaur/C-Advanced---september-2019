namespace P03.WildFarm.Models
{
    using Models.Animals.Birds;
    using Models.Animals.Mammals;
    using Models.Animals.Mammals.Felines;

    public class AnimalFactory
    {
        public Animal CreateAnimal(string input)
        {
            Animal currentAnimal = null;

            var animalInfo = input
                                .Split();
            var animalType = animalInfo[0];
            var name = animalInfo[1];
            var weight = double.Parse(animalInfo[2]);

            if (animalType == nameof(Owl) || animalType == nameof(Hen))
            {
                var wingSize = double.Parse(animalInfo[3]);
                if (animalType == nameof(Owl))
                {
                    currentAnimal = new Owl(name, weight, wingSize);
                }
                else
                {
                    currentAnimal = new Hen(name, weight, wingSize);
                }
            }
            else if (animalType == nameof(Tiger) || animalType == nameof(Cat))
            {
                var livingRegion = animalInfo[3];
                var breed = animalInfo[4];

                if (animalType == nameof(Tiger))
                {
                    currentAnimal = new Tiger(name, weight, livingRegion, breed);
                }
                else
                {
                    currentAnimal = new Cat(name, weight, livingRegion, breed);
                }
            }
            else if (animalType == nameof(Mouse) || animalType == nameof(Dog))
            {
                var livingRegion = animalInfo[3];

                if (animalType == nameof(Mouse))
                {
                    currentAnimal = new Mouse(name, weight, livingRegion);
                }
                else
                {
                    currentAnimal = new Dog(name, weight, livingRegion);
                }
            }

            return currentAnimal;
        }
    }
}
