namespace _6.FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Player
    {
        private string name;
        private Dictionary<string, int> statistics;

        public Player(string name, params int[] stats)
        {
            this.Name = name;
            this.statistics = new Dictionary<string, int>();
            this.SeedStats();
            AddStat(stats);
        }

        public IReadOnlyDictionary<string, int> Statistics => this.statistics;

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public double AverageStat => this.statistics.Sum(x => (double)x.Value) / this.statistics.Count;

        private void SeedStats()
        {
            this.statistics.Add("Endurance", 0);
            this.statistics.Add("Sprint", 0);
            this.statistics.Add("Dribble", 0);
            this.statistics.Add("Passing", 0);
            this.statistics.Add("Shooting", 0);
        }

        private void AddStat(params int[] stats)
        {
            this.statistics["Endurance"] = stats[0];
            this.statistics["Sprint"] = stats[1];
            this.statistics["Dribble"] = stats[2];
            this.statistics["Passing"] = stats[3];
            this.statistics["Shooting"] = stats[4];

            if (statistics.Any(x => x.Value > 100 || x.Value < 0))
            {
                var wrongRangeStats = statistics.FirstOrDefault(x => x.Value < 0 || x.Value > 100);
                throw new ArgumentException($"{wrongRangeStats.Key} should be between 0 and 100.");
            }
        }
    }
}
