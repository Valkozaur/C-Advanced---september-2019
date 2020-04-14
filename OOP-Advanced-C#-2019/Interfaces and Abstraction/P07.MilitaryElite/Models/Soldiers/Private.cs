namespace P07.MilitaryElite.Models.Soldiers
{
    using Contracts.Soldiers.Privates;

    public class Private : Soldier, IPrivate
    {
        public Private(string id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} Salary: {this.Salary:F2}";
        }
    }
}
