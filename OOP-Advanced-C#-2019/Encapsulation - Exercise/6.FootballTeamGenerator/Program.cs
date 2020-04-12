using System;

namespace _6.FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var teamRepository = new TeamsRepository();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                var splitInput = input
                    .Split(";");
                var command = splitInput[0];
                var teamName = splitInput[1];

                try
                {
                    switch (command)
                    {
                        case "Team":
                            var teamToAdd = new Team(teamName);
                            teamRepository.AddTeam(teamToAdd);
                            break;

                        case "Add":
                            var playerName = splitInput[2];
                            var endurance = int.Parse(splitInput[3]);
                            var sprint = int.Parse(splitInput[4]);
                            var dribble = int.Parse(splitInput[5]);
                            var passing = int.Parse(splitInput[6]);
                            var shooting = int.Parse(splitInput[7]);

                            var player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                            var team = teamRepository.ReturnTeam(teamName);
                            team.AddPlayer(player);
                            break;

                        case "Remove":
                            playerName = splitInput[2];
                            team = teamRepository.ReturnTeam(teamName);
                            team.RemovePlayer(playerName);
                            break;

                        case "Rating":
                            team = teamRepository.ReturnTeam(teamName);
                            Console.WriteLine($"{team.TeamName} - {team.Rating}");
                            break;
                    }
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
