﻿
namespace _4.BorderControl
{
    using Interfaces;
    public class Rebel : Buyer, IPerson
    {
        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }

        public string Group { get; set; }

        protected override int DefaultFood => 5;
    }
}
