namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Family
    {
        private List<Person> family;

        public Family()
        {
            this.family = new List<Person>();
        }

        public void AddMember(Person member)
        {
            this.family.Add(member);
        }

        public Person GetOldestMember()
        {
            int oldestAge = int.MinValue;
            Person oldestPerson = null;

            foreach (var member in this.family)
            {
                if (member.Age > oldestAge)
                {
                    oldestAge = member.Age;
                    oldestPerson = member;
                }
            }

            return oldestPerson;
        }

        public List<Person> GetPeopleOverThirty()
        {
            return this.family.Where(x => x.Age > 30).ToList();
        }
    }
}
