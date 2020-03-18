namespace Guild
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = Capacity;
            this.roster = new List<Player>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count
        {
            get { return this.Count; }
            private set { this.Count = this.roster.Count; }
        }

        public void AddPlayer(Player player)
        {
            this.roster.Add(player);
        }

        public bool RemovePlayer(string name)
        {
            var player = this.roster.FirstOrDefault(x => x.Name == name);
            if (player != default)
            {
                this.roster.Remove(player);
                return true;
            }

            return false;
        }

        public void PromotePlayer(string name)
        {
            var player = this.roster.FirstOrDefault(x => x.Name == name);
            if (player != default)
            {
                if (player.Rank != "Member")
                {
                    player.Rank = "Member";
                }
            }
        }

        public void DemotePlayer(string name)
        {
            var player = this.roster.FirstOrDefault(x => x.Name == name);
            if (player != default)
            {
                if (player.Rank == "Member")
                {
                    player.Rank = "Trial";
                }
            }
        }

        public Player[] KickPlayersByClass(string @class)
        {
            var players = this.roster
                .Where(x => x.Class == @class)
                .ToArray();

            this.roster.RemoveAll(x => x.Class == @class);

            return players;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");

            foreach (var player in this.roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString();
        }
    }
}
