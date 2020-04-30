using System;
using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.Factories
{
    public class Report : Command
    {
        [Inject]
        private IRepository repository;

        public Report(string[] data)
            : base(data)
        {
        }

        public override string Execute()
        {
            var output = this.repository.Statistics;
            return output;
        }
    }
}
