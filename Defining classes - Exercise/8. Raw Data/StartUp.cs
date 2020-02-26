namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var cars = new List<Car>();

            var numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                var carInfo = Console.ReadLine()
                    .Split(" ", 6);

                var model = carInfo[0];
                var engineSpeed = int.Parse(carInfo[1]);
                var enginePower = int.Parse(carInfo[2]);
                var cargoWeight = int.Parse(carInfo[3]);
                var cargoType = carInfo[4];
                var tiresInput = carInfo[5].Split(" ");

                var engine = new Engine(engineSpeed, enginePower);
                var cargo = new Cargo(cargoWeight, cargoType);
                var tires = new List<Tire>();

                for (int currentTire = 1; currentTire < tiresInput.Length; currentTire += 2)
                {
                    var pressure = double.Parse(tiresInput[currentTire - 1]);
                    var age = int.Parse(tiresInput[currentTire]);

                    var tire = new Tire(pressure, age);
                    tires.Add(tire);
                }

                var car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            var demandCargo = Console.ReadLine();
            var demandedCars = new List<Car>();

            if (demandCargo == "fragile")
            {
                demandedCars = cars
                    .Where(x => x.Cargo.CargoType == "fragile")
                    .Where(x => x.Tires.Any(y => y.TirePressure < 1))
                    .ToList();
            }
            else if (demandCargo == "flamable")
            {
                demandedCars = cars
                    .Where(x => x.Cargo.CargoType == "flamable")
                    .Where(x => x.Engine.EnginePower > 250)
                    .ToList();
            }

            foreach (var car in demandedCars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
