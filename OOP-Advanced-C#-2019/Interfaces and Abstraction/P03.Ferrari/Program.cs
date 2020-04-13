using System;

namespace P03.Ferrari
{
    public class Program
    {
        public static void Main()
        {
            var driver = Console.ReadLine();
            Car car = new Ferrari(driver);
            Console.WriteLine(car);
        }
    }
}
