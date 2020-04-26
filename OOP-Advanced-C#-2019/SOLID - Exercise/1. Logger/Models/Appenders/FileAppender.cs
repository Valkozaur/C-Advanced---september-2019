namespace _1._Logger.Models.Appenders
{
    using System;
    using System.IO;

    using Enumerations;
    using Errors.Contracts;
    using Logger.Contracts;
    using Layouts.Contracts;
    using Appenders.Contracts;

    public class FileAppender : IAppender
    {
        private const string Path = @"..\..\..\log.txt";

        private ILayout layout;
        private ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile)
            :this(layout, logFile, ReportLevel.INFO)
        {
        }

        public FileAppender(ILayout layout, ILogFile logFile, ReportLevel reportLevel)
        {
            this.layout = layout;
            this.logFile = logFile;
            this.ReportLevel = reportLevel;
        }

        public ReportLevel ReportLevel { get; set; }

        private int ReportsCounter { get; set; }

        public void Append(IError error)
        {
            var formatedMessage = string.Format(this.layout.Format, error.Time.ToString(), error.Level, error.Message);

            if ((int)this.ReportLevel <= (int)error.Level)
            {
                File.AppendAllText(Path, formatedMessage + Environment.NewLine);
                this.logFile.Write(formatedMessage);

                this.ReportsCounter++;
            }
        }

        public override string ToString()
        {
            return $"Appender type: {nameof(FileAppender)}, Layout type: {nameof(this.layout)}, Report level: {this.ReportLevel}, Messages appended: {this.ReportsCounter}, File size: {this.logFile.Size}";
        }
    }
}
