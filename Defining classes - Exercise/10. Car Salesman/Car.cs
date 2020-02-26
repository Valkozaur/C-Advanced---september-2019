namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Car
    {
        public Car(string model, Engine engine, double weight, string color)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }

        public Car(string model, Engine engine, double weight)
    : this(model, engine, weight, "n/a")
        {
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine, -1, color)
        {
        }

        public Car(string model, Engine engine)
            : this(model, engine, -1, "n/a")
        {
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public double Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Model}:");
            sb.AppendLine($"{this.Engine}");
            sb.AppendLine(this.Weight == -1
                ? $"  Weight: {this.Weight}"
                : "  Weight: n/a");
            sb.Append($"  Color: {this.Color}");

            return sb.ToString();
        }
    }
}
