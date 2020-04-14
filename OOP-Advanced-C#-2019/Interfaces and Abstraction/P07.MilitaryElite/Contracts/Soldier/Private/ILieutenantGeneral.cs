namespace P07.MilitaryElite.Contracts.Soldier.Private.LieutenantGeneral
{
    using System.Collections.Generic;
    using Models.Soldiers;

    public interface ILieutenantGeneral
    {
        IReadOnlyCollection<Private> Privates { get; }
    }
}
