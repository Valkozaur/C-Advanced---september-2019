namespace P07.InfernoInfinity.IOManager
{
    using Contracts;

    public class InputManager : IInputManager
    {
        public string ReadLine()
        {
            return System.Console.ReadLine();
        }
    }
}
