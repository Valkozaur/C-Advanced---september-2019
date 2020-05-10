namespace RobotService.Models.Procedures
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Robots.Contracts;
    using Utilities.Messages;

    public abstract class Procedure : IProcedure
    {
        protected Procedure()
        {
            this.Robots = new HashSet<IRobot>();
        }

        public virtual void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }

            robot.ProcedureTime -= procedureTime;
            this.Robots.Add(robot);
        }

        public string History()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(this.GetType().Name);

            foreach(IRobot robot in this.Robots)
            {
                stringBuilder.AppendLine(robot.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }

        protected ICollection<IRobot> Robots;
    }
}
