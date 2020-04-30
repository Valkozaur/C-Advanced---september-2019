namespace RobotService.Models.Robots
{
    using System;

    using Contracts;
    using Utilities.Messages;

    public abstract class Robot : IRobot
    {
        private const string DefaultOwner = "Service";
        private bool DefaultStateOfBools = false;

        private int happiness;
        private int energy;

        protected Robot(string name, int energy, int happiness, int produceTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = produceTime;
            this.Owner = DefaultOwner;
            this.IsBought = DefaultStateOfBools;
            this.IsChecked = DefaultStateOfBools;
            this.IsChipped = DefaultStateOfBools;
        }

        public string Name { get;  set; }

        public int Happiness 
        {
            get => this.happiness;
            set
            {
                if (IsInRangeOneToHundred(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidHappiness);
                }

                this.happiness = value;
            }
        }

        public int Energy 
        {
            get => this.energy;
            set
            {
                if (IsInRangeOneToHundred(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEnergy);
                }
            }
        }

        public int ProcedureTime { get;  set; }

        public string Owner { get;  set; }

        public bool IsBought { get;  set; }

        public bool IsChipped { get;  set; }

        public bool IsChecked { get;  set; }

        private bool IsInRangeOneToHundred(int value) => value < 0 || value > 100;

        public override string ToString()
        {
            return 
                String.Format(OutputMessages.RobotInfo, this.GetType().Name, this.Name, this.Happiness, this.Energy);
        }
    }
}
