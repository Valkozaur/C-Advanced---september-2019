using System.Collections.Generic;

namespace _6.StrategyPattern
{
    public class NameComperator : IComparer<Person>
    {
        public int Compare(Person firstPerson, Person secondPerson)
        {
            var compareByLenght = firstPerson.Name.Length.CompareTo(secondPerson.Name.Length);

            if (compareByLenght == 0)
            {
                return firstPerson.Name.CompareTo(secondPerson.Name);
            }

            return compareByLenght;
        }
    }
}