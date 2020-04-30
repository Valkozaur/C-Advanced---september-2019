namespace P07.InfernoInfinity.Models
{
    using System.Collections.Generic;

    using Contracts;

    public abstract class Command : IExecutable
    {
        protected IList<string> arguments;
        protected IWeaponRepository weaponDatabase;

        protected Command(IList<string> arguments, IWeaponRepository weaponDatabase)
        {
            this.arguments = arguments;
            this.weaponDatabase = weaponDatabase;
        }

        public abstract void Execute();
    }
}
