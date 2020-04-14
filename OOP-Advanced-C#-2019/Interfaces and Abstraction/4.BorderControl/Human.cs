namespace _4.BorderControl
{
    using Interfaces;
    using System;

    public class Human : Buyer, ICitizen
    {
        public Human(string name, int age, string id, string birthDate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.BirthDate = birthDate;
        }

        public string Id { get; set; }

        public string BirthDate { get; set; }

        protected override int DefaultFood => 10;
    }
}
