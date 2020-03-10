using System;

namespace _5.ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Town { get; set; }

        public int Equal { get; set; }

        public int CompareTo(Person other)
        {
            var namesAreEqual = this.Name.CompareTo(other.Name);

            if (namesAreEqual == 0)
            {
                var agesAreEqual = this.Age.CompareTo(other.Age);

                if (agesAreEqual == 0)
                {
                    var townsAreEqual = this.Town.CompareTo(other.Town);

                    if (townsAreEqual == 0)
                    {
                        return 0;
                    }
                }
            }

            return -1;
        }
    }
}
