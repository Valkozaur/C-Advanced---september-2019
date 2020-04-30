
namespace P07.InfernoInfinity.Models.Commands
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Attributes;
    using Enumerations;

    public class Add : Command
    {
        [Inject]
        private IGemFactory gemFactory;

        public Add(IList<string> arguments, IWeaponRepository weaponDatabase)
            : base(arguments, weaponDatabase)
        {
        }

        public override void Execute()
        {
            var weaponName = this.arguments[0];
            var indexOfSocket = int.Parse(this.arguments[1]);
            var gemArgs = this.arguments[2].Split(" ");
            var clarity = gemArgs[0];
            var type = gemArgs[1];

            var weapon = this.weaponDatabase.GetWeapon(weaponName);
            weapon.AddGem(this.gemFactory.CreateGem((Clarity)Enum.Parse(typeof(Clarity), clarity), type), indexOfSocket);
        }
    }
}
