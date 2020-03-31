using System;

namespace _1.Person2
{
    public class Program
    {
        public static void Main()
        {
            var name = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());

            try
            {
                var child = new Child(name, age);
                Console.WriteLine(child);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
