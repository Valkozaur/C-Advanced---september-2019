﻿namespace P02_CarsSalesman
{
    using System;
    using System.Text;

    public class Car
    {
        private const string offset = "  ";

        private string model;
        private Engine engine;
        private int weight;
        private string color;

        public Car(string model, Engine engine, int weight, string color)
        {
            this.model = model;
            this.engine = engine;
            this.weight = weight;
            this.color = color;
        }

        public Car(string model, Engine engine, int weight)
        : this(model, engine,weight, "n/a")
        {
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine, -1, color)
        {
            this.model = model;
            this.engine = engine;
            this.weight = -1;
            this.color = color;
        }
        
        public Car(string model, Engine engine)
            : this(model, engine, -1, "n/a")
        {
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}:" + Environment.NewLine, this.model);
            sb.Append(this.engine.ToString());
            sb.AppendFormat("{0}Weight: {1}" + Environment.NewLine, offset, this.weight == -1 ? "n/a" : this.weight.ToString());
            sb.AppendFormat("{0}Color: {1}", offset, this.color);

            return sb.ToString();
        }
    }
}
