namespace P01_RawData
{
    public class EngineFactory
    {
        public Engine CreateEngine(int horsePowers, int speed)
        {
            return new Engine(speed, horsePowers);
        }
    }
}
