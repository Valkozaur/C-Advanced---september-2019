using System;

namespace P03.Ferrari
{
    public class Ferrari : Car
    {
        private string model;

        public Ferrari(string driver)
        {
            this.Driver = driver;
            this.model = "488-Spider";
        }

        public string Driver { get; set; }

        public string Model => this.model;

        public override string ToString()
        {
            return $"{this.Model}/{this.Brakes}/{this.GasPedal}/{this.Driver}";
        }
    }
}
