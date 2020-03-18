namespace P01_RawData
{
    using System.Collections.Generic;
    using System.Linq;

    public class CarCatalog
    {
        private List<Car> cars;
        private CarFactory carFactory;
        private EngineFactory engineFactory;
        private CargoFactory cargoFactory;
        private TiresFactory tiresFactory;

        public CarCatalog()
        {
            this.cars = new List<Car>();
            this.carFactory = new CarFactory();
            this.engineFactory = new EngineFactory();
            this.cargoFactory = new CargoFactory();
            this.tiresFactory = new TiresFactory();
        }

        public List<Car> Cars => cars;

        public void AddCar(string[] parameters)
        {
            var model = parameters[0];
            var engineSpeed = int.Parse(parameters[1]);
            var enginePower = int.Parse(parameters[2]);
            var cargoWeight = int.Parse(parameters[3]);
            var cargoType = parameters[4];
            var tiresParameters = parameters.Skip(5).ToList();

            var engine = engineFactory.CreateEngine(enginePower, engineSpeed);
            var cargo = cargoFactory.CreateCargo(cargoWeight, cargoType);
            var tires = tiresFactory.CreateTiresCollection(tiresParameters);

            this.cars.Add(carFactory.CarCreate(model, engine, cargo, tires));
        }
    }
}
