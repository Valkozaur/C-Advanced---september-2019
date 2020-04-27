namespace MXGP.Models.Motorcycles
{
    using System;

    using Utilities.Messages;

    public class SpeedMotorcycle : Motorcycle
    {
        private const double MandatoryCubicCentimeters = 125;

        private int horsePower;

        public SpeedMotorcycle(string model, int horsePower) 
            : base(model, horsePower, MandatoryCubicCentimeters)
        {
        }

        public override int HorsePower 
        { 
            get => this.horsePower;
            protected set 
            {
                if (value < 50 || value > 69)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                this.horsePower = value;
            } 
        }
    }
}
