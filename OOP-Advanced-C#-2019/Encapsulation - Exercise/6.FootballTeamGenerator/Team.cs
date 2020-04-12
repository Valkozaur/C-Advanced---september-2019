namespace _6.FootballTeamGenerator
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class Team
    {
		private string teamName;
		private List<Player> players;

		public Team(string teamName)
		{
			this.TeamName = teamName;
			this.players = new List<Player>();
		}
		
		public string TeamName 
		{
			get => this.teamName;
			private set
			{

				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("A name should not be empty.");
				}

				this.teamName = value;
			}
		}

		public double Rating { get; private set; }

	public void AddPlayer(Player player)
		{
			this.players.Add(player);
			this.Rating = Math.Round(players.Sum(x => x.AverageStat) / this.players.Count);
		}

		public void RemovePlayer(string playersName)
		{
			var playerToRemove = players.FirstOrDefault(x => x.Name == playersName);
			if (playerToRemove == default)
			{
				throw new ArgumentException($"Player {playersName} is not in {this.TeamName} team.");
			}

			this.players.Remove(playerToRemove);
			this.Rating = Math.Round(players.Sum(x => x.AverageStat) / this.players.Count);
		}
	}
}
