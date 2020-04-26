namespace _1._Logger.Models.Errors
{
    using System;

    using Models.Enumerations;
    using Models.Errors.Contracts;

    public class Error : IError
    {
        public Error(DateTime dateTime, ReportLevel level, string message)
        {
            this.Time = dateTime;
            this.Level = level;
            this.Message = message;
        }

        public DateTime Time { get; }

        public ReportLevel Level { get; }

        public string Message { get; }
    }
}
