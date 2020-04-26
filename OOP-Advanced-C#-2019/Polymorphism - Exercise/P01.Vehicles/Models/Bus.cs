namespace P01.Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double AirConditionerConsumption = 1.4;

        public Bus(double fuelQuantity, double consumptionPerKm, double tankCapacity) 
            : base(fuelQuantity, consumptionPerKm + AirConditionerConsumption, tankCapacity)
        {
        }

        public string DriveEmpty(double km)
        {
            var vehicleName = this.GetType().Name;
            var neededFuel = (this.ConsumptionPerKm - AirConditionerConsumption) * km;

            if (this.FuelQuantity < neededFuel)
            {
                return $"{vehicleName} needs refueling";
            }

            this.FuelQuantity -= neededFuel;
            return $"{vehicleName} travelled {km} km";
        }
    }
}
