using System;
using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.Commands
{
    class Fight : Command
    {
        public Fight(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return String.Empty;
        }
    }
}
