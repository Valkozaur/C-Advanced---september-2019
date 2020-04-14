namespace P07.MilitaryElite.Models.Soldiers
{
    using Contracts.Soldiers;
    using System.Text;

    public class Spy : Soldier, ISpy
    {
        public Spy(string id, string firstName, string lastName, int codeNumber)
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{base.ToString()}");
            stringBuilder.Append($"Code Number: {this.CodeNumber}");

            return stringBuilder.ToString();
        }
    }
}
