namespace P07.MilitaryElite.Contracts.Soldier.Private.SpecialisedSoldier
{
    using Models.Soldiers.Privates.SpecialisedSoldiers;
    using System.Collections.Generic;

    public interface ICommando
    {
        IReadOnlyCollection<Mission> Missions { get; }
    }
}
