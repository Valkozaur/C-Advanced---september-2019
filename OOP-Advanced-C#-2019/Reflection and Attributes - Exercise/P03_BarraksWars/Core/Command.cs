using _03BarracksFactory.Contracts;

namespace P03_BarraksWars
{
    public abstract class Command : IExecutable
    {
        private string[] data;

        public Command(string[] data)
        {
            this.Data = data;
        }

        protected string[] Data 
        {
            get => this.data;
            private set => this. data = value;
        }

        public abstract string Execute();
    }
}
