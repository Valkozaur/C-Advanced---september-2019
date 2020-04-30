namespace RobotService.Models.Procedures
{
    using System;

    using Robots.Contracts;
    using Utilities.Messages;

    public class Chip : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            if (robot.IsChipped)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.AlreadyChipped, robot.Name));
            }

            robot.Happiness -= 5;
            robot.IsChipped = true;
        }
    }
}
