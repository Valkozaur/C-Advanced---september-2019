using System;

namespace P01.Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;

        public Vehicle(double fuelQuantity, double consumptionPerKm, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.ConsumptionPerKm = consumptionPerKm;
            this.FuelQuantity = fuelQuantity;
            
        }

        public double FuelQuantity 
        {
            get => this.fuelQuantity;
            protected set
            {
                if (fuelQuantity > this.TankCapacity)
                {
                    this.FuelQuantity = 0;
                }

                this.fuelQuantity = value;
            }
        }

        public virtual double ConsumptionPerKm { get; protected set; }

        public double TankCapacity { get; protected set; }

        public virtual string Drive(double km)
        {
            var vehicleName = this.GetType().Name;
            var neededFuel = this.ConsumptionPerKm * km;

            if (this.FuelQuantity < neededFuel)
            {
                return $"{vehicleName} needs refueling";
            }

            this.FuelQuantity -= neededFuel;
            return $"{vehicleName} travelled {km} km";
        }

        public virtual void Refuel(double amountRefueled)
        {
            if (amountRefueled <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (this.FuelQuantity + amountRefueled > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {amountRefueled} fuel in the tank");
            }

            this.FuelQuantity += amountRefueled;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
