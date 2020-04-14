namespace P07.MilitaryElite.Models.Soldiers.Privates
{
    using Contracts.Soldier.Private.SpecialisedSoldier;
    using System;
    using System.Text;

    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corps;

        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public string Corps
        {
            get => this.corps;
            private set
            {
                if (value != "Airforces" && value != "Marines")
                {
                    throw new ArgumentException("Invalid corps!");
                }

                this.corps = value;
            }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{base.ToString()}");
            stringBuilder.Append($"Corps: {this.Corps}");

            return stringBuilder.ToString();
        }
    }
}
