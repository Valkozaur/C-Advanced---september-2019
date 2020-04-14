namespace P07.MilitaryElite.Models.Soldiers.Privates.SpecialisedSoldiers
{
    using Contracts.Soldier.Private.SpecialisedSoldier;
    using System.Collections.Generic;
    using System.Text;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private HashSet<Repair> repairs;

        public Engineer(string id, string firstName, string lastName, decimal salary, string corps, HashSet<Repair> repairs) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = repairs; 
        }

        public IReadOnlyCollection<Repair> Repairs => this.repairs;

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{base.ToString()}");
            stringBuilder.AppendLine("Repairs:");

            foreach (var @repair in repairs)
            {
                stringBuilder.AppendLine(repair.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
