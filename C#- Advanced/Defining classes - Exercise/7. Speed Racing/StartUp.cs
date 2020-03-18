namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int numerOfCars = int.Parse(Console.ReadLine());
            HashSet<Car> cars = new HashSet<Car>();

            for (int i = 0; i < numerOfCars; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(" ");

                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsuptionPerKm = double.Parse(carInfo[2]);

                var car = new Car(model, fuelAmount, fuelConsuptionPerKm);
                cars.Add(car);
            }

            while (true)
            {
                string[] splittedInput = Console.ReadLine()
                    .Split(" ");

                if (splittedInput[0] == "End")
                {
                    break;
                }

                string model = splittedInput[1];
                int kilometersToDrive = int.Parse(splittedInput[2]);

                var carToDrive = cars.FirstOrDefault(x => x.Model == model);

                carToDrive.Drive(kilometersToDrive);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
