namespace P02_CarsSalesman
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var carSalesMan = new CarSalesman();

            int engineCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < engineCount; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                carSalesMan.AddEngine(parameters);
            }

            int carCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carCount; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                carSalesMan.AddCar(parameters);
                
            }

            foreach (var car in carSalesMan.ReturnCars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
