namespace P07.InfernoInfinity.Models.Commands
{
    using System.Collections.Generic;

    using Contracts;

    public class Remove : Command
    {
        public Remove(IList<string> arguments, IWeaponRepository weaponDatabase) 
            : base(arguments, weaponDatabase)
        {
        }

        public override void Execute()
        {
            var weaponName = this.arguments[0];
            var socketIndex = int.Parse(this.arguments[1]);

            var weapon = this.weaponDatabase.GetWeapon(weaponName);
            weapon.RemoveGem(socketIndex);
        }
    }
}
