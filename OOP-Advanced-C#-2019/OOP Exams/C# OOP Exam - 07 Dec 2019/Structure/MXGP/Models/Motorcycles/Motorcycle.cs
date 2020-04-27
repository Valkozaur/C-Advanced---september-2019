namespace MXGP.Models.Motorcycles
{
    using System;

    using Contracts;
    using Utilities.Messages;

    public abstract class Motorcycle : IMotorcycle
    {
        private const int MinimumNameLenght = 4;

        private string model;
        private int horsePower;

        protected Motorcycle(string model, int horsePower, double cubicCentimeters)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model 
        {
            get => this.model;
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < MinimumNameLenght)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidModel, value, MinimumNameLenght));
                }

                this.model = value;
            }
        }

        public virtual int HorsePower 
        { 
            get => this.horsePower; 
            protected set => this.horsePower = value; 
        }

        public double CubicCentimeters { get; }

        public double CalculateRacePoints(int laps)
        {
            double racePoints = this.CubicCentimeters / this.HorsePower * laps;
            return racePoints;
        }
    }
}
