namespace MXGP.Models.Motorcycles
{
    using System;

    using Utilities.Messages;

    class PowerMotorcycle : Motorcycle
    {
        private const double MandatoryCubicCentimeters = 450;

        private int horsePower;

        public PowerMotorcycle(string model, int horsePower)
            : base (model, horsePower, MandatoryCubicCentimeters)
        {
        }

        public override int HorsePower 
        {
            get => this.horsePower;
            protected set
            {
                if (value < 70 || value > 100)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                this.horsePower = value;
            } 
        }
    }
}
