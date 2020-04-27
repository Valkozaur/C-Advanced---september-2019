using MXGP.IO;

namespace MXGP.Core.Contracts
{
    public interface IEngine
    {
        ConsoleReader ConsoleReader { get; }

        ConsoleWriter ConsoleWriter { get; }

        void Run();
    }
}
