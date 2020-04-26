namespace _1._Logger.Models.Logger
{
    using System.Collections.Generic;

    using Errors.Contracts;
    using Appenders.Contracts;
    using Models.Logger.Contracts;

    public class Logger : ILogger
    {
        private ICollection<IAppender> appenders;

        public Logger(ICollection<IAppender> appenders)
        {
            this.appenders = appenders;
        }

        public IReadOnlyCollection<IAppender> Appenders => (IReadOnlyCollection<IAppender>)this.appenders;


        public void CallAppenders(IError error)
        {
            foreach (IAppender appender in this.appenders)
            {
                appender.Append(error);
            }
        }
    }
}
