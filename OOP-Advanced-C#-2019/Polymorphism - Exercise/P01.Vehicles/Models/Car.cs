using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Vehicles
{
    public class Car : Vehicle
    {
        private const double AirConditionerUsage = 0.9;

        public Car(double fuelQuantity, double consumptionPerKm, double tankCapacity) 
            : base(fuelQuantity, consumptionPerKm + AirConditionerUsage, tankCapacity)
        {
        }
    }
}
