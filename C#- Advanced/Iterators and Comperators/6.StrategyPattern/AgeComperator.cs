using System.Collections.Generic;

namespace _6.StrategyPattern
{
    public class AgeComperator : IComparer<Person>
    {
        public int Compare(Person firstPerson, Person secondPerson)
        {
            return firstPerson.Age.CompareTo(secondPerson.Age);
        }
    }
}