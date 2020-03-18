namespace P01_RawData
{
    public class CargoFactory
    {
        public Cargo CreateCargo(int weight, string type)
        {
            return new Cargo(weight, type);
        }
    }
}
