namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Car
    {
        private int kilometersTravelled;

        public Car(string model, double fuelAmount, double fuelConsumptionPerKm)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        public int KilometersTravelled
        {
            get { return this.kilometersTravelled; }
            set { this.kilometersTravelled = value; }
        }

        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKm { get; set; }

        public void Drive(int kilometersToDrive)
        {
            if (this.EnoughFuelForDrive(kilometersToDrive))
            {
                this.KilometersTravelled += kilometersToDrive;
                this.FuelAmount -= kilometersToDrive * this.FuelConsumptionPerKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:F2} {this.KilometersTravelled}";
        }

        private bool EnoughFuelForDrive(int kilometersToDrive)
        {
            return this.FuelAmount >= (kilometersToDrive * this.FuelConsumptionPerKm);
        }

    }
}