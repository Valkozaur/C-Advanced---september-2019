namespace SoftUniParking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Parking
    {
        private static HashSet<Car> parking;
        private int capacity;

        public Parking(int capacity)
        {
            this.Capacity = capacity;
        }

        public int Count = parking.Count();

        public int Capacity
        {
            set { this.capacity = value; }
        }

        public void AddCar(Car car)
        {
            if (parking.Contains(car))
            {
                Console.WriteLine("Car with that registration number, already exists!");
                return;
            }
            else if (parking.Count == this.capacity)
            {
                Console.WriteLine("Parking is full!");
                return;
            }
            else
            {
                parking.Add(car);
                Console.WriteLine($"Successfully added new car {car.Make} {car.RegistrationNumber}");
            }
        }

        public void RemoveCar(string registrationNumber)
        {
            var car = parking.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
            if (car == default)
            {
                Console.WriteLine("Car with that registration number, doesn't exist!");
            }
            else
            {
                Console.WriteLine($"Successfully removed {registrationNumber}");
            }
        }

        public Car GetCar(string registrationNumber)
        {
            var car = parking.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
            return car;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var registartionNumber in registrationNumbers)
            {
                parking = parking
                    .Where(x => x.RegistrationNumber != registartionNumber)
                    .ToHashSet();
            }
        }
    }
}
