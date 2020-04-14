namespace P07.MilitaryElite.Contracts.Soldier.Private.SpecialisedSoldier
{
    using Models.Soldiers.Privates.SpecialisedSoldiers;
    using System.Collections.Generic;

    public interface IEngineer
    {
        IReadOnlyCollection<Repair> Repairs { get; }
    }
}
