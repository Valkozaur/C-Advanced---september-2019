namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var linesOfEngines = int.Parse(Console.ReadLine());
            var engines = EnginesInput(linesOfEngines);

            var linesOfCars = int.Parse(Console.ReadLine());
            var cars = CarsInput(linesOfCars, engines);

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private static List<Car> CarsInput(int linesOfCars, List<Engine> engines)
        {
            var cars = new List<Car>();
            for (int i = 0; i < linesOfCars; i++)
            {
                Car car = null;
                var carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var model = carInfo[0];
                var engine = engines.FirstOrDefault(x => x.Model == carInfo[1]);

                if (carInfo.Length == 4)
                {
                    var weight = double.Parse(carInfo[2]);
                    var color = carInfo[3];

                    car = new Car(model, engine, weight, color);
                }
                else if (carInfo.Length == 3)
                {
                    var isWeight = int.TryParse(carInfo[2], out int weight);

                    if (isWeight)
                    {
                        car = new Car(model, engine, weight);
                    }
                    else
                    {
                        var color = carInfo[2];
                        car = new Car(model, engine, color);
                    }
                }
                else if (carInfo.Length == 2)
                {
                    car = new Car(model, engine);
                }

                cars.Add(car);
            }

            return cars;
        }

        private static List<Engine> EnginesInput(int linesOfEngines)
        {
            var engines = new List<Engine>();
            for (int i = 0; i < linesOfEngines; i++)
            {
                Engine engine = null;
                var engineInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var model = engineInfo[0];
                var power = int.Parse(engineInfo[1]);

                if (engineInfo.Length == 4)
                {
                    var displacement = int.Parse(engineInfo[2]);
                    var efficiency = engineInfo[3];

                    engine = new Engine(model, power, displacement, efficiency);

                }
                else if (engineInfo.Length == 3)
                {
                    int displacement = 0;
                    var isDisplacement = int.TryParse(engineInfo[2], out displacement);
                    if (isDisplacement)
                    {
                        engine = new Engine(model, power, displacement);
                    }
                    else
                    {
                        var efficiency = engineInfo[2];
                        engine = new Engine(model, power, efficiency);
                    }
                }
                else if (engineInfo.Length == 2)
                {
                    engine = new Engine(model, power);
                }

                engines.Add(engine);
            }

            return engines;
        }
    }
}
