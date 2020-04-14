namespace _4.BorderControl
{
    using System;
    using Interfaces;

    public class Pet
    {
        public Pet(string name, string birthDate)
        {
            this.Name = name;
            this.BirthDate = birthDate;
        }

        public string Name { get; set; }

        public string BirthDate { get; set; }
    }
}
