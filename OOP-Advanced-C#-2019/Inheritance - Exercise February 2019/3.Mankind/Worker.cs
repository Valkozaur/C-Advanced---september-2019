namespace _3.Mankind
{
    using System;
    using System.Text;

    public class Worker : Human
    {
        private const string ValueMismatchMessage = "Expected value mismatch! Argument: {0}";

        private double weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, double weekSalary, double workingHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workingHoursPerDay;
        }

        public double WeekSalary
        {
            get => this.weekSalary;
            set
            {
                if (value <= 10)
                {
                    throw new ArgumentException(string.Format(ValueMismatchMessage, nameof(this.weekSalary)));
                }

                this.weekSalary = value;
            }
        }

        public double WorkHoursPerDay
        {
            get => this.workHoursPerDay;
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException(string.Format(ValueMismatchMessage, nameof(this.workHoursPerDay)));
                }

                this.workHoursPerDay = value;
            }
        }

        public double moneyPerHour(double weekSalary, double workingHours)
        {
            // 5 days work week;
            return weekSalary / (workingHours * 5);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Week Salary: {this.weekSalary:F2}");
            sb.AppendLine($"Hours per day: {this.WorkHoursPerDay:F2}");
            sb.AppendLine($"Salary per hour: {moneyPerHour(this.weekSalary, this.workHoursPerDay):F2}");

            return sb.ToString().TrimEnd();
        }
    }
}
