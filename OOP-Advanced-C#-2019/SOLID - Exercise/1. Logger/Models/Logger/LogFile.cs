using System.Linq;

namespace _1._Logger.Models.Logger.Contracts
{
    public class LogFile : ILogFile
    {
        public int Size { get; private set; }

        public void Write(string message)
        {
            this.Size += message.Where(x => char.IsLetter(x)).Sum(x => x);
        }
    }
}
