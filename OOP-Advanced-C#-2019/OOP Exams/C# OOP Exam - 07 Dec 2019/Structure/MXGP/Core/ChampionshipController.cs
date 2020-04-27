namespace MXGP.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Repositories;
    using Models.Races;
    using Models.Riders;
    using Core.Contracts;
    using Models.Motorcycles;
    using Utilities.Messages;
    using Models.Riders.Contracts;
    using Models.Motorcycles.Contracts;


    public class ChampionshipController : IChampionshipController
    {
        private const int MinimumParticipants = 3;

        private RaceRepository raceRepository = new RaceRepository();
        private RiderRepository riderRepository = new RiderRepository();
        private MotorcycleRepository motorcycleRepository = new MotorcycleRepository();

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var rider = this.riderRepository.GetByName(riderName);
            if (rider == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            var motorcycle = this.motorcycleRepository.GetByName(motorcycleModel);
            if (motorcycle == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel));
            }

            if (rider.Motorcycle != null)
            {
                rider.AddMotorcycle(motorcycle);
                return String.Format(OutputMessages.MotorcycleReplaced, riderName, motorcycleModel);
            }

            rider.AddMotorcycle(motorcycle);
            return String.Format(OutputMessages.MotorcycleAdded, riderName, motorcycleModel);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var race = this.raceRepository.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            var rider = this.riderRepository.GetByName(riderName);
            if (rider == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            race.AddRider(rider);
            return String.Format(OutputMessages.RiderAdded, riderName, raceName);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            if (this.motorcycleRepository.GetByName(model) != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.MotorcycleExists, model));
            }

            IMotorcycle motorcylce;

            if (type == "Speed")
            {
                motorcylce = new SpeedMotorcycle(model, horsePower);
            }
            else
            {
                motorcylce = new PowerMotorcycle(model, horsePower);

            }

            this.motorcycleRepository.Add(motorcylce);
            return String.Format(OutputMessages.MotorcycleCreated, motorcylce.GetType().Name, model);
        }

        public string CreateRace(string name, int laps)
        {
            if (this.raceRepository.GetByName(name) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExists, name));
            }

            var race = new Race(name, laps);
            this.raceRepository.Add(race);

            return String.Format(OutputMessages.RaceCreated, name);
        }

        public string CreateRider(string riderName)
        {
            if (this.riderRepository.GetByName(riderName) != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.RiderExists, riderName));
            }

            var rider = new Rider(riderName);
            this.riderRepository.Add(rider);
            return String.Format(OutputMessages.RiderCreated, riderName);
        }

        public string StartRace(string raceName)
        {
            var race = this.raceRepository.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Riders.Count < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceInvalid, raceName, MinimumParticipants));
            }

            List<IRider> topThreeRiders = race.Riders
                .OrderByDescending(x => x.Motorcycle.CalculateRacePoints(race.Laps))
                .Take(3)
                .ToList();

            var firstPlace = topThreeRiders[0];
            var secondPlace = topThreeRiders[1];
            var thirdPlace = topThreeRiders[2];

            firstPlace.WinRace();

            this.raceRepository.Remove(race);

            return String.Format(OutputMessages.RiderFirstPosition, firstPlace.Name, race.Name) + Environment.NewLine +
                    String.Format(OutputMessages.RiderSecondPosition, secondPlace.Name, race.Name) + Environment.NewLine +
                    String.Format(OutputMessages.RiderThirdPosition, thirdPlace.Name, race.Name);
        }
    }
}
