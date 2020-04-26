namespace _1._Logger.Models.Appenders
{
    using System;

    using Enumerations;
    using Errors.Contracts;
    using Layouts.Contracts;
    using Appenders.Contracts;

    class ConsoleAppender : IAppender
    {
        private ILayout layout;

        public ConsoleAppender(ILayout layout)
            : this(layout, ReportLevel.INFO)
        {
        }

        public ConsoleAppender(ILayout layout, ReportLevel reportLevel)
        {
            this.layout = layout;
            this.ReportLevel = reportLevel;
        }

        public ReportLevel ReportLevel { get; set; }

        private int ReportsCounter { get; set; }

        public void Append(IError error)
        {
            var formattedMessage = string.Format(this.layout.Format, error.Time, error.Level, error.Message);

            if ((int)this.ReportLevel <= (int)error.Level)
            {
                Console.WriteLine(formattedMessage);

                this.ReportsCounter++;
            }
        }

        public override string ToString()
        {
            return $"Appender type: {nameof(ConsoleAppender)}, Layout type: {nameof(this.layout)}, Report level: {this.ReportLevel}, Messages appended: {this.ReportsCounter}";
        }
    }
}
