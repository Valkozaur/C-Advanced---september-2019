namespace P02_CarsSalesman
{
    using System.Collections.Generic;

    public class CarCatalog
    {
        private List<Car> cars;

        public CarCatalog()
        {
            this.cars = new List<Car>();
        }

        public List<Car> GetCars => cars;

        public void AddCar(Car car)
        {
            this.cars.Add(car);
        }
    }
}
