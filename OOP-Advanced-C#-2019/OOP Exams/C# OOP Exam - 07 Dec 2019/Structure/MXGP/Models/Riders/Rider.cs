namespace MXGP.Models.Riders
{
    using System;

    using Riders.Contracts;
    using Utilities.Messages;
    using Motorcycles.Contracts;

    public class Rider : IRider
    {
        private const int MinimumNameSymbols = 5;
        private string name;
        
        public Rider(string name)
        {
            this.Name = name;
            this.CanParticipate = false;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < MinimumNameSymbols)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidName, value, MinimumNameSymbols));
                }

                this.name = value;
            }
        }

        public IMotorcycle Motorcycle { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate { get; private set; }

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            if (motorcycle == null)
            {
                throw new ArgumentNullException(ExceptionMessages.MotorcycleInvalid);
            }

            this.Motorcycle = motorcycle;
            this.CanParticipate = true;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
