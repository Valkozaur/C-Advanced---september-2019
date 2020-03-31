using System;

namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var name = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());

            Person person;

            try
            {
                if (age > 15)
                {
                    person = new Person(name, age);
                }
                else
                {
                    person = new Child(name, age);
                }
                Console.WriteLine(person);
            }
            catch (Exception e)
            {

            }
        }
    }
}