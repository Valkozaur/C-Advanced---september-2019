namespace _1._Logger.Models.Logger.Contracts
{
    using System.Collections.Generic;

    using Appenders.Contracts;
    using Errors.Contracts;

    public interface ILogger
    {
        IReadOnlyCollection<IAppender> Appenders { get; }

        void CallAppenders(IError error);
    }
}
