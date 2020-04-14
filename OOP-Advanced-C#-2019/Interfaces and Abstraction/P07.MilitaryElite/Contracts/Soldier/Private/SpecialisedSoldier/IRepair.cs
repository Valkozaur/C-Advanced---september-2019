namespace P07.MilitaryElite.Contracts.Soldier.Private.SpecialisedSoldier
{
    public interface IRepair
    {
        string PartName { get; }
        
        int HoursWorker { get; }
    }
}