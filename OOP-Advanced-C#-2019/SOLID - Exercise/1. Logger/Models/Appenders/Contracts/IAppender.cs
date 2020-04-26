namespace _1._Logger.Models.Appenders.Contracts
{
    using Enumerations;

    using Errors.Contracts;

    public interface IAppender
    {
        int ReportsCounter { get; set; }

        ReportLevel ReportLevel { get; }

        void Append(IError error);
    }
}
