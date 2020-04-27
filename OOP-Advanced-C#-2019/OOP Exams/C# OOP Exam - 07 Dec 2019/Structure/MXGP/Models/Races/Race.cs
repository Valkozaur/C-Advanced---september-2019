namespace MXGP.Models.Races
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using MXGP.Models.Riders;
    using Riders.Contracts;
    using Utilities.Messages;

    public class Race : IRace
    {
        private const int MinimumNameLenght = 5;
        private const int MinimumLaps = 1;

        private string name;
        private int laps;
        private IList<IRider> riders;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            this.riders = new List<IRider>();
        }

        public string Name 
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < MinimumNameLenght)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidName, value, MinimumNameLenght));
                }

                this.name = value;
            }
        }

        public int Laps 
        {
            get => this.laps;
            private set
            {
                if(value < MinimumLaps)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidNumberOfLaps), MinimumLaps.ToString());
                }

                this.laps = value;
            }
        }

        public IReadOnlyCollection<IRider> Riders => (IReadOnlyCollection<IRider>)this.riders;

        public void AddRider(IRider rider)
        {
            if (rider == null)
            {
                throw new ArgumentNullException(ExceptionMessages.RiderInvalid);
            }

            if (rider.CanParticipate == false)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.RiderNotParticipate, rider.Name));
            }

            if (this.Riders.Any(x => x.Name == rider.Name))
            {
                throw new ArgumentNullException(String.Format(ExceptionMessages.RiderAlreadyAdded, rider.Name, this.name));
            }

            this.riders.Add(rider);
        }
    }
}
