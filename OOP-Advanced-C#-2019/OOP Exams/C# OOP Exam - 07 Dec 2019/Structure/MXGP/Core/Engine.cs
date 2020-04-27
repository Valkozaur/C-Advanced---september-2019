namespace MXGP.Core
{
    using IO;
    using System;

    using Contracts;

    public class Engine : IEngine
    {
        public Engine()
        {
            this.ConsoleReader = new ConsoleReader();
            this.ConsoleWriter = new ConsoleWriter();
        }

        public ConsoleReader ConsoleReader { get; private set; }

        public ConsoleWriter ConsoleWriter { get; private set; }

        public void Run()
        {
            var championshipController = new ChampionshipController();

            while (true)
            {
                var input = ConsoleReader.ReadLine();

                if (input == "End")
                {
                    break;
                }

                var splitInput = input.Split();
                var command = splitInput[0];

                try
                {
                    switch (command)
                    {
                        case "CreateRider":
                            var riderName = splitInput[1];
                            this.ConsoleWriter.WriteLine(championshipController.CreateRider(riderName));
                            break;

                        case "CreateMotorcycle":
                            var type = splitInput[1];
                            var model = splitInput[2];
                            var horsePower = int.Parse(splitInput[3]);
                            this.ConsoleWriter.WriteLine(championshipController.CreateMotorcycle(type, model, horsePower));
                            break;
                            
                        case "AddMotorcycleToRider":
                            riderName = splitInput[1];
                            var motorcycleModel = splitInput[2];
                            this.ConsoleWriter.WriteLine(championshipController.AddMotorcycleToRider(riderName, motorcycleModel));
                            break;

                        case "AddRiderToRace":
                            var raceName = splitInput[1];
                            riderName = splitInput[2];
                            this.ConsoleWriter.WriteLine(championshipController.AddRiderToRace(raceName, riderName));
                            break;

                        case "CreateRace":
                            raceName = splitInput[1];
                            var laps = int.Parse(splitInput[2]);
                            this.ConsoleWriter.WriteLine(championshipController.CreateRace(raceName, laps));
                            break;

                        case "StartRace":
                            raceName = splitInput[1];
                            this.ConsoleWriter.WriteLine(championshipController.StartRace(raceName));
                            break;
                    }
                }
                catch (Exception ex)
                {
                    this.ConsoleWriter.WriteLine(ex.Message);
                }
            }
        }
    }
}
