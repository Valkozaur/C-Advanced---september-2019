namespace P01_RawData
{
    using System.Collections.Generic;

    public class TiresFactory
    {
        public List<Tire> CreateTiresCollection(List<string> tiresParameters)
        {
            var tires = new List<Tire>();

            for (var i = 1; i < tiresParameters.Count; i += 2)
            {
                var tirePressure = double.Parse(tiresParameters[i - 1]);
                var tireAge = int.Parse(tiresParameters[i]);

                var tire = new Tire(tirePressure, tireAge);
                tires.Add(tire);
            }

            return tires;
        }
    }
}
