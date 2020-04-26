namespace _1._Logger
{
    using Models;

    public class Program
    {
        public static void Main()
        {
            var commandInterpreter = new CommandInterpreter();

            commandInterpreter.Run();
        }
    }
}
