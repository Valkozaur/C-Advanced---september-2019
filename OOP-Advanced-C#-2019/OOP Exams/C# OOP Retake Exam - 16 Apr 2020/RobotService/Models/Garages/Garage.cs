namespace RobotService.Models.Garages
{
    using System.Collections.Generic;

    using Robots.Contracts;
    using Garages.Contracts;
    using System;
    using RobotService.Utilities.Messages;

    public class Garage : IGarage
    {
        private const int MaxCapacity = 10;
        
        private Dictionary<string, IRobot> robots;

        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
        }

        public IReadOnlyDictionary<string, IRobot> Robots => this.robots;

        public void Manufacture(IRobot robot)
        {
            if (this.robots.Count > MaxCapacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            if (this.robots.ContainsKey(robot.Name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingRobot, robot.Name));
            }

            this.robots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!this.robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            var robot = this.robots[robotName];

            robot.Owner = ownerName;
            robot.IsBought = true;
            this.robots.Remove(robotName);
        }
    }
}
