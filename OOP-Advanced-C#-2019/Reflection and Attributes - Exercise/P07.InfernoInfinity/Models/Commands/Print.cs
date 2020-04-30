
namespace P07.InfernoInfinity.Models.Commands
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Attributes;

    public class Print : Command
    {
        [Inject]
        private IOutputManager outputManager;

        public Print(IList<string> arguments, IWeaponRepository weaponDatabase)
            : base(arguments, weaponDatabase)
        {
        }

        public override void Execute()
        {
            var weaponName = this.arguments[0];

            var weapon = this.weaponDatabase.GetWeapon(weaponName);
            Console.WriteLine(weapon);
        }
    }
}
