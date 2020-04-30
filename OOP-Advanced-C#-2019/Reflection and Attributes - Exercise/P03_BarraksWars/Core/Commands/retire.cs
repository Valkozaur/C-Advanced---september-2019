using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.Commands
{
    public class Retire : Command
    {
        [Inject]
        private IRepository repository;

        public Retire(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            this.repository.RemoveUnit(this.Data[1]);
            return $"{this.Data[1]} retired!";
        }
    }
}
