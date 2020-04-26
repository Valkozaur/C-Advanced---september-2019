using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Vehicles
{
    public class Truck : Vehicle
    {
        private const double AirConditonerUsage = 1.6;
        private const double WastedFuel = 0.05;

        public Truck(double fuelQuantity, double consumptionPerKm, double tankCapacity) 
            : base(fuelQuantity, consumptionPerKm + AirConditonerUsage, tankCapacity)
        {
        }

        public override void Refuel(double amountRefueled)
        {
            base.Refuel(amountRefueled);
            this.FuelQuantity -= amountRefueled * WastedFuel;
        }
    }
}
