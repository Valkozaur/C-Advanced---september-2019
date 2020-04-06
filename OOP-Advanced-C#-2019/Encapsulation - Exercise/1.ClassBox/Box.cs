using System;

namespace _1.ClassBox
{
    public class Box
    {
        private const string ErrorMessage = "{0} cannot be zero or negative.";

        private double length;
        private double width;
        private double heigth;

        public Box(double length, double width, double heigth)
        {
            this.Length = length;
            this.Width = width;
            this.Heigth = heigth;
        }

        private double Length
        {
            get => this.length;
            set
            {
                ValidateParameter(value,nameof(this.Length));
                this.length = value;
            }
        }

        private double Width
        {
            get => this.width;
            set
            {
                ValidateParameter(value, nameof(this.Width));
                this.width = value;
            }
        }

        private double Heigth {

            get => this.heigth;
            set
            {
                ValidateParameter(value, nameof(this.Heigth));
                this.heigth = value;
            } 
        }

        private void ValidateParameter(double parameter, string caller)
        {
            if (parameter <= 0)
            {
                throw new ArgumentException(String.Format(ErrorMessage, caller));
            }
        }


        public double GetSurfaceArea()
        {
            var surfaceArea = (2 * this.length * this.width) + GetLateralSurface();
            return surfaceArea;
        }

        public double GetLateralSurface()
        {
            double lateralSurface = 2 * (this.length * this.heigth + this.width * this.heigth);
            return lateralSurface;
        }

        public double GetVolume()
        {
            var volume = this.length * this.width * this.heigth;
            return volume;
        }
    }
}
