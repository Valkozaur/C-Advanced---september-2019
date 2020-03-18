using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization.Formatters;

namespace P02_CarsSalesman
{
    public class CarSalesman
    {
        private EngineFactory engineFactory;
        private CarFactory carFactory;
        private EngineCatalog engineCatalog;
        private CarCatalog carCatalog;

        public CarSalesman()
        {
            this.engineFactory = new EngineFactory();
            this.carFactory = new CarFactory();
            this.engineCatalog = new EngineCatalog();
            this.carCatalog = new CarCatalog();
        }

        public void AddEngine(string[] parameters)
        {
            this.engineCatalog.AddCar(this.engineFactory.CreateEngine(parameters));
        }

        public void AddCar(string[] parameters)
        {
            var car = this.carFactory.CreateCar(parameters, this.engineCatalog.GetEngines);
            if (car != null)
            {
                carCatalog.AddCar(car);
            }
        }

        public List<Car> ReturnCars => carCatalog.GetCars;
    }
}
