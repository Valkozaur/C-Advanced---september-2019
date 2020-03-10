namespace _7.EqualityLogic
{
    using System;
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(Person other)
        {
            var namesResult = this.Name.CompareTo(other.Name);

            if (namesResult == 0)
            {
                return this.Age - other.Age;
            }

            return namesResult;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Person other)
            {
                return this.Name == other.Name && this.Age == other.Age;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Age.GetHashCode();
        }
    }
}