namespace P07.InfernoInfinity.Models.Commands
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Attributes;
    using Enumerations;

    public class Create : Command
    {
        [Inject]
        private IWeaponFactory weaponFactory;

        public Create(IList<string> arguments, IWeaponRepository weaponDatabase)
            : base(arguments, weaponDatabase)
        {
        }

        public override void Execute()
        {
            var typeArgs = this.arguments[0]
                .Split(" ");
            var rarity = typeArgs[0];
            var type = typeArgs[1];
            var name = this.arguments[1];

            this.weaponDatabase.AddWeapon(this.weaponFactory.CreateWeapon((Rarity)Enum.Parse(typeof(Rarity), rarity), type, name));
        }
    }
}
