namespace _1._Logger.Models.Logger.Contracts
{
    public interface ILogFile
    {
        int Size { get; }

        void Write(string text);
    }
}
