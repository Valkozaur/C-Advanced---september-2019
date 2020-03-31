namespace _3.Mankind
{
    using System;
    using System.Text;

    public abstract class Human
    {
        private const string InvalidFirstLetterMessage = "Expected upper case letter! Argument: {0}";
        public static string InvalidLengthMessage { get; } = "Expected length at least {0} symbols! Argument: {1}";

        private const int MinimumFirstNameLength = 4;
        private const int MinimumLastNameLength = 3;

        private string firstName;
        private string lastName;

        protected Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get => this.firstName;
            protected set
            {

                ValidateUpperCase(value, nameof(this.firstName));

                ValidateLength(value, nameof(this.firstName), MinimumFirstNameLength);

                this.firstName = value;
            }
        }

        public string LastName
        {
            get => this.lastName;
            protected set
            {
                ValidateUpperCase(value, nameof(this.lastName));

                ValidateLength(value, nameof(this.lastName), MinimumLastNameLength);

                this.lastName = value;
            }
        }

        private void ValidateUpperCase(string name, string parameterName)
        {
            if (!char.IsUpper(name[0]))
            {
                throw new ArgumentException(string.Format(InvalidFirstLetterMessage, parameterName));
            }
        }

        private void ValidateLength(string name, string parameterName, int minimumLength)
        {
            if (name.Length < minimumLength)
            {
                throw new ArgumentException(string.Format(InvalidLengthMessage, minimumLength, parameterName));
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"First Name: {this.FirstName}");
            sb.AppendLine($"Last Name: {this.LastName}");

            return sb.ToString().TrimEnd();
        }
    }
}
