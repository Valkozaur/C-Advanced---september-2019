using System.Collections.Generic;

namespace P07.InfernoInfinity.Contracts
{
    public abstract class IWeaponRepository
    {
        public abstract IReadOnlyCollection<IWeapon> WeaponDatabase { get; }
        public abstract void AddWeapon(IWeapon weapon);
        public abstract IWeapon GetWeapon(string name);
    }
}
