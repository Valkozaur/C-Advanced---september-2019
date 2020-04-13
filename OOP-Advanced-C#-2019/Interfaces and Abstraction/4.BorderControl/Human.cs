namespace _4.BorderControl
{
    using Interfaces;
    using System;

    public class Human : Citizen, IBeing, ICitizen
    {
        public Human(string name, int age, string id, string birthDate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.BirthDate = birthDate;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string BirthDate { get; set; }
    }
}
