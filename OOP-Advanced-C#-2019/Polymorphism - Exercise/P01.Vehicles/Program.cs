using P01.Vehicles.Models;
using System;
using System.Collections.Generic;

namespace P01.Vehicles
{
    public class Program
    {
        public static void Main()
        {
            var carInfo = Console.ReadLine().Split();
            var fuelQuantity = double.Parse(carInfo[1]);
            var consumption = double.Parse(carInfo[2]);
            var tankCapacity = double.Parse(carInfo[3]);

            Car car = new Car(fuelQuantity, consumption, tankCapacity);

            var truckInfo = Console.ReadLine().Split();
            fuelQuantity = double.Parse(truckInfo[1]);
            consumption = double.Parse(truckInfo[2]);
            tankCapacity = double.Parse(truckInfo[3]);

            Truck truck = new Truck(fuelQuantity, consumption, tankCapacity);

            var busInfo = Console.ReadLine().Split();
            fuelQuantity = double.Parse(busInfo[1]);
            consumption = double.Parse(busInfo[2]);
            tankCapacity = double.Parse(busInfo[3]);

            Bus bus = new Bus(fuelQuantity, consumption, tankCapacity);

            var numberOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInputs; i++)
            {
                var input = Console.ReadLine().Split();
                var command = input[0];
                var vehicle = input[1];


                if (command == "Drive")
                {
                    var kmToDrive = double.Parse(input[2]);

                    if (vehicle == "Car")
                    {
                        Console.WriteLine(car.Drive(kmToDrive)); ;
                    }
                    else if (vehicle == "Truck")
                    {
                        Console.WriteLine(truck.Drive(kmToDrive)); ;
                    }
                    else
                    {
                        Console.WriteLine(bus.Drive(kmToDrive));
                    }
                }
                else if (command == "DriveEmpty" && vehicle == "Bus")
                {
                    var kmToDrive = double.Parse(input[2]);
                    Console.WriteLine(bus.DriveEmpty(kmToDrive));
                }
                else if (command == "Refuel")
                {
                    var fuelAmount = double.Parse(input[2]);

                    try
                    {
                        if (vehicle == "Car")
                        {
                            car.Refuel(fuelAmount);
                        }
                        else if (vehicle == "Truck")
                        {
                            truck.Refuel(fuelAmount);
                        }
                        else
                        {
                            bus.Refuel(fuelAmount);
                        }
                    }
                    catch (ArgumentException ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
