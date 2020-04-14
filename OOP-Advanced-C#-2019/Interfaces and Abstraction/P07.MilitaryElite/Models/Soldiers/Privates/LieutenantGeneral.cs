namespace P07.MilitaryElite.Models.Soldiers.Privates
{
    using Contracts.Soldier.Private.LieutenantGeneral;
    using System.Collections.Generic;
    using System.Text;

    class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private HashSet<Private> privates;

        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary, HashSet<Private> privates) 
            : base(id, firstName, lastName, salary)
        {
            this.privates = privates;
        }

        public IReadOnlyCollection<Private> Privates => this.privates;

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{base.ToString()}");
            stringBuilder.AppendLine($"Privates:");

            foreach (var @private in Privates)
            {
                stringBuilder.AppendLine(" " + @private.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
