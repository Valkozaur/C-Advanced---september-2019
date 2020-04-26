namespace _1._Logger.Models.Errors.Contracts
{
    using System;

    using Enumerations;

    public interface IError
    {
        DateTime Time { get; }

        ReportLevel Level { get; }

        string Message { get; }
    }
}
