namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int memberCount = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < memberCount; i++)
            {
                string[] peopleInput = Console.ReadLine()
                    .Split(" ");
                string name = peopleInput[0];
                int age = int.Parse(peopleInput[1]);

                Person newMember = new Person(name, age);

                family.AddMember(newMember);
            }

            List<Person> PeopleOverThirty = family.GetPeopleOverThirty()
                .OrderBy(x => x.Name)
                .ToList();

            foreach (var member in PeopleOverThirty)
            {
                Console.WriteLine(member);
            }
        }
    }
}
