namespace P07.MilitaryElite.Models.Soldiers.Privates.SpecialisedSoldiers
{
    using Contracts.Soldier.Private.SpecialisedSoldier;
    using System.Collections.Generic;
    using System.Text;

    public class Commando : SpecialisedSoldier, ICommando
    {
        private HashSet<Mission> missions;

        public Commando(string id, string firstName, string lastName, decimal salary, string corps, HashSet<Mission> missions)
            : base(id, firstName, lastName, salary, corps)
        {
            this.missions = missions;
        }

        public IReadOnlyCollection<Mission> Missions => this.missions;

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{base.ToString()}");
            stringBuilder.AppendLine("Missions:");

            foreach (var mission in this.Missions)
            {
                stringBuilder.AppendLine(mission.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
