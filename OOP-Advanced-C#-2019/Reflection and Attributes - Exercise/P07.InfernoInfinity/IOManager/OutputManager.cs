namespace P07.InfernoInfinity.IOManager
{
    using Contracts;

    public class OutputManager : IOutputManager
    {
        public void Print(string text)
        {
            System.Console.WriteLine(text);
        }
    }
}
