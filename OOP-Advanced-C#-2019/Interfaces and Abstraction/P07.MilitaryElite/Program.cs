namespace P07.MilitaryElite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using Models.Soldiers;
    using Models.Soldiers.Privates;
    using Models.Soldiers.Privates.SpecialisedSoldiers;

    class Program
    {
        private static List<Soldier> soldiers = new List<Soldier>();


        public static void Main()
        {

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                var soldierArgs = input
                    .Split(" ");

                var rank = soldierArgs[0];
                var id = soldierArgs[1];
                var firstName = soldierArgs[2];
                var lastName = soldierArgs[3];

                switch (rank)
                {
                    case "Private":
                        var salary = decimal.Parse(soldierArgs[4]);

                        var @private = new Private(id, firstName, lastName, salary);

                        soldiers.Add(@private);
                        break;

                    case "LieutenantGeneral":
                        salary = decimal.Parse(soldierArgs[4]);
                        var privatesInput = soldierArgs
                            .Skip(5)
                            .ToList();

                        var privates = GetPrivates(privatesInput);

                        var general = new LieutenantGeneral(id, firstName, lastName, salary, privates);
                        soldiers.Add(general);
                        break;

                    case "Engineer":
                        salary = decimal.Parse(soldierArgs[4]);
                        var corps = soldierArgs[5];
                        var repairsInput = soldierArgs
                            .Skip(6)
                            .ToList();

                        try
                        {
                            var repairs = GetRepairs(repairsInput);

                            soldiers.Add(new Engineer(id, firstName, lastName, salary, corps, repairs));
                        }
                        catch (Exception)
                        {
                        }
                        break;

                    case "Commando":
                        salary = decimal.Parse(soldierArgs[4]);
                        corps = soldierArgs[5];
                        var missionsInput = soldierArgs
                            .Skip(6)
                            .ToList();

                        try
                        {
                            var missions = GetMissions(missionsInput);

                            soldiers.Add(new Commando(id, firstName, lastName, salary, corps, missions));
                        }
                        catch (Exception)
                        {
                        }
                        break;

                    case "Spy":
                        var codeNumber = int.Parse(soldierArgs[4]);

                        soldiers.Add(new Spy(id, firstName, lastName, codeNumber));
                        break;
                }
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }

        private static HashSet<Mission> GetMissions(List<string> missionsInput)
        {
            var missions = new HashSet<Mission>();

            for (int i = 0; i < missionsInput.Count(); i += 2)
            {
                var missionName = missionsInput[i];
                var state = missionsInput[i + 1];

                try
                { 
                    missions.Add(new Mission(missionName, state));
                }
                catch (Exception)
                { 
                }
            }

            return missions;
        }

        private static HashSet<Repair> GetRepairs(List<string> repairsInput)
        {
            var repairs = new HashSet<Repair>();

            for (int i = 0; i < repairsInput.Count(); i+=2)
            {
                var partName = repairsInput[i];
                var partHours = int.Parse(repairsInput[i + 1]);

                repairs.Add(new Repair(partName, partHours));
            }

            return repairs;
        }

        private static HashSet<Private> GetPrivates(List<string> privatesIds)
        {
            var privatesToReturn = new HashSet<Private>();

            foreach (var id in privatesIds)
            {
                var soldier = soldiers.FirstOrDefault(x => x.Id == id && x.GetType().Name == nameof(Private));

                privatesToReturn.Add((Private)soldier);
            }

            return privatesToReturn;
        }
    }
}
