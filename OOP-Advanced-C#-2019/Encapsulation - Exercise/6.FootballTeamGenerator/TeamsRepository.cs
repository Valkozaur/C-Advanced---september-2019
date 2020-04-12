namespace _6.FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TeamsRepository
    {
        private List<Team> teams;

        public TeamsRepository()
        {
            this.teams = new List<Team>();
        }

        public void AddTeam(Team team)
        {
            this.teams.Add(team);
        }

        public Team ReturnTeam(string name)
        {
            if (!this.teams.Any(x => x.TeamName == name))
            {
                throw new ArgumentException($"Team {name} does not exist.");
            }

            return teams.First(x => x.TeamName == name);
        }
    }
}
