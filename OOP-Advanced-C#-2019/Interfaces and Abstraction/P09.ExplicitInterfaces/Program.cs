namespace P09.ExplicitInterfaces
{
    using Objects;
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var citizens = new List<Citizen>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                var citizenInfo = input.Split(" ");
                var name = citizenInfo[0];
                var country = citizenInfo[1];
                var age = int.Parse(citizenInfo[2]);

                citizens.Add(new Citizen(name, country, age));
            }

            foreach (var citizen in citizens)
            {
                Console.WriteLine(citizen.GetName());
                var asResident = citizen as IResident; 
                Console.WriteLine(asResident.GetName());
            }
        }
    }
}
