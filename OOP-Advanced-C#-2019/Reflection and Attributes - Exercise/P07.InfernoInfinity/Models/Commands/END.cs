using System.Collections.Generic;

namespace P07.InfernoInfinity.Models.Commands
{
    using System;

    using Contracts;

    public class END : Command
    {
        public END(IList<string> arguments, IWeaponRepository weaponDatabase) 
            : base(arguments, weaponDatabase)
        {
        }

        public override void Execute()
        {
            Environment.Exit(0);
        }
    }
}
