namespace _4.BorderControl
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class Program
    {
        public static void Main()
        {
            var citizens = new List<IBeing>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                var citizenInfo = input
                    .Split(" ");

                if (citizenInfo[0] == "Citizen")
                {
                    var name = citizenInfo[1];
                    var age = int.Parse(citizenInfo[2]);
                    var id = citizenInfo[3];
                    var birthDate = citizenInfo[4];


                    var human = new Human(name, age, id, birthDate);
                    citizens.Add(human);
                }
                ///else if (citizeninfo[0] == "robot")
                //{
                //    var model = citizeninfo[0];
                //    var id = citizeninfo[1];

                //    var robot = new robot(model, id);
                //    citizens.add(robot);
                //}
                else if (citizenInfo[0] == "Pet")
                {
                    var name = citizenInfo[1];
                    var birthDate = citizenInfo[2];
                    var pet = new Pet(name, birthDate);
                    citizens.Add(pet);
                }
            }

            var birthYear = Console.ReadLine();

            foreach (var citizen in citizens)
            {
                if (citizen.BirthDate.EndsWith(birthYear))
                {
                    Console.WriteLine(citizen.BirthDate);
                }
            }
        }
    }
}
