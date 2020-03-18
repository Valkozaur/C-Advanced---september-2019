namespace P01_RawData
{
    using System;
    using System.Linq;

    public class RawData
    {
        static CarCatalog carCatalog = new CarCatalog();

        public static void Main()
        {
            var lines = int.Parse(Console.ReadLine());

            for (var i = 0; i < lines; i++)
            {
                var parameters = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                carCatalog.AddCar(parameters);
            }

            var command = Console.ReadLine();

            Console.WriteLine(CommandParser(command));
        }

        public static string CommandParser(string command)
        {
            if (command == "fragile")
            {
                var fragile = carCatalog.Cars
                    .Where(x => x.Cargo.CargoType == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                return string.Join(Environment.NewLine, fragile);
            }
            else
            {
                var flamable = carCatalog.Cars
                    .Where(x => x.Cargo.CargoType == "flamable" && x.Engine.EnginePower > 250)
                    .Select(x => x.Model)
                    .ToList();

                return string.Join(Environment.NewLine, flamable);
            }
        }
    }
}
