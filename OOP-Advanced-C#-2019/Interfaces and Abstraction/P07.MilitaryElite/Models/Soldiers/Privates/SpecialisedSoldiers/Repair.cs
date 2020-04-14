namespace P07.MilitaryElite.Models.Soldiers.Privates.SpecialisedSoldiers
{
    using Contracts.Soldier.Private.SpecialisedSoldier;

    public class Repair : IRepair
    {
        public Repair(string partName, int hoursWorked)
        {
            this.PartName = partName;
            this.HoursWorker = hoursWorked;
        }

        public string PartName { get; set; }

        public int HoursWorker { get; set; }

        public override string ToString()
        {
            return " " + $"Part Name: {this.PartName} Hours Worked: {this.HoursWorker}";
        }
    }
}
