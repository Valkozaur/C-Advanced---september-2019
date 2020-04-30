namespace P07.InfernoInfinity.DataBase
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;

    public class WeaponRepository : IWeaponRepository
    {
        public List<IWeapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new List<IWeapon>();
        }

        public override IReadOnlyCollection<IWeapon> WeaponDatabase => this.weapons;

        public override void AddWeapon(IWeapon weapon)
        {
            this.weapons.Add(weapon);
        }

        public override IWeapon GetWeapon(string name)
        {
            var weapon = this.weapons.FirstOrDefault(x => x.Name == name);
            return weapon;
        }
    }
}
