namespace P09.ExplicitInterfaces.Objects
{
    public class Citizen : IResident, IPerson
    {
        public Citizen(string name, string country, int age)
        {
            this.Name = name;
            this.Country = country;
            this.Age = age;
        }

        public string Name { get; set; }

        public string Country { get; set; }

        public int Age { get; set; }

        public string GetName() => this.Name;

        string IResident.GetName() => $"Mr/Ms/Mrs {this.Name}";
    }
}
