using System;
using System.Linq;
using RobotService.Models.Factories;
using RobotService.Models.Factories.Contracts;
using RobotService.Models.ProcedureRepository;
using RobotService.Models.ProcedureRepository.Contracts;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Core
{
    using Contracts;
    using Models.Garages;

    public class Controller : IController
    {
        private readonly Garage garage;
        private readonly IRobotFactory robotFactory;
        private readonly IProcedureFactory procedureFactory;
        private readonly IProcedureRepository procedures;

        public Controller()
        {
            this.garage = new Garage();
            this.robotFactory = new RobotFactory();
            this.procedureFactory = new ProcedureFactory();
            this.procedures = new ProcedureRepository();
        }

        public string Charge(string robotName, int procedureTime)
        {
            var robot = GetRobot(robotName);

            var procedure = GetProcedureFromDB(nameof(Charge));

            if (procedure == null)
            {
                procedure = CreateProcedure(nameof(Charge));
            }


            procedure.DoService(robot, procedureTime);

            return $"{robotName} had charge procedure";
        }

        public string Chip(string robotName, int procedureTime)
        {
            var robot = GetRobot(robotName);

            var procedure = GetProcedureFromDB(nameof(Chip));

            if (procedure == null)
            {
                procedure = CreateProcedure(nameof(Chip));
            }


            procedure.DoService(robot, procedureTime);

            return $"{robotName} had chip procedure";
        }

        public string History(string procedureType)
        {
            var procedure = GetProcedureFromDB(procedureType);

            if (procedure == null)
            {
                return String.Empty;
            }

            return procedure.History();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot = this.robotFactory.CreateRobot(robotType, name, energy, happiness, procedureTime);

            this.garage.Manufacture(robot);

            return $"Robot {name} registered successfully";
        }

        public string Polish(string robotName, int procedureTime)
        {
            var robot = GetRobot(robotName);

            var procedure = GetProcedureFromDB(nameof(Polish));

            if (procedure == null)
            {
                procedure = CreateProcedure(nameof(Polish));
            }


            procedure.DoService(robot, procedureTime);

            return $"{robotName} had polish procedure";
        }

        public string Rest(string robotName, int procedureTime)
        {
            var robot = GetRobot(robotName);

            var procedure = GetProcedureFromDB(nameof(Rest));

            if (procedure == null)
            {
                procedure = CreateProcedure(nameof(Rest));
            }


            procedure.DoService(robot, procedureTime);

            return $"{robotName} had rest procedure";
        }

        public string Sell(string robotName, string ownerName)
        {
            var robot = GetRobot(robotName);

            this.garage.Sell(robotName, ownerName);

            if (robot.IsChipped)
            {
                return $"{ownerName} bought robot with chip";
            }
            else
            {
                return $"{ownerName} bought robot without chip";
            }
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            var robot = GetRobot(robotName);

            var procedure = GetProcedureFromDB(nameof(TechCheck));

            if (procedure == null)
            {
                procedure = CreateProcedure(nameof(TechCheck));
            }


            procedure.DoService(robot, procedureTime);

            return $"{robotName} had tech check procedure";
        }

        public string Work(string robotName, int procedureTime)
        {
            var robot = GetRobot(robotName);

            var procedure = GetProcedureFromDB(nameof(Work));

            if (procedure == null)
            {
                procedure = CreateProcedure(nameof(Work));
            }

            procedure.DoService(robot, procedureTime);

            return $"{robotName} was working for {procedureTime} hours";
        }

        private IRobot GetRobot(string robotName)
        {
            var keyValuePair = this.garage.Robots
                .FirstOrDefault(x => x.Key == robotName);
            var robot = keyValuePair.Value;

            if (robot == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            return robot;
        }

        private IProcedure GetProcedureFromDB(string procedureName)
        {
            IProcedure procedure = procedures.GetProcedure(procedureName);

            return procedure;
        }

        private IProcedure CreateProcedure(string procedureName)
        {
            var procedure = this.procedureFactory.CreateProcedure(procedureName);
            this.procedures.AddProcedure(procedure);
            return procedure;
        }
    }
}
