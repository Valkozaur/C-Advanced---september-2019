namespace P01_RawData
{
    using System.Collections.Generic;

    public class CarFactory
    {
        public Car CarCreate(string model, Engine engine, Cargo cargo, List<Tire> tires)
        {
            
            return new Car(model, engine, cargo, tires);
        }
    }
}
