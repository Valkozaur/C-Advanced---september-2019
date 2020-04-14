namespace P07.MilitaryElite.Contracts.Soldier.Private.SpecialisedSoldier
{
    public interface IMission
    {
        string CodeName { get; }

        string State { get; }

        void CompleteMission();
    }
}